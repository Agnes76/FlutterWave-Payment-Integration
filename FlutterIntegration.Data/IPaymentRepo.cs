using FlutterIntegration.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterIntegration.Data
{
    public interface IPaymentRepo
    {
        void AddPayment(Transaction trans);
        void UpdatePayment(Transaction trans);
        Transaction GetPayment(string transactionReference);
        IEnumerable<Transaction> GetAllPayment();
        void DeletePayment(Transaction trans);
        Task SaveChangesAsync();
    }
}
