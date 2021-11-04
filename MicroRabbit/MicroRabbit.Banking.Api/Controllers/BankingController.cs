using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService _iAccountService;

        public BankingController(IAccountService iAccountService)
        {
            _iAccountService = iAccountService;
        }
        // GET api/value
        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return Ok(_iAccountService.GetAccounts());
        }

        [HttpPost]
        public IActionResult Post([FromBody] AccountTransfer accountTransfer)
        {
            _iAccountService.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}
