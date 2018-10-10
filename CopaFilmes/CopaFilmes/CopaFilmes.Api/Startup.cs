using AutoMapper;
using CopaFilmes.Api.Attributes;
using CopaFilmes.AppService.Validations;
using CopaFilmes.Infrastructure.CrossCutting.IoC;
using CopaFilmes.Infrastructure.CrossCutting.Utilities;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CopaFilmes.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();

            Configuration = builder.Build();

            //Serilog para Log
            //Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();
            //Infrastructure.CrossCutting.Logs.Log.Register(Serilog.Log.Logger);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //MVC e Fluent Validation
            services
                .AddMvc(options => {
                    options.Filters.Add(new ApiExceptionFilter());//Tratamento das Exceptions
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            //Swagger
            services.AddSwaggerGen(c => {
                c.SwaggerDoc(Configuration["SwaggerVersion"].ToString(),
                new Info {
                    Title = Configuration["SwaggerTitle"].ToString(),
                    Version = Configuration["SwaggerVersion"].ToString(),
                    Description = Configuration["SwaggerDescription"].ToString(),
                    TermsOfService = "None",
                    Contact = new Contact { Name = Configuration["SwaggerContactName"].ToString(), Email = Configuration["SwaggerContactEmail"].ToString(), Url = Configuration["SwaggerContactUrl"].ToString() }
                });

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> { { "Bearer", Enumerable.Empty<string>() } });
            });

            //Autenticacao JWT - Json Web Token
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options => {

                var sec = Encoding.UTF8.GetBytes(Configuration["SecretKey"].ToString());

                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateAudience = false,
                    ValidAudience = "The name of audience",
                    ValidateIssuer = false,
                    ValidIssuer = "The name of issuer",

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(sec),
                    ValidateLifetime = true,
                };
            });

            //Cors
            services.AddCors();

            //Lendo chaves no arquivo de configuracoes
            services.AddOptions();
            services.Configure<KeysConfig>(Configuration);

            //AutoMapper
            services.AddAutoMapper();

            //Injecao de dependencia nativa
            var ioc = new InjectorContainer();
            services = ioc.ObterScopo(services);

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Adicionar a compressão ao servico
            services.AddResponseCompression();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //Serilog para Log
            //loggerFactory.AddSerilog();
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials()
            );
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", Configuration["SwaggerTitle"].ToString());
            });

            //Informando ao app que deve usar compressao
            app.UseResponseCompression();
        }
    }
}
