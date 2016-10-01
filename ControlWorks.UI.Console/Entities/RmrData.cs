namespace ControlWorks.UI.Console
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RmrData")]
    public partial class RmrData
    {
        [Key]
        public int RmrId { get; set; }

        [StringLength(10)]
        public string Material { get; set; }

        [StringLength(12)]
        public string RMR { get; set; }
    }
}
