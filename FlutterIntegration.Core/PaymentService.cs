using FlutterIntegration.Data;
using FlutterIntegration.Logic;
using FlutterIntegration.Models.Domain;
using FlutterIntegration.Models.FlutterModel;
using FlutterIntegration.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterIntegration.Core
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepo _payRepo;
        private readonly FlutterClient _client;
        private readonly ICustomerRepo _customerRepo;
        public PaymentService(IPaymentRepo payRepo, ICustomerRepo customerRepo, FlutterClient client)
        {
            _payRepo = payRepo;
            _client = client;
            _customerRepo = customerRepo;
        }

        public async Task<string> InitializePayment(FlutterViewModel model, Customer customer, Transaction transaction)
        {
            var response = "";
            try
            {
                var newCustomer = new Customer()
                {
                    Name = customer.Name,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                };
                
                var flutterCustomer = new FlutterwaveCustomerDTO()
                {
                    Name = customer.Name,
                    Email = customer.Email,
                };

                Transaction newTransaction = new Transaction()
                {
                    Id = transaction.Id,
                    Amount = transaction.Amount,
                    TransactionReference = Guid.NewGuid().ToString(),
                    Customer = newCustomer
                };

                var redirectUrl = await _client.InitiatePaymentAsync(new FlutterRequest
                {
                    amount = model.Amount,
                    customer = flutterCustomer,
                    currency = "NGN",
                    tx_ref = newTransaction.TransactionReference,
                    redirect_url = "http://localhost:23235/payment/verify/" 

                });
                if (redirectUrl != null)
                {
                    _payRepo.AddPayment(newTransaction);
                    _customerRepo.AddCustomer(newCustomer);
                    await _payRepo.SaveChangesAsync();

                }
                
                response = redirectUrl;
            }
            catch (Exception e)
            {
                 
            }
           return response;
        }

        public IEnumerable<Transaction> GetAllPayments()
        {
            var trans = _payRepo.GetAllPayment();
           return trans;
        }

        public async Task<bool> VerifyPayment(string transactionRef = null)
        {
            var response = await _client.VerifyPaymentAsync(transactionRef);
            if (response.Data.status == "success")
            {
                var trans = _payRepo.GetPayment(transactionRef);
                if (trans != null)
                {
                    trans.Status = true;
                    _payRepo.UpdatePayment(trans);
                    await _payRepo.SaveChangesAsync();
                }
                return true;
            }
            return false;
        }
    }
}