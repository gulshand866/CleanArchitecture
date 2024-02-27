using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.KafkaProducers
{
    public interface IKafkaProducer
    {
        public Task ProduceMessage(object message);
    }
}
