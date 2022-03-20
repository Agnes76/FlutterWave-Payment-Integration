using FlutterIntegration.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterIntegration.Data
{
    public interface ICustomerRepo
    {
        void AddCustomer(Customer cust);
        void UpdateCustomer(Customer cust);
        Customer GetCustomer(string id);
        IEnumerable<Customer> GetAllCustomers();
        void DeleteCustomer(Customer cust);
        Task SaveChangesAsync();
    }
}
