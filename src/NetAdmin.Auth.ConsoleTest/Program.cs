using System;
using System.Net.Http;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace NetAdmin.Auth.ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            new Program().ExecuteAsync();

            Console.WriteLine("\nEnd of program, press any key...");
            Console.ReadKey();
        }

        public async void ExecuteAsync()
        {
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");
            var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }
            Send(tokenResponse);

            Console.WriteLine(tokenResponse.Json);
        }

        public async void Send(TokenResponse tokenResponse)
        {
            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync("http://localhost:5000/identity");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}