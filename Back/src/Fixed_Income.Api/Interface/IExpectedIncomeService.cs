using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fixed_Income.Api.Model;

namespace Fixed_Income.Api.Interface
{
    public interface IExpectedIncomeService
    {
        ExpectedIncome GetExpectedIncome(decimal initialValue, int numberOfMonth);
    }
}