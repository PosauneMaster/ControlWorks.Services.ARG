namespace ControlWorks.UI.Console
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CoilData")]
    public partial class CoilData
    {
        public int CoilDataId { get; set; }

        [StringLength(30)]
        public string MaterialType { get; set; }

        public decimal? MaterialThickness { get; set; }

        public int? OriginalSqYards { get; set; }

        [StringLength(30)]
        public string BatchNumber { get; set; }

        [StringLength(30)]
        public string ChangeNumber { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ExtrusionDate { get; set; }

        [StringLength(30)]
        public string RollSnNumber { get; set; }

        public short? CoilNumber { get; set; }

        public decimal? CoilWidth { get; set; }

        public decimal? TolerancePlus { get; set; }

        public decimal? ToleranceMinus { get; set; }

        [StringLength(30)]
        public string Inspector { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? InspectionDateTime { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CalibrationDate { get; set; }

        [StringLength(40)]
        public string GeneratedMaterialType { get; set; }

        public int? OvenPos { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? BatchRunTimestamp { get; set; }

        public int? MachineNumber { get; set; }

        [StringLength(30)]
        public string CoilSnNumber { get; set; }

        [StringLength(30)]
        public string LabInspector { get; set; }

        public int? RollNumber { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LabInspectDate { get; set; }
    }
}
