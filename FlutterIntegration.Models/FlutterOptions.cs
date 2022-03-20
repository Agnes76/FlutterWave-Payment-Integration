using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterIntegration.Models
{
    public class FlutterOptions
    {
        public string BaseUrl { get; set; }
        public string PaymentLink { get; set; }
        public string Token { get; set; }
        public string PaymentOptions { get; set; }
    }
}
