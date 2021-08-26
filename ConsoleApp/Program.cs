namespace ConsoleApp
{
    using ConsoleApp.Models;
    using ConsoleApp.Providers;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            // Data
            var chartModelData = ChartModelProvider.GetListOfChartModels();
            var dougnutModelData = DoughnutModelProvider.GetListDoughnutModel();

            Task[] tasks = new Task[]
            {
                Task.Run(() => { RunChartDataHttpPost("http://localhost:5000/api/Chart", chartModelData); }),
                Task.Run(() => { DoughnutDataHttpPost("http://localhost:5000/api/Doughnut", dougnutModelData); })
            };

            Task.WaitAll(tasks);
        }

        /// <summary>
        ///     Sending chart module data against the chart controller to WEB API.
        /// </summary>
        /// <param name="url">Chart controller URL</param>
        /// <param name="jsonContent">Chart data</param>
        public static void RunChartDataHttpPost(string url, IList<ChartModel> jsonContent)
        {
            using (var client = new HttpClient())
            {
                // HTTP Post
                var responseTask = client.PostAsync(url, new JsonContent<ChartModel>(jsonContent));

                Console.WriteLine("[Chart Data] Waiting for task...");
                responseTask.Wait();

                if (responseTask.Result.IsSuccessStatusCode)
                {
                    Console.WriteLine("[Chart Data] POST OK.");
                    foreach (var item in jsonContent)
                    {
                        Console.WriteLine(string.Concat("[Chart Data] ", item.Label, ": Value = ", item.Data[0].ToString()));
                    }
                }
                else
                {
                    Console.WriteLine("[Chart Data] POST NOT OK.");
                }
            }
        }

        /// <summary>
        ///     Sending doughnut module data against the Doughnut controller to WEB API. 
        /// </summary>
        /// <param name="url">Doughnut controller URL</param>
        /// <param name="jsonContent">Doughnut data</param>
        public static void DoughnutDataHttpPost(string url, IList<DoughnutModel> jsonContent)
        {
            using (var client = new HttpClient())
            {
                // HTTP Post
                var responseTask = client.PostAsync(url, new JsonContent<DoughnutModel>(jsonContent));

                Console.WriteLine("[Dougnut Data] Waiting for task...");
                responseTask.Wait();

                if (responseTask.Result.IsSuccessStatusCode)
                {
                    Console.WriteLine("[Dougnut Data] POST OK.");

                    foreach (var item in jsonContent)
                    {
                        for (int i = 0; i < item.Label.Count; i++)
                        {
                            Console.WriteLine(string.Concat("[Dougnut Data] ", item.Label[i], ": Value = ", item.Data[i]));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("[Dougnut Data] POST NOT OK.");
                }
            }
        }
    }
}
