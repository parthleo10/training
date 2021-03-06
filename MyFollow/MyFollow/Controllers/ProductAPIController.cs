﻿using System;
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
using MyFollow.DAL.IdentityMigrations;
using MyFollow.Models;

namespace MyFollow.Controllers
{
    /// <summary>
    /// Product Api                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
    /// </summary>
    [Authorize]
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
        public IHttpActionResult GetAllProducts()
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());

            var products = db.Products.Where(p => p.UserId == currentUser.Id).ToList();

            return Ok(products) ;
        }

        // GET: api/ProductApi/5
        /// <summary>
        /// Looks up some products by ID.
        /// </summary>
        /// <param name="id">The ID of product.</param>
        [Route("{id:int}")]
        [ResponseType(typeof(Product))]
        [HttpGet]
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
        [Route("{id:int}/Details")]
        [ResponseType(typeof(Product))]
        [HttpGet]
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
        [Route("{id:int}/Update")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            product.UserId = currentUser.Id;
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
        [Route("Create")]
        public IHttpActionResult PostProduct(Product product)
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            product.UserId = currentUser.Id;
            db.Products.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { controller = "ProductApi", id = product.ProductId }, new Product { ProductId = product.ProductId, ProductName = product.ProductName, ProductDetails = product.ProductDetails, ProductPrice = product.ProductPrice });
        }
        
        // DELETE: api/ProductApi/5
        ///<summary>
        ///Delete Product by ID
        ///</summary>
        [ResponseType(typeof(Product))]
        [Route("{id:int}/Delete")]
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