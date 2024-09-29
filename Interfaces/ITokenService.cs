using _1st_Project_Api.Models;

namespace _1st_Project_Api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken (AppUser user);
    }
}
