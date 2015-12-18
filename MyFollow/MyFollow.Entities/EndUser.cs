using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFollow.Entities
{

    public class EndUser
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Joining")]
        public DateTime? DateOfJoining { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Street 1")]
        public string Street1 { get; set; }

        [Display(Name = "Street 2")]
        public string Street2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Pin { get; set; }

        [Display(Name = "Contact Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string ContactNumber { get; set; }

    }

}
