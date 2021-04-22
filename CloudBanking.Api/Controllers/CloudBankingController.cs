using CloudBanking.Core.Entities;
using CloudBanking.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CloudBanking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloudBankingController : ControllerBase
    {
        private readonly IBankingRepository _bankingRepository;
        private readonly IBankingService _bankingService;
        private readonly ICalculator _calculator;
        private readonly AppParameters _appParameters;

        public CloudBankingController(IBankingRepository bankingRepository, IBankingService bankingService, ICalculator calculator, IOptions<AppParameters> opAppParameters)
        {
            _bankingRepository = bankingRepository;
            _bankingService = bankingService;
            _calculator = calculator;
            _appParameters = opAppParameters.Value;
        }

        [HttpGet("v1/simulate")]
        public async Task<IActionResult> Simulate([FromBody] Info info)
        {

            try
            {
                var result = await _bankingService.SimulateLoan(_calculator, info, _appParameters);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpPost("v1/save")]
        public async Task<IActionResult> Save([FromBody] Info info)
        {
            try
            {
                var result = await _bankingService.SimulateLoan(_calculator, info, _appParameters);

                Loan loan = await _bankingRepository.SaveLoan(result);

                return StatusCode(StatusCodes.Status200OK, loan);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }


        }


    }
}
