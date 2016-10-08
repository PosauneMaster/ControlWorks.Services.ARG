using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ControlWorks.PrintService
{
    public class LabelSettingsAmerican
    {
        public Point GeneratedMaterialType { get; set; }
        public Point GeneratedMaterialTypeBarcode { get; set; }
        public Point SqYards { get; set; }
        public Point SqYardsBarcode { get; set; }
        public Point INSP { get; set; }
        public Point LAB { get; set; }
        public Point MATLINSP { get; set; }
        public Point LabInspectionDate { get; set; }
        public Point InspectionDate { get; set; }
        public Point LabInspector { get; set; }
        public Point Inspector { get; set; }
        public Point Tolerance { get; set; }
        public Point Change { get; set; }
        public Point BatchField { get; set; }
        public Point CalibrationDate { get; set; }
        public Point Batch1 { get; set; }
        public Point Batch1Barcode { get; set; }
        public Point CoilSerialNumber1Barcode { get; set; }
        public Point CoilSerialNumber1Text { get; set; }
        public Point Batch2 { get; set; }
        public Point Batch2Barcode { get; set; }
        public Point CoilSerialNumber2Barcode { get; set; }
        public Point CoilSerialNumber2Text { get; set; }

        public string ToXml()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());

            using (var sw = new Utf8StringWriter())
            {
                serializer.Serialize(sw, this);

                return sw.ToString();
            }
        }

        public void SetProperty(string name, string value)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this);
            PropertyDescriptor prop = props[name];

            if (prop.Converter.IsValid(value))
            {
                prop.SetValue(this, prop.Converter.ConvertFromInvariantString(value));
            }
        }

    }

    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding { get { return Encoding.UTF8; } }
    }
}
