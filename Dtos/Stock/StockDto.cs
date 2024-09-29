using _1st_Project_Api.Dtos.Comment;
using _1st_Project_Api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1st_Project_Api.Dtos.Stock
{
    public class StockDto
    {

        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
       
        public decimal Purchase { get; set; }

        public decimal LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;

        public long MarketCap { get; set; }

        public List<CommentDto> Comments { get; set; }

    }
}
