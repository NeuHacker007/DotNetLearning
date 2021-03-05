using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace RabbitMQ.Producer.Demo
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

            var msg = new {Name = "Producer", Msg = "Hello"};
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(msg));

            channel.BasicPublish("", "demo-queue",null, body);
        }
    }
}
