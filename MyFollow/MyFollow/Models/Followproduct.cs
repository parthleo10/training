using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFollow.Models
{
    public class Followproduct
    {

        public int FollowproductID { get; set; }
        public int ProductID { get; set; }
        public int StudentID { get; set; }
        public bool Follows { get; set; }

        public virtual Product Product { get; set; }
        public virtual EndUser EndUsers { get; set; }

    }
}