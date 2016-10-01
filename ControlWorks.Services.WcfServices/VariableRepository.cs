using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Services.WcfServices
{

    [DataContract]
    public class VariableRepository
    {
        public VariableRepository()
        {
            Variables = new List<VariableMap>();
        }
        [DataMember]
        public int MachineId { get; set; }

        [DataMember]
        public List<VariableMap> Variables {get; set;}

        public void Add(string runningPart, string currentPart)
        {
            Variables.Add(new VariableMap { RunningPart = runningPart, CurrentPart = currentPart });
        }
    }

    [Serializable]
    public class VariableMap
    {
        public string RunningPart {get; set;}
        public string CurrentPart { get; set; }

    }
}
