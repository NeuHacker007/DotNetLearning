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
2. To use the MediaType we need add below option to Startup.cs
   ```C#
   services.AddApiVersioning(opt =>
            {
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = ApiVersion.Default;
                // this is going to return all available api versions in response header
                opt.ReportApiVersions = true;

                opt.ApiVersionReader = new MediaTypeApiVersionReader("x-api-version");
            });
   ``` 

3. To use a separate head we need to use
   ```C#
   services.AddApiVersioning(opt =>
            {
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = ApiVersion.Default;
                // this is going to return all available api versions in response header
                opt.ReportApiVersions = true;

                opt.ApiVersionReader = new HeaderApiVersionReader("x-api-version"); //new MediaTypeApiVersionReader("x-api-version");
            });
   ```