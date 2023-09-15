using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fixed_Income.Api.Interface;
using Fixed_Income.Api.Model;

namespace Fixed_Income.Api.Service
{
    public class ExpectedIncomeService : IExpectedIncomeService
    {


        public  ExpectedIncome GetExpectedIncome(decimal initialValue, int numberOfMonth)
        {
            ExpectedIncome expectedIncome = new ExpectedIncome(initialValue, numberOfMonth);

            CalulateIncome(expectedIncome, 1);
            expectedIncome.FinalValue = Math.Round(expectedIncome.FinalValue - (expectedIncome.FinalValue * expectedIncome.TaxApplied),2);


            expectedIncome.InitialValue = initialValue;

            return expectedIncome;
        }

        private  ExpectedIncome CalulateIncome(ExpectedIncome income, int monthNumber)
        {
            income.FinalValue = income.InitialValue * (1 + (income.Cdi * income.Tb));

            if (income.NumberOfMonths > monthNumber)
            {
                 income.InitialValue = income.FinalValue;
                 CalulateIncome(income, monthNumber+=1);
            }
          
             return income;
            

        }

    }
}