namespace ControlWorks.Services
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CoilMeasurement")]
    public partial class CoilMeasurement
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CoilTypeId { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal Measurement { get; set; }

        public int MeasurementCount { get; set; }
    }
}
