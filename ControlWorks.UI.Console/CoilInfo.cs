using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlWorks.UI.Console
{
    public class CoilInfo
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

        public int LengthDataId { get; set; }

        public decimal? Good { get; set; }

        public decimal? ThicknessScrap { get; set; }

        public decimal? ThicknessReclass { get; set; }

        public decimal? Blisters { get; set; }

        public decimal? Contamination { get; set; }

        public decimal? Gas { get; set; }

        public decimal? Holes { get; set; }

        public decimal? Lumps { get; set; }

        public decimal? PaperBreaks { get; set; }

        public decimal? PaperSplice { get; set; }

        public decimal? Shiny { get; set; }

        public decimal? SlitterDefect { get; set; }

        public decimal? TapeInCoil { get; set; }

        public decimal? Wrinkles { get; set; }

        public decimal? Width { get; set; }

        public decimal? Other { get; set; }

        public decimal? Salvage { get; set; }

    }
}
