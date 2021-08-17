namespace RealTimeCharts_Server.Models
{
    using System.Collections.Generic;

    public class ChartModel
    {
        public List<int> Data { get; set; }
        public string Label { get; set; }
        public string BackgroundColor { get; set; }
    }
}
