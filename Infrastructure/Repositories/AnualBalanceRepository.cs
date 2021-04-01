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
    public class AnualBalanceRepository : IAnualBalanceRepository
    {
        private readonly DataContext _context;
        private readonly ILoggerFactory _loggerFactory;

        public AnualBalanceRepository(DataContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _loggerFactory = loggerFactory;
        }

        public async Task<AnualBalance> AddAsync(AnualBalance entity)
        {
            try
            {
                await _context.AnualBalances.AddAsync(entity);
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

        public async Task<List<AnualBalance>> GetAllAsync()
        {
            return await _context.AnualBalances.ToListAsync();
        }

        public async Task<AnualBalance> GetByIdAsync(int entityId)
        {
            return await _context.AnualBalances.Where(c => c.Id == entityId).FirstOrDefaultAsync();
        }

        public async Task<AnualBalance> UpdateAsync(AnualBalance entity)
        {
            throw new NotImplementedException();
        }

        public async Task<AnualBalance> CalculateResult(AnualBalance entity)
        {
            try
            {
                if (entity == null) return null;

                _context.Entry(entity).State = EntityState.Modified;

                double total = 0;

                entity.Balances.ForEach(b => total += b.Result);

                entity.Result = total;
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

    }
}
