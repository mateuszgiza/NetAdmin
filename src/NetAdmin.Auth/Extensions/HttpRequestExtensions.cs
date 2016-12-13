using System;
using Microsoft.AspNetCore.Http;

namespace NetAdmin.Auth
{
    public static class HttpRequestExtensions
    {
        public static bool IsCorrectTokenRequest(this HttpRequest request)
        {
            return request.Method.Equals("POST") &&
                   request.HasFormContentType;
        }

        public static bool IsCorrectTokenPath(this HttpRequest request, TokenProviderOptions options)
        {
            return request.Path.Equals(options.Path, StringComparison.Ordinal);
        }
    }
}