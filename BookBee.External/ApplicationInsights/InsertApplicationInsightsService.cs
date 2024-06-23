using BookBee.Application.External.ApplicationInsights;
using BookBee.Domain.Models.ApplicationInsights;
using Microsoft.Extensions.Configuration;

namespace BookBee.External.ApplicationInsights
{
    public class InsertApplicationInsightsService : IInsertApplicationInsightsService
    {
        private readonly IConfiguration _configuration;
        public InsertApplicationInsightsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool Execute(InsertApplicationInsightsModel metric)
        {
            if (metric == null)
                throw new ArgumentNullException(nameof(metric));

            //TelemetryConfiguration config = new TelemetryConfiguration();
            //config.ConnectionString = _configuration["ApplicationInsightsConnectionString"];

            //var _telemetryClient = new TelemetryClient(config);

            //var properties = new Dictionary<string, string>
            //{
            //    {"Id", metric.Id},
            //    {"Content", metric.Content },
            //    {"Detail", metric.Detail }
            //};

            //_telemetryClient.TrackTrace(metric.Type, SeverityLevel.Information, properties);
            return true;
        }
    }
}
