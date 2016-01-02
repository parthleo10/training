using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace MyFollow.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public virtual Owner Owner { get; set; }

        public virtual EndUser EndUser { get; set; }

        public virtual Invitation Invitation { get; set; }

        [Display(Name = "Owner Name")]
        public string OwnerName { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class Invitation
    {
        
        public int Id { get; set; }

        [Required]
        [Display(Name = "Owner Name")]
        public string InviteOwnerName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        
    }

    public class Owner
    {
        
        public int Id { get; set; }

        [Required]
        [Display(Name = "Owner Name")]
        public string OwnerName { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Joining")]
        public DateTime? DateOfJoining { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Founded In")]
        public string FoundedIn { get; set; }
        
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

        [DataType(DataType.Url)]
        [Display(Name = "Website Url")]
        public string WebsiteUrl { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Twitter Handler")]
        public string TwitterHandler { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Facebook Page Url")]
        public string FacebookPageUrl { get; set; }

    }

    public class EndUser
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string EndUserName { get; set; }

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

        public virtual ICollection<Followproduct> Followroduct { get; set; }


    }

   
}