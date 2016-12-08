using IdentityModel.Client;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");

        new Program().ExecuteAsync();

        Console.WriteLine("\nEnd of program, press any key...");
        Console.ReadKey();
    }

    public async void ExecuteAsync()
    {
        var disco = await DiscoveryClient.GetAsync(@"http://localhost:5000");
        var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
        var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

        if (tokenResponse.IsError)
        {
            Console.WriteLine(tokenResponse.Error);
            return;
        }

        Console.WriteLine(tokenResponse.Json);
    }
}