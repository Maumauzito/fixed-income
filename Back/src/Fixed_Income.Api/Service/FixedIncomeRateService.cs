using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fixed_Income.Api.Interface;
using Fixed_Income.Api.Model;

namespace Fixed_Income.Api.Service
{
    public class FixedIncomeRateService : IFixedIncomeRateService
    {

        public FixedIncomeRate GetInterestRate(){
            return new FixedIncomeRate();

        }
    }
}