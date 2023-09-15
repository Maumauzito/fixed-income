using Fixed_Income.Api.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Fixed_Income.Tests;

public class FixedIncomeTest1 : IClassFixture<TestStartup> 
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IExpectedIncomeService _expectedIncomeService;

    public FixedIncomeTest1( TestStartup fixture)
    {
        _serviceProvider = fixture.ServiceProvider;
        var scope = _serviceProvider.CreateScope();
        _expectedIncomeService = _serviceProvider.GetService<IExpectedIncomeService>();
    }



    [Fact]
    public void GetExpectedIncome_WhitValidParameters_ResultExpectedValue()
    {
        var initialValue = 50.00M;
        var numberOfMonths = 1;
        var expectedIncome = 76.42M;

        var income = _expectedIncomeService.GetExpectedIncome(initialValue, numberOfMonths);

        Assert.True(income.FinalValue == expectedIncome);
    }

    [Fact]
    public void GetExpectedIncome_WhitValidParameters_ResultTaxApplied1()
    {
        var initialValue = 50.00M;
        var numberOfMonths = 1;
       

        var income = _expectedIncomeService.GetExpectedIncome(initialValue, numberOfMonths);

        Assert.True(income.TaxApplied == 0.225M);
    }

    [Fact]
    public void GetExpectedIncome_WhitValidParameters_ResultTaxApplied2()
    {
        var initialValue = 50.00M;
        var numberOfMonths = 8;

        var income = _expectedIncomeService.GetExpectedIncome(initialValue, numberOfMonths);

        Assert.True(income.TaxApplied == 0.2M);
    }

    [Fact]
    public void GetExpectedIncome_WhitValidParameters_ResultTaxApplied3()
    {
        var initialValue = 50.00M;
        var numberOfMonths = 16;

        var income = _expectedIncomeService.GetExpectedIncome(initialValue, numberOfMonths);

        Assert.True(income.TaxApplied == 0.175M);
    }

    [Fact]
    public void GetExpectedIncome_WhitValidParameters_ResultTaxApplied4()
    {
        var initialValue = 50.00M;
        var numberOfMonths = 25;

        var income = _expectedIncomeService.GetExpectedIncome(initialValue, numberOfMonths);

        Assert.True(income.TaxApplied == 0.15M);
    }
}