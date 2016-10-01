using System;

namespace ControlWorks.Database.SqlServer
{
    public class CoilDataInternal : InternalBase
    {
        public string MaterialType { get; set; }
        public decimal? MaterialThickness { get; set; }
        public int? OriginalSqYards { get; set; }
        public string BatchNumber { get; set; }
        public string ChangeNumber { get; set; }
        public DateTime? ExtrusionDate { get; set; }
        public string RollSnNumber { get; set; }
        public short? CoilNumber { get; set; }
        public decimal? CoilWidth { get; set; }
        public decimal? TolerancePlus { get; set; }
        public decimal? ToleranceMinus { get; set; }
        public string Inspector { get; set; }
        public DateTime? InspectionDateTime { get; set; }
        public DateTime? CalibrationDate { get; set; }
        public string GeneratedMaterialType { get; set; }
        public DateTime? BatchRunTimestamp { get; set; }
        public int? OvenPos { get; set; }
        public int? MachineNumber { get; set; }
        public string Coil_SN_Number { get; set; }
        public string LabInspector { get; set; }
        public DateTime? LabInspectDate { get; set; }
        public int? RollNumber { get; set; }

        public void SetLabInspectDate(string inspectDate)
        {
            DateTime dt;
            if (DateTime.TryParse(inspectDate, out dt))
            {
                LabInspectDate = dt;
            }
        }

        public void SetInspectionDateTime(string date, string time)
        {
            DateTime dt;
            DateTime tm;

            if (DateTime.TryParse(date, out dt) && DateTime.TryParse(time, out tm))
            {
                InspectionDateTime = new DateTime(dt.Year, dt.Month, dt.Day, tm.Hour, tm.Minute, tm.Second);
            }
        }
    }
}
