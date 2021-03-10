using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQ.Consumer.Demo
{
    static class Program
    {
        static void Main(string[] args)
        {
           var factory = new ConnectionFactory()
           {
               Uri = new Uri("amqp://guest:guest@localhost:5672")
           };

           using var connection = factory.CreateConnection();
           using var channel = connection.CreateModel();

           //QueueConsumer.Consume(channel);

           DirectExchangeConsumer.Consumer(channel);

           Console.ReadLine();
        }
    }
}
