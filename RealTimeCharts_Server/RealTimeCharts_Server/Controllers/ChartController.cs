namespace RealTimeCharts_Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.Extensions.Logging;
    using RealTimeCharts_Server.HubConfigs;
    using RealTimeCharts_Server.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private IHubContext<ChartHub> _hub;
        private readonly ILogger _logger;

        public ChartController( IHubContext<ChartHub> hub, ILogger<ChartController> logger)
        {
            _logger = logger;
            _hub = hub;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChartModel>>> Get()
        {
            var random = new Random();
            var data = new List<ChartModel>()
            {
                new ChartModel 
                {
                    Label = "Data1",
                    BackgroundColor = string.Format("#{0:X6}", random.Next(0x1000000)),
                    Data = new List<int> { random.Next(1, 100) }
                },
                new ChartModel 
                { 
                    Data = new List<int> { random.Next(1, 100) }, 
                    Label = "Data2", 
                    BackgroundColor = string.Format("#{0:X6}", random.Next(0x1000000))
                },
                new ChartModel 
                { 
                    Data = new List<int> { random.Next(1, 100) }, 
                    Label = "Data3", 
                    BackgroundColor = string.Format("#{0:X6}", random.Next(0x1000000))
                },
                new ChartModel 
                { 
                    Data = new List<int> { random.Next(1, 100) }, 
                    Label = "Data4", 
                    BackgroundColor = string.Format("#{0:X6}", random.Next(0x1000000))
                },
                new ChartModel 
                { 
                    Data = new List<int> { random.Next(1, 100) },
                    Label = "Data5", 
                    BackgroundColor = string.Format("#{0:X6}", random.Next(0x1000000))
                },
                new ChartModel 
                { 
                    Data = new List<int> { random.Next(1, 100) }, 
                    Label = "Data6", 
                    BackgroundColor = string.Format("#{0:X6}", random.Next(0x1000000))
                }     
            };

            Task<List<ChartModel>> myTask = Task.Run(async () => 
            {
                // Simulate procesing in the server.
                await Task.Delay(random.Next(1, 2000));
                return data; 
            });
           
            var result = await Task.FromResult(myTask.Result);
            
            data.ForEach(element => _logger.LogInformation(
                string.Concat(element.Label, ": Value = ", element.Data[0].ToString())));
            
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> AddMetric(List<ChartModel> chartModelList)
        {
            await _hub.Clients.All.SendAsync("transferchartdataChart", chartModelList);

            chartModelList.ForEach(element => _logger.LogInformation(
                string.Concat(element.Label, ": Value = ", element.Data[0].ToString())));
            return Ok(new { Message = "Request Completed" });
        }
    }
}
