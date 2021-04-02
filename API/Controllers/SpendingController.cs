using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Infrastructure.Repositories.Interfaces;
using API.Errors;

namespace API.Controllers
{
    public class SpendingController : BaseApiController
    {
        private readonly ICommonRepository<Income, Spending> _commonRepository;

        public SpendingController(ICommonRepository<Income, Spending> commonRepository)
        {
            _commonRepository = commonRepository;
        }

        // GET: api/Spending
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spending>>> GetSpendings()
        {
            return await _commonRepository.GetSpendingsAsync();
        }

        // GET: api/Spending/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Spending>> GetSpending(int id)
        {
            var Spending = await _commonRepository.GetSpendingByIdAsync(id);

            if (Spending == null) return BadRequest(new ApiResponse(400));

            return Spending;
        }

        // PUT: api/Spending/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpending(int id, Spending Spending)
        {
            if (Spending == null || id != Spending.Id) return BadRequest();          

            if (!_commonRepository.IncomeExists(id)) return NotFound(new ApiResponse(404));

            await _commonRepository.UpdateSpendingAsync(Spending, true);

            return NoContent();
        }

        // POST: api/Spending
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Spending>> PostSpending(Spending Spending)
        {
            if (Spending == null) return BadRequest();

            var result = await _commonRepository.AddSpendingAsync(Spending);

            return CreatedAtAction("GetSpending", new { id = result.Id }, result);
        }

        // DELETE: api/Spending/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Spending>> DeleteSpending(int id)
        {
            var Spending = await _commonRepository.GetSpendingByIdAsync(id);
            if (Spending == null) return NotFound(new ApiResponse(404));

            await _commonRepository.DeleteSpendingAsync(Spending);

            return Spending;
        }
    }
}
