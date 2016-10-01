namespace ControlWorks.Database.SqlServer
{
    public class SensorReportInternal : InternalBase
    {
        public decimal? SensorMeasurement { get; set; }
        public short? MeasurementCount { get; set; }
    }
}
