namespace ControlWorks.Database.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SensorReport")]
    public partial class SensorReport
    {
        public long SensorReportId { get; set; }
        public int? CoilDataId { get; set; }

        public decimal? SensorMeasurement { get; set; }

        public short? MeasurementCount { get; set; }
    }
}
