using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Services.WcfServices
{
    public interface IHeartbeat
    {
        bool Beat { get; set; }
        string Timestamp { get; }
    }
}
