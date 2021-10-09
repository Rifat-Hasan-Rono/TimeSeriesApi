using System;

namespace TimeSeriesApi
{
    public class Reading
    {
        public Int64 Timestamp { get; set; }
        public int BuildingId { get; set; }
        public int ObhectId { get; set; }
        public int DataFieldId { get; set; }
        public decimal Value { get; set; }
    }
}
