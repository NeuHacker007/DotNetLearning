### Notes
---
1. To use the apiversioning we should add 
    services.AddApiVersioning();in the Startup.cs
    ```C#
    services.AddApiVersioning();
    ```
    - however, this will break the existing API accessing because if we didn't append the query string api-version=1.0.0, it will throw error. The reason is because the AddApiVersioning() will automatically scan the available controller and identify their version. If only 1 version available, then it will tag the controller with version 1.0.0. To avoid this error, we need to add options while calling AddApiVersioning() like below 
    ```C#
    // Updating the middleware to use the versioning
            services.AddApiVersioning(opt => {
                opt.AssumeDefaultVersionWhenUnspecified = true; 
            });
    ```