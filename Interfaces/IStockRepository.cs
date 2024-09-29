using _1st_Project_Api.Dtos.Stock;
using _1st_Project_Api.Helpers;
using _1st_Project_Api.Models;

namespace _1st_Project_Api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock?> GetByIdAsync(int id); // FirstOrDefault can not be null

        Task<Stock?> GetBySymbolAsync(string symbol);
        Task<Stock> CreateAsync(Stock stockModel);

        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);

        Task<Stock?> DeleteAsync(int id);

        Task<bool> StockExist(int id);


     }
}
