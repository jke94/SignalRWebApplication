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
    public class DoughnutController : Controller
    {

        private IHubContext<DoughnutHub> _hub;
        private readonly ILogger _logger;

        public DoughnutController(IHubContext<DoughnutHub> hub, ILogger<DoughnutController> logger)
        {
            _logger = logger;
            _hub = hub;
        }

        [HttpGet]
        public async Task<ActionResult<DoughnutModel>> Get()
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

            Task<DoughnutModel> myTask = Task.Run(async () =>
            {
                // Simulate procesing in the server.
                await Task.Delay(random.Next(1, 2000));
                return doughnutModelA;
            });

            var result = await Task.FromResult(myTask.Result);

            // TODO: SignalR Connection
            for (int i = 0; i < result.Label.Count; i++)
            {
                _logger.LogInformation(string.Concat("[Dougnut Data] ", result.Label[i], ": Value = ", result.Data[i]));
            }

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> AddMetric(List<DoughnutModel> doughnutModelList)
        {
            await _hub.Clients.All.SendAsync("transferchartdataBubbleDoughnutModel", doughnutModelList);
            
            doughnutModelList.ForEach( element =>
            {
                for (int i = 0; i < element.Label.Count; i++)
                {
                    _logger.LogInformation(string.Concat("[Dougnut Data] ", element.Label[i], ": Value = ", element.Data[i]));
                }
            });

            return Ok(new { Message = "Request Completed" });
        }
    }
}
