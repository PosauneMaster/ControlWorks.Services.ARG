namespace ControlWorks.Database.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SensorData")]
    public partial class SensorData
    {
        public int SensorDataId { get; set; }

        public int? CoilDataId { get; set; }

        public short? SensorNumber { get; set; }

        public decimal? Position { get; set; }

        public decimal? SensorData0 { get; set; }

        public decimal? SensorData1 { get; set; }

        public decimal? SensorData2 { get; set; }

        public decimal? SensorData3 { get; set; }

        public decimal? SensorData4 { get; set; }
    }
}
