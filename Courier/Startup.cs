using Courier.Application.Common.Interfaces;
using Courier.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Courier;

public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add controllers (API)
            services.AddControllers();

            // Add Entity Framework Core (replace with your DbContext and connection string)
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,            // Number of retry attempts (default: 6)
                            maxRetryDelay: TimeSpan.FromSeconds(30), // Max delay between retries
                            errorNumbersToAdd: null      // SQL error numbers to consider transient (null = default list)
                        );
                    }
                ));
            // Add Authentication
            // services.AddAuthentication(options => { /* configure */ });

            // Add Authorization
            // services.AddAuthorization(options => { /* configure */ });

            // Add Swagger/OpenAPI
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            // Add CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            // Add Logging
            services.AddLogging();

            // Add HttpClient
            services.AddHttpClient();

            // Add MediatR
            // Register MediatR and scan the current assembly for handlers
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly));
            
            // Add custom services
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            
            // services.AddSingleton<>();
            // services.AddTransient<>();

            // Add Options/Configuration
            // services.Configure<MyOptions>(Configuration.GetSection("MyOptions"));
            
            // Add Health Checks
            services.AddHealthChecks();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Routing
            app.UseRouting();

            // CORS
            app.UseCors("AllowAll");

            // Authentication/Authorization
            // app.UseAuthentication();
            // app.UseAuthorization();
            
            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            // Endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }