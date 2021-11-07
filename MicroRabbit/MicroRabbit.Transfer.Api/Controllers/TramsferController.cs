using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MicroRabbit.Banking.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _iTransferService;

        // Injecting the inteferface of TransferService into the TransfersController constructor
        public TransferController(ITransferService iTransferService)
        {
            _iTransferService = iTransferService;

        }

        // GET api/transfer
        [HttpGet]
        public ActionResult<IEnumerable <TransferLog>>Get()
        {
            return Ok(_iTransferService.GetTransferLogs());
        }
    }
}
