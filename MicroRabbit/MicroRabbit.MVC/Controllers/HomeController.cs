using MicroRabbit.MVC.Models;
using MicroRabbit.MVC.Models.DTO;
using MicroRabbit.MVC.Services;
using MicroRabbit.Transfer.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroRabbit.MVC.Controllers
{ 
    public class HomeController : Controller
    {
        private readonly ITransferService _iTransferService;

        public HomeController(ITransferService iTransferService)
        {
            _iTransferService = iTransferService;
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        // The presentation only knows the TransferViewModel at this point; declaring model as Transferviewmodel
        public async Task<IActionResult> Transfer(TransferViewModel model)
        {
            // Creating a TransferDto object and initialize with TransferViewModel (model) with data
            // and pass it to Transfer service

            // The idea is as soon as someone post to this view model, we want to map it to the TransferDto
            // then call the local proxy transfer service.
            TransferDto transferDto = new TransferDto()
            {
                // These data are coming from the view model of the presentation layer
                FromAccount = model.FromAccount,
                ToAccount = model.ToAccount,
                TransferAmount = model.TransferAmount
            };

            // wait for the transfer to be completed
            await _iTransferService.Transfer(transferDto);

            // Returning the index of this view back to the caller
            return View("Index");

        }

        [HttpGet]
        // The presentation only knows the TransferViewModel at this point; declaring model as Transferviewmodel
        public async Task<IActionResult> GetTransferLogs(TransferViewModel model)
        {
            // wait for the transfer to be completed
            var response = await _iTransferService.GetTransferLogs();
            var stringValue = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<IEnumerable<TransferLog>>(stringValue);
            var transferLogs = obj as IEnumerable<TransferLog>;
            ViewBag.Message = "Testing Here";
            ViewBag.Data = transferLogs;
            return View("Index");            
        }
    }
}
