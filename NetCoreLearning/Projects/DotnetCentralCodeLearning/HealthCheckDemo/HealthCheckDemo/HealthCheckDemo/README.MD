### Difference between HealthCheckResult.Degraded | Healthy | Unhealthy 

Degraded -> the service still available but has performance deterioration. We can use timer to know this. Also, the httpcode returned is 200 ok
Unhealty -> the service is not available so, response http status code is 503 service is not available  