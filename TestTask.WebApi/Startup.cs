using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using TestTask.Persistence;

namespace TestTask.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get;}

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {                        
            services.AddSwaggerGen();

            services.AddPersistence(Configuration);

            services.AddControllers().AddNewtonsoftJson(
          options => {
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          });


            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthorization();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });            
        }
    }
}
