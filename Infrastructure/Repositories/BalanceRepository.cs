using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly DataContext _context;
        private readonly ILoggerFactory _loggerFactory;

        public BalanceRepository(DataContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _loggerFactory = loggerFactory;
        }

        public async Task<Balance> AddAsync(Balance entity)
        {
            try
            {
                await _context.Balances.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger<DataContext>();
                logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<List<Balance>> GetAllAsync()
        {
            return await _context.Balances
                .Include(b => b.Incomes)
                .Include(b => b.Spendings)
                .ToListAsync();
        }

        public async Task<Balance> GetByIdAsync(int entityId)
        {
            return await _context.Balances
                .Include(b => b.Incomes)
                .Include(b => b.Spendings)
                .OrderBy(b => b.Month)
                .Where(c => c.Id == entityId)
                .FirstOrDefaultAsync();
        }

        public Task<Balance> UpdateAsync(Balance entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Balance> CalculateResult(Balance entity)
        {
            try
            {
                if (entity == null) return null;

                _context.Entry(entity).State = EntityState.Modified;

                double totalIncomes = 0;
                double totalSpendings = 0;

                entity.Incomes.ForEach(i => totalIncomes += i.Amount);
                entity.Spendings.ForEach(s => totalSpendings += s.Amount);

                entity.Result = totalIncomes - totalSpendings;
                entity.Positive = entity.Result >= 0;

                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger<DataContext>();
                logger.LogError(ex.Message);
                return null;
            }
        }

        public bool EntityExists(int id) => _context.Balances.Any(b => b.Id == id);
    }
}
