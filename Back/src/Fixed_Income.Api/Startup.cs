using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fixed_Income.Api.Interface;
using Fixed_Income.Api.Service;


namespace Fixed_Income.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigurationServices(IServiceCollection services)
        {
            services.AddSingleton<IExpectedIncomeService, ExpectedIncomeService>();
            services.AddSingleton<IFixedIncomeRateService, FixedIncomeRateService>();
            services.AddControllers();
            services.AddCors();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());

            app.MapControllers();
        }
    }
}