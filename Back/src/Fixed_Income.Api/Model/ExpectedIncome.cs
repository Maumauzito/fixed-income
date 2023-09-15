using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fixed_Income.Api.Model
{
    public class ExpectedIncome
    {
        public  decimal Cdi {get; private set;} = 0.9M;
        public decimal Tb {get; private set;} = 1.08M;
        public decimal InitialValue { get; set; }
        public decimal FinalValue { get; set; }
        public int NumberOfMonths { get; set; }
        public decimal TaxApplied { get; set; }

        public ExpectedIncome()
        {
                
        }
        public ExpectedIncome(decimal initial, int months)
        {
            InitialValue = initial;
            NumberOfMonths = months;
            Tax();
        }

        private int NumberOfDays()
        {
            return NumberOfMonths * 30;
        }

        private void Tax()
        {
            switch (NumberOfDays())
            {
                case int d when d >= 0 && d <= 180:
                    TaxApplied = 0.225M;
                    break;
                case int d when d > 180 && d <= 360:
                    TaxApplied = 0.2M;
                    break;
                case int d when d > 360 && d <= 720:
                    TaxApplied = 0.175M;
                    break;
                case > 720:
                    TaxApplied = 0.15M;
                    break;
            }

        }
    }
}