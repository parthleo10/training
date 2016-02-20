using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyFollow.Models
{
    public class FollowProduct
    {
        public int FollowProductId { get; set; }

        public bool IsFollowed { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public int EndUserId { get; set; }

        [ForeignKey("EndUserId")]
        public virtual EndUser EndUser { get; set; }
    }
}