using Fixed_Income.Api.Model;


namespace Fixed_Income.Api.Interface
{
    public interface IFixedIncomeRateService
    {
        FixedIncomeRate GetInterestRate();
    }
}