using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using ControlWorks.Common;
using ControlWorks.Database.SqlServer.InternalEntities;

namespace ControlWorks.Database.SqlServer
{
    public class CoilInfo
    {
        private List<SensorDataInternal> _sensorDataList = new List<SensorDataInternal>();

        public CoilDataInternal CoilData { get; set; }
        public LengthDataInternal LengthData  { get; set; }
        public List<SensorDataInternal> SensorData
        {
            get => _sensorDataList;
            set => _sensorDataList = value;
        }

        public string IPAddress { get; set; }
        public string CpuName { get; set; }

        public void AddSensorData(SensorDataInternal data)
        {
            if (data.Position.HasValue && data.Position > 0)
            {
                _sensorDataList.Add(data);
            }
        }

        public string Serialize()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CoilInfo));
            using (var textWriter = new Utf8StringWriter())
            {
                xmlSerializer.Serialize(textWriter, this);
                var result = textWriter.ToString();

                return result;
            }
        }
    }

    class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
