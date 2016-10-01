namespace ControlWorks.Database.SqlServer
{
    public class SensorDataInternal : InternalBase
    {
        public short? SensorNumber { get; set; }
        public decimal? Position { get; set; }
        public decimal? SensorData0 { get; set; }
        public decimal? SensorData1 { get; set; }
        public decimal? SensorData2 { get; set; }
        public decimal? SensorData3 { get; set; }
        public decimal? SensorData4 { get; set; }
    }
}
