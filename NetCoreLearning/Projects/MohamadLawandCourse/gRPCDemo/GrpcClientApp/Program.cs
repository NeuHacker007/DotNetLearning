using System;
using Grpc.Net.Client;
using Grpc.Core;
using System.Threading.Tasks;

namespace GrpcClientApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello gRPC from Ivan!");

            var channel = GrpcChannel.ForAddress("http://localhost:5000");

            var customerClient = new Customer.CustomerClient(channel);

            var result = await customerClient.GetCustomerInfoAsync(new CustomerFindModel()
            {
                UserId = 10
            });
            // System.Console.WriteLine(result.FirstName);
            System.Console.WriteLine($"First Name: {result.FirstName} \nLast Name: {result.LastName}");
        }
    }
}
