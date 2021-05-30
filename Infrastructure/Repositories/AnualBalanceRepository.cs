using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model.Entities;
using Model.Enums;
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

        private async Task<AnualBalance> CreateAnualBalance(AnualBalance entity)
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

        public async Task<AnualBalance> AddAsync(AnualBalance entity)
        {
            try
            {
                var result = await CreateAnualBalance(entity);

                if(result == null)
                {
                    throw new Exception();
                }

                result = await CreateBalances(entity);

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
            return await _context.AnualBalances
                .Include(a => a.Balances)
                .Include(a => a.Savings)
                .Include(a => a.Vehicles)
                .OrderByDescending(a => a.Year)
                .ToListAsync();
        }

        public async Task<AnualBalance> GetByIdAsync(int entityId)
        {
            return await _context.AnualBalances
                .Include(a => a.Balances)
                .Include(a => a.Savings)
                .Include(a => a.Vehicles)
                .Where(c => c.Id == entityId).FirstOrDefaultAsync();
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

        public async Task<Savings> AddSavingsAsync(Savings entity)
        {
            try
            {
                await _context.Savings.AddAsync(entity);
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

        public async Task<Savings> UpdateSavingsAsync(Savings entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
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

        public bool EntityExists(int id) => _context.AnualBalances.Any(a => a.Id == id);

        public bool AvailableAnualBalance(int year) => !_context.AnualBalances.Any(a => a.Year == year);

        public bool SavingsExists(int savingsId) => _context.Savings.Any(s => s.Id == savingsId);

        private async Task<AnualBalance> CreateBalances(AnualBalance entity)
        {
            try
            {
                var newBalances = new List<Balance>();
                foreach (var monthValue in Enum.GetValues(typeof(EMonth)))
                {
                    newBalances.Add(new Balance() { AnualBalanceId = entity.Id, Month = (EMonth)monthValue, Positive = true });
                }

                await _context.Balances.AddRangeAsync(newBalances);

                _context.Entry(entity).State = EntityState.Modified;
                entity.Balances = newBalances;

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
