using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ControlWorks.Database.SqlServer
{
    public class CoilInfo
    {
        private List<SensorDataInternal> _sensorDataList;
        public CoilInfo()
        {
            _sensorDataList = new List<SensorDataInternal>();
        }
        public CoilDataInternal CoilData { get; set; }
        public LengthDataInternal LengthData  { get; set; }
        public List<SensorDataInternal> SensorData
        {
            get
            {
                return _sensorDataList;
            }
            set { _sensorDataList = value; }
        }
        public SensorReportInternal[] SensorReport { get; set; }

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
