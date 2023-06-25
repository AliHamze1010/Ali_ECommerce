using Ali_ECommerce.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Linq;

namespace Ali_ECommerce.Controllers
{
    public class UserSellerDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public IQueryable<UserSeller> ListUserSellers()
        {
            return db.UserSellers;
        }

        [HttpGet]
        [ResponseType(typeof(UserSeller))]
        public IHttpActionResult FindUserSeller(int id)
        {
            UserSeller userSeller = db.UserSellers.Find(id);
            if (userSeller == null)
            {
                return NotFound();
            }

            return Ok(userSeller);
        }

        [HttpPost]
        [ResponseType(typeof(UserSeller))]
        public IHttpActionResult AddUserSeller(UserSeller userSeller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserSellers.Add(userSeller);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userSeller.UserSellerID }, userSeller);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateUserSeller(int id, UserSeller userSeller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userSeller.UserSellerID)
            {
                return BadRequest();
            }

            db.Entry(userSeller).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSellerExists(id))
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
        [ResponseType(typeof(UserSeller))]
        public IHttpActionResult DeleteUserSeller(int id)
        {
            UserSeller userSeller = db.UserSellers.Find(id);
            if (userSeller == null)
            {
                return NotFound();
            }

            db.UserSellers.Remove(userSeller);
            db.SaveChanges();

            return Ok(userSeller);
        }

        private bool UserSellerExists(int id)
        {
            return db.UserSellers.Count(e => e.UserSellerID == id) > 0;
        }
    }
}
