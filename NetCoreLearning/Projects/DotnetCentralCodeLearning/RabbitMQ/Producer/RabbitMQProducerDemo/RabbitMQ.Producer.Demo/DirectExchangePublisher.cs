using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace RabbitMQ.Producer.Demo
{
    public static class DirectExchangePublisher
    {
        public static void Publish(IModel channel)
        {
            channel.ExchangeDeclare("demo-direct-exchange", ExchangeType.Direct);

            var count = 0;

            while (true)
            {
                var msg = new { Name = "Producer", Msg = $"Hello! Count: {count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(msg));

                channel.BasicPublish("demo-direct-exchange", "account.init", null, body);
                count++;

                Thread.Sleep(1000);
            }
        }
    }
}
