using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace NetAdmin.Auth
{
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;

        public TokenProviderMiddleware(RequestDelegate next, IOptions<TokenProviderOptions> options)
        {
            _next = next;
            _options = options.Value;
        }

        public Task Invoke(HttpContext context)
        {
            if (!context.Request.IsCorrectTokenPath(_options))
            {
                return _next(context);
            }

            if (context.Request.IsCorrectTokenRequest())
            {
                return GenerateTokenAsync(context);
            }

            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return context.Response.WriteAsync("Bad Request!");
        }

        private async Task GenerateTokenAsync(HttpContext context)
        {
            var username = context.Request.Form["username"];
            var password = context.Request.Form["password"];

            var identity = await GetIdentity(username, password);
            if (identity == null)
            {
                context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                await context.Response.WriteAsync("Invalid username or password");
                return;
            }

            var now = DateTime.UtcNow;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)_options.Expiration.TotalSeconds
            };

            context.Response.ContentType = "application/json";
            var jsonSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, jsonSettings));
        }

        private Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            if (CheckCredentials(username, password) == false)
            {
                return Task.FromResult<ClaimsIdentity>(null);
            }

            var emptyClaims = new Claim[] { };
            var genericIdentity = new GenericIdentity(username, "Token");

            return Task.FromResult(new ClaimsIdentity(genericIdentity, emptyClaims));
        }

        private bool CheckCredentials(string username, string password)
        {
            var userExists = username.Equals("admin", StringComparison.OrdinalIgnoreCase);
            var correctPassword = password.Equals("admin", StringComparison.OrdinalIgnoreCase);

            return userExists && correctPassword;
        }
    }
}
