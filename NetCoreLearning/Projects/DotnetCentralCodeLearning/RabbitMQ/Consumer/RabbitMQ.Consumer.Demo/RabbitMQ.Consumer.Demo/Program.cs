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

           channel.QueueDeclare("demo-queue", true, false, false, null);

           var consumer = new EventingBasicConsumer(channel);

           consumer.Received += (sender, e) =>
           {
               var body = e.Body.ToArray();
               var msg = Encoding.UTF8.GetString(body);
               Console.WriteLine(msg);
           };

           channel.BasicConsume("demo-queue", true, consumer);

           Console.ReadLine();
        }
    }
}
