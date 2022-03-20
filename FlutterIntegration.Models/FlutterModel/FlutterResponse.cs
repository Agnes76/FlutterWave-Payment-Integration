using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterIntegration.Models.FlutterModel
{
    public class FlutterwaveResponseDTO<T> where T : class
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public class FlutterwaveResponseDataDTO
    {
        public string link { get; set; }
    }

    public class FlutterwaveVerifyResponseDataDTO
    {
        public int id { get; set; }
        public string tx_ref { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public string status { get; set; }
    }

}







