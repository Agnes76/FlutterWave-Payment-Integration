using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterIntegration.Models.Domain
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string TransactionReference { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}