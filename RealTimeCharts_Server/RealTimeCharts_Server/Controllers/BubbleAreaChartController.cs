namespace RealTimeCharts_Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.Extensions.Logging;
    using RealTimeCharts_Server.HubConfigs;
    using RealTimeCharts_Server.Model;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class BubbleAreaChartController : ControllerBase
    {
        private IHubContext<BubbleAreaCharHub> _hub;
        private readonly ILogger _logger;
        public BubbleAreaChartController(IHubContext<BubbleAreaCharHub> hub,
                                ILogger<ChartController> logger
            )
        {
            _logger = logger;
            _hub = hub;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BubbleAreaCharModel>>> Get()
        {
            var r = new Random();
            var data = new List<BubbleAreaCharModel>()
            {
                new BubbleAreaCharModel 
                { 
                    Label = "Data 1", 
                    BackgroundColor = "#5491DA",
                    Data = new List<int>()
                    {
                        r.Next(1, 1000), r.Next(1, 1000), r.Next(10, 50)
                    }
                }
                ,
                new BubbleAreaCharModel 
                { 
                    Label = "Data 2", 
                    BackgroundColor = "#E74C3C",
                    Data = new List<int>()
                    {
                        r.Next(1, 1000), r.Next(1, 1000), r.Next(10, 50)
                    }
                },
                new BubbleAreaCharModel 
                { 
                    Label = "Data 3", 
                    BackgroundColor = "#82E0AA",
                    Data = new List<int>()
                    {
                        r.Next(1, 1000), r.Next(1, 1000), r.Next(10, 50)
                    }
                },
                new BubbleAreaCharModel 
                { 
                    Label = "Data 4", 
                    BackgroundColor = "#A5C7E9",
                    Data = new List<int>()
                    {
                        r.Next(1, 1000), r.Next(1, 1000), r.Next(10, 50)
                    }
                }                
            };

            Task<List<BubbleAreaCharModel>> myTask = Task.Run(async () =>
            {
                // Simulate procesing in the server.
                await Task.Delay(r.Next(1, 2000));
                return data;
            });

            var result = await Task.FromResult(myTask.Result);

            // data.ForEach(element => _logger.LogInformation(
            //     string.Concat("X: ", element., ", Y: ", element.CoordinateY, ", Radiux: ", element.Radiux)));


            return result;
        }

        [HttpPost]
        public async Task<IActionResult> AddMetric(List<BubbleAreaCharModel> chartModelList)
        {
            await _hub.Clients.All.SendAsync("transferchartdataBubbleAreaChart", chartModelList);

            // chartModelList.ForEach(element => _logger.LogInformation(
            // string.Concat("X: ", element.CoordinateX, ", Y: ", element.CoordinateY, ", Radiux: ", element.Radiux)));
            return Ok(new { Message = "Request Completed" });
        }
    }
}
