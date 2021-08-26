namespace ConsoleApp.Providers
{
    using ConsoleApp.Models;
    using System;
    using System.Collections.Generic;

    public static class DoughnutModelProvider
    {
        public static DoughnutModel GetDoughnutModel()
        {

            var random = new Random();

            var doughnutModel = new DoughnutModel()
            {
                Data = new List<int> { random.Next(1, 100), random.Next(1, 100),random.Next(1, 100),
                                        random.Next(1, 100), random.Next(1, 100) },

                Label = new List<string>() { "Data 1", "Data 2", "Data 3", "Data 4", "Data 5" }
            };

            return doughnutModel;
        }

        public static IList<DoughnutModel> GetListDoughnutModel()
        {

            var random = new Random();

            List<string> labels = new List<string>()
            {
                "Data 1", "Data 2", "Data 3", "Data 4", "Data 5"
            };

            var doughnutModelA = new DoughnutModel()
            {
                Data = new List<int> { random.Next(1, 100), random.Next(1, 100),random.Next(1, 100), 
                                        random.Next(1, 100), random.Next(1, 100) },

                Label = labels
            };

            var doughnutModelB = new DoughnutModel()
            {
                Data = new List<int> { random.Next(1, 100), random.Next(1, 100),random.Next(1, 100),
                                        random.Next(1, 100), random.Next(1, 100) },

                Label = labels
            };

            var listDougnutModel = new List<DoughnutModel>()
            {
                doughnutModelA
            };

            return listDougnutModel;
        }
    }
}
