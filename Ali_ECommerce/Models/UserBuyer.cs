using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ali_ECommerce.Models
{
    public class UserBuyer
    {
        [Key]
        public int UserBuyerID { get; set; }
        public string UserBuyerName { get; set; }
        public string FirstName { get; set; }

        [ForeignKey("Merchant")]
        public int MerchantID { get; set; }
        public virtual Merchant Merchant { get; set; }
    }

    public class UserBuyerDto
    {
        public int UserBuyerID { get; set; }
        public string UserBuyerName { get; set; }
        public string FirstName { get; set; }
        public string MerchantBusiness { get; set; }
    }
}
