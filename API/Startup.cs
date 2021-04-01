using API.ConfigValues;
using API.Extensions;
using API.Middleware;
using Infrastructure.Context;
using Infrastructure.Contexts.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Services
            services.AddControllers();

            //Context and Database
            services.AddDbContext<DataContext>(options => options.UseSqlServer(_configuration.GetConnectionString(Constants.DefaultConnection)));
            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString(Constants.IdentityConnection));
            });

            //Add other services by extion class
            services.AddApplicationServices();

            //Identity
            services.AddIdentityServices(_configuration);

            //Swagger
            services.AddSwaggerDocumentation();

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(Constants.ClientAddress);
                });
            });

            //Validation Scheme
            services.AddAuthentication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == Constants.Development)
            {
                //Swagger
                app.UseSwaggerDocumentation();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            //Need to be changed for deploy
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
