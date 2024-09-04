using Grpc.Net.Client;
using GrpcGreeterClient;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Press any key to start...");
Console.ReadKey();
Console.WriteLine("Connecting to gRPC server...\r\n");

// Setup dependency injection
var serviceCollection = new ServiceCollection();
serviceCollection.AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:7145");
    });

var serviceProvider = serviceCollection.BuildServiceProvider();

// Do the actual work
var client = serviceProvider.GetRequiredService<Greeter.GreeterClient>();
var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });

Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("\r\nPress any key to exit...");
Console.ReadKey();