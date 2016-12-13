using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace NetAdmin.Auth
{
    public static class MiddlewareSetup
    {
        public const string AuthCookieScheme = "Cookie";
        private const string AuthCookieName = "access_token";
        private const string TokenSecret = "mysupersecret_secretkey!123";
        private const string TokenAudience = "ExampleAudience";
        private const string TokenIssuer = "ExampleIssuer";

        public static void UseJwtMiddleware(this IApplicationBuilder app)
        {
            var signingKey = GetSigningKey();
            var options = new TokenProviderOptions
            {
                Audience = TokenAudience,
                Issuer = TokenIssuer,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            };

            app.UseMiddleware<TokenProviderMiddleware>(Options.Create(options));
        }

        public static void AddJwtCookieAuthentication(this IApplicationBuilder app)
        {
            var signingKey = GetSigningKey();
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = TokenIssuer,
                ValidateAudience = true,
                ValidAudience = TokenAudience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                AuthenticationScheme = AuthCookieScheme,
                CookieName = AuthCookieName,
                TicketDataFormat = new CustomJwtDataFormat(SecurityAlgorithms.HmacSha256, tokenValidationParameters)
            });
        }

        private static SecurityKey GetSigningKey()
            => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenSecret));
    }
}