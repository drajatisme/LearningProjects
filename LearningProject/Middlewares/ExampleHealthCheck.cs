using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LearningProject.Middlewares
{
    public class ExampleHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HealthCheckResult.Degraded("A Degraded result"));
            var healthCheckResultHealthy = true;

            if (healthCheckResultHealthy)
            {
                return Task.FromResult(HealthCheckResult.Healthy("A Healthy result"));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("A Unhealthy result"));

        }
    }
}
