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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Required]
        [StringLength(20,MinimumLength = 1)]
        [Display(Name= "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [StringLength(140,MinimumLength = 1)]
        [Display(Name = "Product Intro")]
        public string ProductIntro { get; set; }

        [Required]
        [StringLength(1000,MinimumLength = 1)]
        [Display(Name = "Product Details")]
        public string ProductDetails { get; set; }

        [Required]
        [Display(Name = "Product Price")]
        public double Productprice { get; set; }

        public virtual ICollection<Followproduct> Followproduct { get; set; }
}
}