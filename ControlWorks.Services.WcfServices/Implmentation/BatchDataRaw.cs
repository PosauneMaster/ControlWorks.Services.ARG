﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Services.WcfServices
{
    [DataContract]
    public class BatchDataRaw : IBatchDataRaw
    {
        [DataMember]
        public string RawBatchData { get; set; }
    }
}
