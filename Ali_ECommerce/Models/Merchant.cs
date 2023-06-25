using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ali_ECommerce.Models
{
    public class Merchant
    {
        public int MerchantID { get; set; }
        public string MerchantName { get; set; }
        public string MerchantBusiness { get; set; }
    }

    public class MerchantDto
    {
        public int MerchantID { get; set; }
        public string MerchantName { get; set; }
        public string MerchantBusiness { get; set; }
    }
}
