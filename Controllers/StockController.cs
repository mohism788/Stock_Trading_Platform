using _1st_Project_Api.Data;
using _1st_Project_Api.Dtos.Stock;
using _1st_Project_Api.Helpers;
using _1st_Project_Api.Interfaces;
using _1st_Project_Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _1st_Project_Api.Controllers
{

    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStockRepository _stockRepo;
        public StockController(ApplicationDbContext context, IStockRepository stockRepo)

        {
            _stockRepo = stockRepo;
            _context = context;

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery]QueryObject query)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stocks = await _stockRepo.GetAllAsync(query);
                var stockDto = stocks.Select(s => s.ToStockDto()).ToList();

            return Ok(stocks);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var stocks = await _stockRepo.GetByIdAsync(id);

            if (stocks == null)
            {
                return NotFound();

            }
            return Ok(stocks.ToStockDto());
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var stockModel = stockDto.ToStockFromCreateDto();
            await _stockRepo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut] // UPDATE
        [Route("{id:int}")]

        public async Task <IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stockModel = await _stockRepo.UpdateAsync(id, updateDto);

            if (stockModel == null)
            {
                return NotFound();

            }

            return Ok(stockModel.ToStockDto);

        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete ([FromRoute] int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var stockModel = await _stockRepo.DeleteAsync(id);

            if (stockModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
