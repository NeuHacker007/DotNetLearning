using System;

namespace SwaggerDemo
{
    public class WeatherForecast
    {
        /// <summary>
        /// Get or Set the Weather Forecast Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Get or Set the Temperature in C
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Get the Temperature in F
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// Weather summary 
        /// </summary>
        public string Summary { get; set; }
    }
}
