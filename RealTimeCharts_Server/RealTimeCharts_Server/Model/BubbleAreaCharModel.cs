using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeCharts_Server.Model
{
    public class BubbleAreaCharModel
    {      
        public List<int> Data { get; set;}
        public string Label {get; set;}
        public string BackgroundColor { get; set; }
    }

    public class PointBubbleChartModel
    {
       public int CoordinateX { get; set; }
       public int CoordinateY { get; set; }
       public double Radiux { get; set; }
    }
}
