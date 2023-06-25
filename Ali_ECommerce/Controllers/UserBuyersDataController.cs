using Ali_ECommerce.Models;
using System.Data.Entity;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace Ali_ECommerce.Controllers
{
    public class UserBuyersDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public IEnumerable<UserBuyerDto> ListUserBuyers()
        {
            List<UserBuyer> UserBuyers = db.UserBuyers.ToList();
            List<UserBuyerDto> UserBuyerDtos = new List<UserBuyerDto>();

            UserBuyers.ForEach(ub => UserBuyerDtos.Add(new UserBuyerDto()
            {
                UserBuyerID = ub.UserBuyerID,
                UserBuyerName = ub.UserBuyerName,
                FirstName = ub.FirstName,
                MerchantBusiness = ub.Merchant != null ? ub.Merchant.MerchantBusiness : ""
            }));

            return UserBuyerDtos;
        }

        [HttpGet]
        [ResponseType(typeof(UserBuyer))]
        public IHttpActionResult FindUserBuyer(int id)
        {
            UserBuyer userbuyer = db.UserBuyers.Find(id);
            if (userbuyer == null)
            {
                return NotFound();
            }

            return Ok(userbuyer);
        }

        [HttpPost]
        [ResponseType(typeof(UserBuyer))]
        public IHttpActionResult AddUserBuyer(UserBuyer userbuyer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserBuyers.Add(userbuyer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userbuyer.UserBuyerID }, userbuyer);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateUserBuyer(int id, UserBuyer userbuyer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userbuyer.UserBuyerID)
            {
                return BadRequest();
            }

            db.Entry(userbuyer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserBuyerExists(id))
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
        [ResponseType(typeof(UserBuyer))]
        public IHttpActionResult DeleteUserBuyer(int id)
        {
            UserBuyer userbuyer = db.UserBuyers.Find(id);
            if (userbuyer == null)
            {
                return NotFound();
            }

            db.UserBuyers.Remove(userbuyer);
            db.SaveChanges();

            return Ok(userbuyer);
        }

        private bool UserBuyerExists(int id)
        {
            return db.UserBuyers.Count(e => e.UserBuyerID == id) > 0;
        }
    }
}
