namespace Fixed_Income.Api.Model
{
    public class FixedIncomeRate
    {
        public string? Cdi { get; private set; }
        public string? Tb { get; private set; }

        public FixedIncomeRate()
        {
            Cdi="108%";
            Tb ="0,9%";
        }
    }
}