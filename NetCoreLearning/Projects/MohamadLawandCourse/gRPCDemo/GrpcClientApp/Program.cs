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

            var allCustomers = customerClient.GetAllCustomers(new AllCustomerModel());
            // use await foreach to avoid thread blocking 
            await foreach (var customer in allCustomers.ResponseStream.ReadAllAsync())
            {
                System.Console.WriteLine($"First Name: {customer.FirstName} \nLast Name: {customer.LastName}");
            }
        }
    }
}
