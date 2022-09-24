using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Spikes.Host.Healthchecks
{
    public class SampleHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, 
            CancellationToken cancellationToken = default)
        {
            var isHealthy = true;

            // ...

            if (isHealthy)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy(
                        "A healthy result."));
            }
            Dictionary<string, object> properties = 
                new Dictionary<string, object>();

            properties.Add("KeyA", "KeyB");
            properties.Add("KeyB", Guid.NewGuid());

            var x = new HealthCheckResult();


            return Task.FromResult(
                new HealthCheckResult(
                    context.Registration.FailureStatus,
                    "An unhealthy result.",
                    new NotImplementedException(),
                    properties
                    ));
        }
    }
}
