namespace ControlWorks.Database.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LengthData")]
    public partial class LengthData
    {
        public int LengthDataId { get; set; }

        public int CoilDataId { get; set; }

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

        public decimal? LinearMeters { get; set; }
    }
}
