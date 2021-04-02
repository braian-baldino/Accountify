using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Infrastructure.Repositories.Interfaces;
using API.Errors;

namespace API.Controllers
{
    public class IncomeController : BaseApiController
    {
        private readonly ICommonRepository<Income,Spending> _commonRepository;

        public IncomeController(ICommonRepository<Income, Spending> commonRepository)
        {
            _commonRepository = commonRepository;
        }

        // GET: api/Income
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Income>>> GetIncomes()
        {
            return await _commonRepository.GetIncomesAsync();
        }

        // GET: api/Income/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Income>> GetIncome(int id)
        {
            var income = await _commonRepository.GetIncomeByIdAsync(id);

            if (income == null) return BadRequest(new ApiResponse(400));

            return income;
        }

        // PUT: api/Income/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncome(int id, Income income)
        {
            if (income == null || id != income.Id) return BadRequest();

            var currentIncome = await _commonRepository.GetIncomeByIdAsync(id);

            if (currentIncome == null) return NotFound(new ApiResponse(404));

            var shouldReCalculate = income.Amount != currentIncome.Amount;

            await _commonRepository.UpdateIncomeAsync(income, shouldReCalculate);

            return NoContent();
        }

        // POST: api/Income
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Income>> PostIncome(Income income)
        {
            if (income == null) return BadRequest();

            var result = await _commonRepository.AddIncomeAsync(income);

            return CreatedAtAction("GetIncome", new { id = result.Id }, result);
        }

        // DELETE: api/Income/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Income>> DeleteIncome(int id)
        {
            var income = await _commonRepository.GetIncomeByIdAsync(id);
            if (income == null) return NotFound(new ApiResponse(404));

            await _commonRepository.DeleteIncomeAsync(income);

            return income;
        }
    }
}
