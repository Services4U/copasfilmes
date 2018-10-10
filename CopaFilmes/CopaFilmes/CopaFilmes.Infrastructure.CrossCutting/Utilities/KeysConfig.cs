namespace CopaFilmes.Infrastructure.CrossCutting.Utilities
{
    public class KeysConfig
    {
        public string TypeDB { get; set; }
        public string ConnectionDB { get; set; }
        public string SwaggerVersion { get; set; }
        public string SwaggerTitle { get; set; }
        public string SwaggerDescription { get; set; }
        public string SwaggerContactName { get; set; }
        public string SwaggerContactEmail { get; set; }
        public string SwaggerContactUrl { get; set; }
        public string EmailFrom { get; set; }
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public string SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPassword { get; set; }
        public string CryptoVector { get; set; }
        public string CryptoKey { get; set; }
        public string SecretKey { get; set; }
    }
}
