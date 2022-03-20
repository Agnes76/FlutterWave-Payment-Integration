using FlutterIntegration.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterIntegration.Data
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void AddCustomer(Customer cust)
        {
            await _context.AddAsync(cust);
        }

        public void UpdateCustomer(Customer cust)
        {
            _context.Customers.Update(cust);
        }
        public Customer GetCustomer(string id)
        {
            return _context.Customers.Where(x => x.Id == id).FirstOrDefault();
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }
        public void DeleteCustomer(Customer cust)
        {
            _context.Customers.Remove(cust);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
