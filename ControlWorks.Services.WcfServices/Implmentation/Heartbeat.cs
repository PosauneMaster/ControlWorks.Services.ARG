using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;


namespace ControlWorks.Services.WcfServices
{
    [DataContract]
    public class Heartbeat
    {
        bool _beat = true;
        DateTime _timestamp = DateTime.Now;

        [DataMember]
        public bool Beat
        {
            get { return _beat; }
            set { _beat = value; }
        }

        [DataMember]
        public DateTime Timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }
    }
}
