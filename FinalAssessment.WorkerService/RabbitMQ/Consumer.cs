using FinalAssessment.Shared.RabbitMQ;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssessment.WorkerService.RabbitMQ
{
    public class Consumer
    {
        string rabbitMqUrl = "amqps://ssqovqfx:CGZc-Unhh3GJUMZ5GuidOs8cA1nIkEL5@jackal.rmq.cloudamqp.com/ssqovqfx";
        string userName = "ssqovqfx";
        string password = "CGZc-Unhh3GJUMZ5GuidOs8cA1nIkEL5";


        public Consumer()
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {

                cfg.Host(new Uri(rabbitMqUrl), h =>
                {
                    h.Username(userName);
                    h.Password(password);
                });


                cfg.ReceiveEndpoint(endpoint => endpoint.Consumer<MessageConsumer>());


            });
            busControl.Start();

            busControl.Stop();



        }


















    }
}
