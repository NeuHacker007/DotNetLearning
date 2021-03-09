using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQ.Consumer.Demo
{
    public static class QueueConsumer
    {
        public static void Consume(IModel channel)
        {
            channel.QueueDeclare("demo-queue", true, false, false, null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var msg = Encoding.UTF8.GetString(body);
                Console.WriteLine(msg);
            };

            channel.BasicConsume("demo-queue", true, consumer);
            Console.WriteLine($"consumer start");
        }
    }
}
