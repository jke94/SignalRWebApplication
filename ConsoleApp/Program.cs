using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ConsoleApp
{
    public class ChartModel
    {
        public List<int> Data { get; set; }
        public string Label { get; set; }
        public string BackgroundColor { get; set; }
    }
    public class JsonContent : StringContent
    {
        private List<ChartModel> data;

        public JsonContent(List<ChartModel> data)
             : base(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")
        {
            this.data = data;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                var r = new Random();
                var data = new List<ChartModel>()
                {
                    new ChartModel { Data = new List<int> { r.Next(1, 100) }, Label = "Data1", BackgroundColor = string.Format("#{0:X6}", r.Next(0x1000000)) },
                    new ChartModel { Data = new List<int> { r.Next(1, 100) }, Label = "Data2", BackgroundColor = string.Format("#{0:X6}", r.Next(0x1000000)) },
                    new ChartModel { Data = new List<int> { r.Next(1, 100) }, Label = "Data3", BackgroundColor = string.Format("#{0:X6}", r.Next(0x1000000)) },
                    new ChartModel { Data = new List<int> { r.Next(1, 100) }, Label = "Data4", BackgroundColor = string.Format("#{0:X6}", r.Next(0x1000000)) },
                    new ChartModel { Data = new List<int> { r.Next(1, 100) }, Label = "Data5", BackgroundColor = string.Format("#{0:X6}", r.Next(0x1000000)) },
                    new ChartModel { Data = new List<int> { r.Next(1, 100) }, Label = "Data6", BackgroundColor = string.Format("#{0:X6}", r.Next(0x1000000)) },
                };

                // HTTP Post
                var responseTask = client.PostAsync("http://localhost:5000/api/Chart", new JsonContent(data));

                Console.WriteLine("Waiting for task...");
                responseTask.Wait();

                if(responseTask.Result.IsSuccessStatusCode)
                {
                    Console.WriteLine("POST OK.");
                    foreach(var item in data)
                    {
                        Console.WriteLine(string.Concat(item.Label, ": Value = ", item.Data[0].ToString()));
                    }
                }
                else
                {
                    Console.WriteLine("POST NOT OK.");
                }
            }
        }
    }
}
