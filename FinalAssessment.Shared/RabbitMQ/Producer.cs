using MassTransit;
using RabbitMQ.Client;


namespace FinalAssessment.Shared.RabbitMQ
{
    public class Producer
    {

 
        string rabbitMqUrl = "amqps://ssqovqfx:CGZc-Unhh3GJUMZ5GuidOs8cA1nIkEL5@jackal.rmq.cloudamqp.com/ssqovqfx";
        string userName = "ssqovqfx";
        string password = "CGZc-Unhh3GJUMZ5GuidOs8cA1nIkEL5";

        public Producer(string originalImagePath)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {

                cfg.Host(new Uri(rabbitMqUrl), h =>
                {
                    h.Username(userName);
                    h.Password(password);
                });
            
            });
            busControl.Start();

            Message m = new Message {
                PublishedTime = DateTime.Now,
                OriginalImagePath = originalImagePath
            };


            busControl.Publish(m);


        }








    }

}


