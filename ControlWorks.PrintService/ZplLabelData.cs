using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.PrintService
{
    public class ZplLabelData
    {
        public string MaterialType { get; set; }
        public string GeneratedMaterialType { get; set; }
        public string SqYards { get; set; }
        public string TolerancePlus { get; set; }
        public string ToleranceMinus { get; set; }
        public string ChangeNumber { get; set; }
        public string Batch { get; set; }
        public DateTime InspectionDate { get; set; }
        public DateTime ProductionDate { get { return DateTime.Now; } }
        public string CoilSerialNumber { get; set; }
        public string Inspector { get; set; }
        public string LabInspector { get; set; }
        public DateTime LabInspectionDate { get; set; }
        public string RmR { get; set; }
        public DateTime CalibrationDate { get; set; }

        public string LinearMeters { get; set; }

        public string GetSqYards()
        {
            return String.Format("{0} SqYards", SqYards);
        }
        public string GetRmR()
        {
            var rmr = RmR.Replace("RMR ", String.Empty);
            return rmr;
        }

        public string GetTolerance()
        {
            return String.Format("+{0} / -{1}", TolerancePlus, ToleranceMinus);
        }

        public string GetToleranceField()
        {
            return String.Format("TOL +{0} / -{1}", TolerancePlus, ToleranceMinus);
        }

        public string GetChangeField()
        {
            return String.Format("CHNG {0}", ChangeNumber);
        }

        public string GetBatchField()
        {
            return String.Format("BATCH {0}", Batch);
        }

        public string GetInspectionField()
        {
            return String.Format("{0}", InspectionDate.ToString("MM/dd/yy"));
        }

        public string GetProductionDateField()
        {
            return String.Format("CAL DATE {0}", ProductionDate.ToString("MM/dd/yy"));
        }

        public string GetCalibrationDateField()
        {
            return String.Format("CAL DATE {0}", CalibrationDate.ToString("MM/dd/yy"));
        }

        public string GetLabInspectionDateField()
        {
            return String.Format("{0}", LabInspectionDate.ToString("MM/dd/yy"));
        }

        public void SetLabInspectionDate(string date)
        {
            DateTime dt;

            if (DateTime.TryParse(date, out dt))
            {
                LabInspectionDate = new DateTime(dt.Year, dt.Month, dt.Day);
            }
        }

        public void SetInspectionDate(string date, string time)
        {
            DateTime dt;
            DateTime tm;

            if (DateTime.TryParse(date, out dt) && DateTime.TryParse(time, out tm))
            {
                InspectionDate = new DateTime(dt.Year, dt.Month, dt.Day, tm.Hour, tm.Minute, tm.Second);
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

        public void SetSqYards(string length)
        {
            decimal l;
            if (Decimal.TryParse(length, out l))
            {
                SqYards = l.ToString("N1");
            }
            else
            {
                SqYards = "0.0";
            }
        }

        public void SetLinearMeters(string length)
        {
            decimal l;
            if (Decimal.TryParse(length, out l))
            {
                LinearMeters = l.ToString("N1");
            }
            else
            {
                LinearMeters = "0.0";
            }
        }

    }

}
