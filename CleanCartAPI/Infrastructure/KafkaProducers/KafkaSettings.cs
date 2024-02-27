﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.KafkaProducers
{
    public class KafkaSettings
    {
        public string? BootstrapServers { get; set; }

        public string? Topic { get; set; }

        public string? SaslUsername { get; set; }

        public string? SaslPassword { get; set; }


    }
}
