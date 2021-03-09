using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace RabbitMQ.Producer.Demo
{
    public static class QueueProducer
    {
        public static void Publish(IModel channel)
        {
            channel.QueueDeclare("demo-queue", true, false, false, null);

            var count = 0;

            while (true)
            {
                var msg = new { Name = "Producer", Msg = $"Hello! Count: {count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(msg));

                channel.BasicPublish("", "demo-queue", null, body);
                count++;
            }

            
        }
    }
}
