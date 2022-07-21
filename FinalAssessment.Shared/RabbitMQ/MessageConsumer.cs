using FinalAssessment.Shared.RabbitMQ;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssessment.WorkerService.RabbitMQ
{
    public class MessageConsumer : IConsumer<Message>
    {
        public Task Consume(ConsumeContext<Message> context)
        {
            return Task.CompletedTask;
        }
    }
}
