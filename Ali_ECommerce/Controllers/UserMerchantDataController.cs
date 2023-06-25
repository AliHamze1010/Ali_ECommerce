using Ali_ECommerce.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Linq;
using System.Collections.Generic;

namespace Ali_ECommerce.Controllers
{
    public class UserMerchantDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public IQueryable<Merchant> ListUserMerchants()
        {
            return db.Merchants;
        }

        [HttpGet]
        [ResponseType(typeof(Merchant))]
        public IHttpActionResult FindUserMerchant(int id)
        {
            Merchant merchant = db.Merchants.Find(id);
            if (merchant == null)
            {
                return NotFound();
            }

            return Ok(merchant);
        }

        [HttpPost]
        [ResponseType(typeof(Merchant))]
        public IHttpActionResult AddUserMerchant(Merchant merchant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Merchants.Add(merchant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = merchant.MerchantID }, merchant);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateUserMerchant(int id, Merchant merchant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != merchant.MerchantID)
            {
                return BadRequest();
            }

            db.Entry(merchant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserMerchantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [ResponseType(typeof(Merchant))]
        public IHttpActionResult DeleteUserMerchant(int id)
        {
            Merchant merchant = db.Merchants.Find(id);
            if (merchant == null)
            {
                return NotFound();
            }

            db.Merchants.Remove(merchant);
            db.SaveChanges();

            return Ok(merchant);
        }

        private bool UserMerchantExists(int id)
        {
            return db.Merchants.Count(e => e.MerchantID == id) > 0;
        }

        // GET: api/UserMerchantData/ListUserMerchantDtos
        [HttpGet]
        public IEnumerable<MerchantDto> ListUserMerchantDtos()
        {
            List<Merchant> merchants = db.Merchants.ToList();
            List<MerchantDto> merchantDtos = new List<MerchantDto>();

            merchants.ForEach(m => merchantDtos.Add(new MerchantDto()
            {
                MerchantID = m.MerchantID,
                MerchantName = m.MerchantName,
                MerchantBusiness = m.MerchantBusiness
            }));

            return merchantDtos;
        }
    }
}
