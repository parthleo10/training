using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyFollow.DAL;
using MyFollow.Models;

namespace MyFollow.Controllers
{
    /// <summary>
    /// Product Api                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/ProductApi")]
    public class ProductApiController : ApiController
    {
        private IdentityDb db = new IdentityDb();
        private UserManager<ApplicationUser> manager;

        public ProductApiController()
        {
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        // GET: api/ProductApi
        /// <summary>
        /// Gets all products created by specific owner.
        /// </summary>
        [Route("")]
        public IEnumerable<Product> GetAllProducts()
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());
            return db.Products.ToList().Where(p => p.User.Id == currentUser.Id);
        }

        // GET: api/ProductApi/5
        /// <summary>
        /// Looks up some products by ID.
        /// </summary>
        /// <param name="id">The ID of product.</param>
        [Route("{id:int}")]
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        
        // GET: api/ProductApi/5
        ///<summary>
        ///GET Product Details by ID
        ///</summary>
        [Route("{id:int}/details")]
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProductDetails(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/ProductApi/5
        ///<summary>
        ///UPDATE Product by ID
        ///</summary>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/ProductApi
        ///<summary>
        ///CREATE Product
        ///</summary>
        [ResponseType(typeof(Product))]
        [AllowAnonymous]
        [Route("Create")]
        public IHttpActionResult PostProduct(Product product)
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             = currentUser;
            db.Products.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {controller= "ProductApi" , id = product.ProductId }, product);
        }
        
        // DELETE: api/ProductApi/5
        ///<summary>
        ///Delete Product by ID
        ///</summary>
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductId == id) > 0;
        }
    }
}