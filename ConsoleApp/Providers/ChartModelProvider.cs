namespace ConsoleApp.Providers
{
    using ConsoleApp.Models;
    using System;
    using System.Collections.Generic;

    public static class ChartModelProvider
    {
        public static IList<ChartModel> GetListOfChartModels()
        {
            var random = new Random();
            IList<ChartModel> chartModelData = new List<ChartModel>()
                {
                    new ChartModel { Data = new List<int> { random.Next(1, 100) }, Label = "Data1", BackgroundColor = string.Format("#{0:X6}", random.Next(0x1000000)) },
                    new ChartModel { Data = new List<int> { random.Next(1, 100) }, Label = "Data2", BackgroundColor = string.Format("#{0:X6}", random.Next(0x1000000)) },
                    new ChartModel { Data = new List<int> { random.Next(1, 100) }, Label = "Data3", BackgroundColor = string.Format("#{0:X6}", random.Next(0x1000000)) },
                    new ChartModel { Data = new List<int> { random.Next(1, 100) }, Label = "Data4", BackgroundColor = string.Format("#{0:X6}", random.Next(0x1000000)) },
                    new ChartModel { Data = new List<int> { random.Next(1, 100) }, Label = "Data5", BackgroundColor = string.Format("#{0:X6}", random.Next(0x1000000)) },
                    new ChartModel { Data = new List<int> { random.Next(1, 100) }, Label = "Data6", BackgroundColor = string.Format("#{0:X6}", random.Next(0x1000000)) },
                };

            return chartModelData;
        }
    }
}
