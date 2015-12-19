using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFollow.Entities
{
    public class Invitation
    {
        [Key]
        public int InvitaionId { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Owner Name")]
        public string OwnerName { get; set; }
        
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

    }
}
