using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ali_ECommerce.Models
{
    public class UserSeller
    {
        public int UserSellerID { get; set; }
        public string UserSellerName { get; set; }
        public string UserSellerBusiness { get; set; }
    }

    public class UserSellerDto
    {
        public int UserSellerID { get; set; }
        public string UserSellerName { get; set; }
        public string UserSellerBusiness { get; set; }
    }
}
