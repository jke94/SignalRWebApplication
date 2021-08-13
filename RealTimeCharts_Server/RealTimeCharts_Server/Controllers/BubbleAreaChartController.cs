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
                    new BubbleAreaCharModel { CoordinateX = r.Next(1, 1000), CoordinateY = r.Next(1, 1000), Radiux = r.Next(10, 50) },
                    new BubbleAreaCharModel { CoordinateX = r.Next(1, 1000), CoordinateY = r.Next(1, 1000), Radiux = r.Next(10, 50) },
                    new BubbleAreaCharModel { CoordinateX = r.Next(1, 1000), CoordinateY = r.Next(1, 1000), Radiux = r.Next(10, 50) },
                    new BubbleAreaCharModel { CoordinateX = r.Next(1, 1000), CoordinateY = r.Next(1, 1000), Radiux = r.Next(10, 50) },
                    new BubbleAreaCharModel { CoordinateX = r.Next(1, 1000), CoordinateY = r.Next(1, 1000), Radiux = r.Next(10, 50) },
                    new BubbleAreaCharModel { CoordinateX = r.Next(1, 1000), CoordinateY = r.Next(1, 1000), Radiux = r.Next(10, 50) }
                };
            


            Task<List<BubbleAreaCharModel>> myTask = Task.Run(async () =>
            {
                // Simulate procesing in the server.
                await Task.Delay(r.Next(1, 2000));
                return data;
            });

            var result = await Task.FromResult(myTask.Result);

            data.ForEach(element => _logger.LogInformation(
                string.Concat("X: ", element.CoordinateX, ", Y: ", element.CoordinateY, ", Radiux: ", element.Radiux)));


            return result;
        }

        [HttpPost]
        public async Task<IActionResult> AddMetric(List<BubbleAreaCharModel> chartModelList)
        {
            await _hub.Clients.All.SendAsync("transferchartdataBubbleAreaChart", chartModelList);

            chartModelList.ForEach(element => _logger.LogInformation(
            string.Concat("X: ", element.CoordinateX, ", Y: ", element.CoordinateY, ", Radiux: ", element.Radiux)));
            return Ok(new { Message = "Request Completed" });
        }
    }
}
