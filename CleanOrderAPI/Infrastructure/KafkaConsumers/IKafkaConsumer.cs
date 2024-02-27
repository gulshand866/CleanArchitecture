using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.KafkaConsumers
{
    public interface IKafkaConsumer
    {
        public void ConsumeMessages(CancellationToken cancellationToken);
        public void RunInBackground();


    }
}
