using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser() : base()
        {
            IsAdmin = false;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomeAdress { get; set; }
        public bool IsAdmin { get; set; }
        //public bool IsSalesman { get; set; }
        //Relations 
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
