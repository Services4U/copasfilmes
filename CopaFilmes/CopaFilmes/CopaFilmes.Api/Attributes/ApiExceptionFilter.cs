using CopaFilmes.Infrastructure.CrossCutting.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Api.Attributes
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var codigo = System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString();
            var messagem = context.Exception.Message;
            var rastreamento = context.Exception.StackTrace;
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new JsonResult(new ResultadoBase(codigo, messagem, rastreamento));

            base.OnException(context);
        }
    }
}
