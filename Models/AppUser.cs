using Microsoft.AspNetCore.Identity;

namespace _1st_Project_Api.Models
{
    public class AppUser : IdentityUser
    {
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    
        
    }
}
