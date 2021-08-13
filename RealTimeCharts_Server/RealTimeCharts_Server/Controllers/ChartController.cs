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
        public ChartController( IHubContext<ChartHub> hub, 
                                ILogger<ChartController> logger
            )
        {
            _logger = logger;
            _hub = hub;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChartModel>>> Get()
        {
            var r = new Random();
            var data = new List<ChartModel>()
                {
                    new ChartModel { Data = new List<int> { r.Next(1, 100) }, Label = "Data1" },
                    new ChartModel { Data = new List<int> { r.Next(1, 100) }, Label = "Data2" },
                    new ChartModel { Data = new List<int> { r.Next(1, 100) }, Label = "Data3" },
                    new ChartModel { Data = new List<int> { r.Next(1, 100) }, Label = "Data4" },
                    new ChartModel { Data = new List<int> { r.Next(1, 100) }, Label = "Data5" },
                    new ChartModel { Data = new List<int> { r.Next(1, 100) }, Label = "Data6" },
                    new ChartModel { Data = new List<int> { r.Next(1, 100) }, Label = "Data7" }
                };

            Task<List<ChartModel>> myTask = Task.Run(async () => 
            {
                // Simulate procesing in the server.
                await Task.Delay(r.Next(1, 2000));
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
