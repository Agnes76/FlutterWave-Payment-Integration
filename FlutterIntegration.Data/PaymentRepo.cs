using FlutterIntegration.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterIntegration.Data
{
    public class PaymentRepo : IPaymentRepo
    {
        private readonly ApplicationDbContext _context;
        public PaymentRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void AddPayment(Transaction trans)
        {
            await _context.AddAsync(trans);
            
        }

        public void UpdatePayment(Transaction trans) 
        {
             _context.Transactions.Update(trans);
        }
        public Transaction GetPayment(string transactionReference) 
        {
            return  _context.Transactions.Where(x => x.TransactionReference == transactionReference).FirstOrDefault();
        }
        public IEnumerable<Transaction> GetAllPayment()
        {
            return _context.Transactions.Where(x => x.Status == true).Include(x => x.Customer).ToList();
        }
        public void DeletePayment(Transaction trans)
        {
            _context.Transactions.Remove(trans);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
