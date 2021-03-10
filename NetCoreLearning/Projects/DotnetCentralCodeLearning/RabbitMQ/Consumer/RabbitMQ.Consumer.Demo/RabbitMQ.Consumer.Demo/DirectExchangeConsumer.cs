using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQ.Consumer.Demo
{
    public static class DirectExchangeConsumer
    {
        public static void Consumer(IModel channel)
        {
            channel.ExchangeDeclare("demo-direct-exchange", ExchangeType.Direct);
            channel.QueueDeclare("demo-direct-queue", true, false, false, null);

            channel.QueueBind("demo-direct-queue", "demo-direct-exchange", "account.init");
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var msg = Encoding.UTF8.GetString(body);
                Console.WriteLine(msg);
            };

            channel.BasicConsume("demo-direct-queue", true, consumer);
            Console.WriteLine($"consumer start");
        }
    }
}
