using FlutterIntegration.Core;
using FlutterIntegration.Data;
using FlutterIntegration.Logic;
using FlutterIntegration.Models.Domain;
using FlutterIntegration.Models.FlutterModel;
using FlutterIntegration.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FlutterIntegration.Controllers
{
    public class PaymentController : Controller
    {
        //private readonly FlutterClient _client;
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(FlutterViewModel model, Customer customer, Transaction transaction)
        {
            
            var trans = await _service.InitializePayment(model, customer, transaction);

            if (trans!=null)
            {
                return Redirect(trans);
                //return View(trans);
            }
           return View("error");
            ViewData["error"] = "Transaction not Successful";
        }

        public IActionResult GetPayments()
        {
           var transactions = _service.GetAllPayments();
            ViewData["transactions"] = transactions;
            return View();
        }

        public async Task<IActionResult> Verify(string tx_ref) 
        {
            await _service.VerifyPayment(tx_ref);
            return RedirectToAction("GetPayments");
        }
    }
}
