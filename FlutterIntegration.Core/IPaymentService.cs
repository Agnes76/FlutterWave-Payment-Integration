using FlutterIntegration.Models.Domain;
using FlutterIntegration.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterIntegration.Core
{
    public interface IPaymentService
    {
        Task<string> InitializePayment(FlutterViewModel model, Customer customer, Transaction transaction);
        IEnumerable<Transaction> GetAllPayments();
        Task<bool> VerifyPayment(string transactionId = null);
    }
}
