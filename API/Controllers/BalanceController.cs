using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Infrastructure.Repositories.Interfaces;
using API.Errors;

namespace API.Controllers
{

    public class BalanceController : BaseApiController
    {
        private readonly IBalanceRepository _balanceRepository;

        public BalanceController(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }

        // GET: api/Balance
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Balance>>> GetBalances()
        {
            return await _balanceRepository.GetAllAsync();
        }

        // GET: api/Balance/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Balance>> GetBalance(int id)
        {
            var balance = await _balanceRepository.GetByIdAsync(id);

            if (balance == null) return NotFound(new ApiResponse(404));

            return balance;
        }

        // PUT: api/Balance/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status405MethodNotAllowed)]
        public async Task<IActionResult> PutBalance(int id, Balance balance)
        {
            return BadRequest(new ApiResponse(405, "Method not implemented"));
        }

        // POST: api/Balance
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Balance>> PostBalance(Balance balance)
        {
            if (balance == null) return BadRequest(new ApiResponse(400));

            var result = await _balanceRepository.AddAsync(balance);

            if (result == null) return BadRequest(new ApiResponse(400));

            return CreatedAtAction("GetBalance", new { id = result.Id }, result);
        }

        // DELETE: api/Balance/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBalance(int id)
        {
            var balance = await _balanceRepository.GetByIdAsync(id);

            if (balance == null) return NotFound(new ApiResponse(404));

            if (balance.Incomes.Any() || balance.Spendings.Any()) return BadRequest(new ApiResponse(400, "The balance has incomes or spendings, It cannot be deleted!"));

            return Ok(balance);
        }
    }
}
