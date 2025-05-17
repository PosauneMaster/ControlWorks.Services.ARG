using Newtonsoft.Json;

namespace ControlWorks.Services.PVI.Variables
{
    public class VariableData
    {

        public string VariableName { get; set; }
        public string CpuName { get; set; }
        public string TaskName { get; set; }
        public string IpAddress { get; set; }
        public string DataType { get; set; }
        public string Value { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}