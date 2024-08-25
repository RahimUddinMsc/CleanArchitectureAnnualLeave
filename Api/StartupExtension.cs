using Api.Middleware;
using Application;
using Application.Contracts.Database;
using Persistence;

namespace Api
{
    public static class StartupExtension
    {

        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceService(builder.Configuration);
            builder.Services.AddInfrastructureService();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials            
            }

            app.UseHttpsRedirection();

            app.UseCustomExceptionHandler();

            app.UseAuthorization();

            app.MapControllers();

            app.MapHub<NotificationHub>("/NotificationHub");

            return app;
        }
    }
}
