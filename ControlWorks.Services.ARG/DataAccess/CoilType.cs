namespace ControlWorks.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CoilType")]
    public partial class CoilType
    {
        [Key]
        public int CoilTypeId { get; set; }

        public decimal? ToleranceMinus { get; set; }

        public decimal? TolerancePlus { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CalibrationDate { get; set; }

        public int? OriginalSqYards { get; set; }

        public short? CoilWidth { get; set; }

        public short? CoilNumber { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(30)]
        public string ChangeNumber { get; set; }

        public short? RollNumber { get; set; }

        [StringLength(30)]
        public string Inspector { get; set; }

        [StringLength(30)]
        public string BatchNumber { get; set; }

        [StringLength(30)]
        public string MaterialType { get; set; }

        public int? OvenPos { get; set; }

        public decimal? MaterialThk { get; set; }

        public decimal? Length { get; set; }

        public string Data { get; set; }

        public decimal? Mean { get; set; }

        public decimal? Nom { get; set; }


    }
}
