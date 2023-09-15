using Fixed_Income.Api.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Fixed_Income.Api.Controllers
{
    [ApiController]
    public class CalculateFixedIncomeController : Controller
    {
        private readonly IFixedIncomeRateService _incomeRateService;
        private readonly IExpectedIncomeService _expectedIncome;

        public CalculateFixedIncomeController(IFixedIncomeRateService rateService, IExpectedIncomeService expectedIncome)
        {
            _incomeRateService = rateService;
            _expectedIncome = expectedIncome;
        }

        [HttpGet]
        [Route("/fixed-interest-rate")]
        public object Get()
        {
            return Json(_incomeRateService.GetInterestRate());
        }

        [HttpPost]
        [Route("/fixed-income")]
        public object FixedIncomeCalculate([FromQuery] string value, [FromQuery] string months)
        {
            int monthsNumber;
            decimal valueStart;
            
            if (!int.TryParse(months, out monthsNumber) || monthsNumber < 0)
            return BadRequest("O valor do campo mês deve ser um número e maior que 0"); 

            if(!decimal.TryParse(value, out valueStart) || valueStart < 0)
            return BadRequest("O valor do campo valor aplicado deve ser um valor monetário positivo");

            try
            {
                var incomeCalculate = _expectedIncome.GetExpectedIncome(valueStart, monthsNumber);
                return Ok(incomeCalculate);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar realizar o calculo. Msg:{ex.Message}");
            }


        }

    }
}