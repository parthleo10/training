using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyFollow.Models
{
    public class Product
{
        public int ProductId { get; set; }
       
        public string ProductName { get; set; }
       
        public string ProductDetails { get; set; }
      
        public double ProductPrice { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }


        
}
}