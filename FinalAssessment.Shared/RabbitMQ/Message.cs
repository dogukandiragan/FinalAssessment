using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssessment.Shared.RabbitMQ
{
    public class Message
    {

        public string OriginalImagePath { get; set; }
        public DateTime PublishedTime { get; set; }
        public DateTime ConsumedTime { get; set; }
        public Guid QueueId { get; set; }


    }
}
