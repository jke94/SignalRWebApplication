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
                    Data = new List<int>(){ r.Next(1, 100), r.Next(1, 100), r.Next(1, 100)},
                    Label = "Data A",
                    BackgroundColor= string.Format("#{0:X6}", r.Next(0x1000000))
                },
                new BubbleAreaCharModel
                {
                    Data = new List<int>(){ r.Next(1, 100), r.Next(1, 100), r.Next(1, 100)},
                    Label = "Data B",
                    BackgroundColor= string.Format("#{0:X6}", r.Next(0x1000000))
                },
                new BubbleAreaCharModel
                {
                    Data = new List<int>(){ r.Next(1, 100), r.Next(1, 100), r.Next(1, 100)},
                    Label = "Data C",
                    BackgroundColor=string.Format("#{0:X6}", r.Next(0x1000000))
                },
                new BubbleAreaCharModel
                {
                    Data = new List<int>(){ r.Next(1, 100), r.Next(1, 100), r.Next(1, 100)},
                    Label = "Data D",
                    BackgroundColor=string.Format("#{0:X6}", r.Next(0x1000000))
                },
                new BubbleAreaCharModel
                {
                    Data = new List<int>(){ r.Next(1, 100), r.Next(1, 100), r.Next(1, 100)},
                    Label = "Data E",
                    BackgroundColor=string.Format("#{0:X6}", r.Next(0x1000000))
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
