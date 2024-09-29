using _1st_Project_Api.Models;

namespace _1st_Project_Api.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Stock>> GetUserPortfolio(AppUser user);
        Task<Portfolio> CreateAsync (Portfolio portfolio);
        Task<Portfolio> DeletePortfolio (AppUser appUser, string symbol);
    }
}
