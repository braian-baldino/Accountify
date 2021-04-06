using API.Errors;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    public class AnualBalanceController : BaseApiController
    {
        private readonly IAnualBalanceRepository _anualBalanceRepository;

        public AnualBalanceController(IAnualBalanceRepository anualBalanceRepository)
        {
            _anualBalanceRepository = anualBalanceRepository;
        }

        // GET: api/<AnualBalanceController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AnualBalance>>> GetAll()
        {
            var anualBalances = await _anualBalanceRepository.GetAllAsync();
            return Ok(anualBalances);
        }

        // GET api/<AnualBalanceController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AnualBalance>> GetAnualBalance(int id)
        {
            var anualBalance = await _anualBalanceRepository.GetByIdAsync(id);

            if (anualBalance == null) return NotFound(new ApiResponse(404));

            return anualBalance;
        }

        // POST api/<AnualBalanceController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AnualBalance>> PostAnualBalance(AnualBalance anualBalance)
        {
            if (anualBalance == null) return BadRequest(new ApiResponse(400));

            var result = await _anualBalanceRepository.AddAsync(anualBalance);

            if (result == null) return BadRequest(new ApiResponse(400));

            return CreatedAtAction("GetAnualBalance", new { id = result.Id }, result);
        }

        // POST api/<AnualBalanceController>/add-savings
        [HttpPost]
        [Route("add-savings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AnualBalance>> PostSavings(Savings savings)
        {
            if (savings == null) return BadRequest(new ApiResponse(400));

            var result = await _anualBalanceRepository.AddSavingsAsync(savings);

            if (result == null) return BadRequest(new ApiResponse(400));

            return CreatedAtAction("GetAnualBalance", new { id = result.Id }, result);
        }

        // PUT: api/AnualBalance/update-savings
        [HttpPut]
        [Route("update-savings/{id}")]
        public async Task<IActionResult> PutSavings(int id, Savings savings)
        {
            if (savings == null || id != savings.Id) return BadRequest();

            if (!_anualBalanceRepository.SavingsExists(id)) return NotFound(new ApiResponse(404));

            await _anualBalanceRepository.UpdateSavingsAsync(savings);

            return NoContent();
        }

        // PUT api/<AnualBalanceController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status405MethodNotAllowed)]
        public async Task<IActionResult> UpdateAnualBalance(int id, AnualBalance anualBalance)
        {
            return BadRequest(new ApiResponse(405, "Method not implemented"));
        }

        // DELETE api/<AnualBalanceController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var anualBalance = await _anualBalanceRepository.GetByIdAsync(id);

            if (anualBalance == null) return NotFound(new ApiResponse(404));

            if (anualBalance.Balances.Any()) return BadRequest(new ApiResponse(400, "The Anual Balance has balances, It cannot be deleted!"));

            return Ok(anualBalance);
        }
    }
}
