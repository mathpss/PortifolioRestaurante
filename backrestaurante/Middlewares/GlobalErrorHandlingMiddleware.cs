using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;

namespace backrestaurante.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {

                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private async static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            HttpStatusCode status;
            string stacktrace;
            string mensagem;
            var exceptionType = exception.GetType();

            if(exceptionType == typeof(DBConcurrencyException))
            {
                mensagem = exception.Message;
                status = HttpStatusCode.BadRequest;
                stacktrace = exception.StackTrace;
            }
            else if(exceptionType == typeof(SqlException))
            {
                mensagem = exception.Message;
                status = HttpStatusCode.InternalServerError;
                stacktrace = exception.StackTrace;
            }
            else if(exceptionType == typeof(ApplicationException))
            {
                mensagem = exception.Message;
                status = HttpStatusCode.BadRequest;
                stacktrace = exception.StackTrace;
            }
            else if(exceptionType == typeof(KeyNotFoundException ))
            {
                mensagem = exception.Message;
                status = HttpStatusCode.NotFound;
                stacktrace = exception.StackTrace;
            }

            else
            {
                mensagem = exception.Message;
                status = HttpStatusCode.InternalServerError;
                stacktrace = exception.StackTrace;                
            }

            var response = JsonSerializer.Serialize(new {status, mensagem, stacktrace });

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)status;
            await  httpContext.Response.WriteAsync(response);
        }
    }   
}