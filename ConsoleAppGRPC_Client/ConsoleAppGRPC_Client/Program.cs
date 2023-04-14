// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using GrpcService1;

Console.WriteLine("Hello, World!");


using var channel = GrpcChannel.ForAddress("https://localhost:7106");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = "GreeterClient HALLO" });
Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey(); 