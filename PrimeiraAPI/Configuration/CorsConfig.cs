namespace PrimeiraAPI.Configuration
{
    public static class CorsConfig
    {
        public static WebApplicationBuilder AddCorsConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Development", builder =>
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

                options.AddPolicy("Production", builder =>
                    builder
                    .WithOrigins("http://localhost:7253")
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .AllowAnyHeader());
            });

            return builder;
        }
    }
}
