using Fixed_Income.Api.Interface;
using Fixed_Income.Api.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fixed_Income.Tests
{
    public class TestStartup 
    {

        public IServiceProvider ServiceProvider { get; set; }
        public TestStartup() : base()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddEnvironmentVariables()
                .Build();

            IServiceCollection services = new ServiceCollection()
                .AddSingleton<IConfiguration>(config)
                .AddSingleton<IExpectedIncomeService, ExpectedIncomeService>();
            ServiceProvider = services.BuildServiceProvider();

        }

    }
}
