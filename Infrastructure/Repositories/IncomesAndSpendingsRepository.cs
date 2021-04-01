using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model.Entities;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class IncomesAndSpendingsRepository : ICommonRepository<Income, Spending>
    {
        private readonly DataContext _context;
        private readonly IBalanceRepository _balanceRepository;
        private readonly IAnualBalanceRepository _anualBalanceRepository;
        private readonly ILoggerFactory _loggerFactory;

        public IncomesAndSpendingsRepository(DataContext context, IBalanceRepository balanceRepository, IAnualBalanceRepository anualBalanceRepository, ILoggerFactory loggerFactory)
        {
            _context = context;
            _balanceRepository = balanceRepository;
            _anualBalanceRepository = anualBalanceRepository;
            _loggerFactory = loggerFactory;
        }

       
        public async Task<Income> AddIncomeAsync(Income entity)
        {
            try
            {
                await _context.Incomes.AddAsync(entity);
                await _context.SaveChangesAsync();

                await CalculateBalanceAndAnualBalanceResults(entity);

                if (entity != null) return entity;

                return null;
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger<DataContext>();
                logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<Spending> AddSpendingAsync(Spending entity)
        {
            try
            {
                await _context.Spendings.AddAsync(entity);
                await _context.SaveChangesAsync();

                await CalculateBalanceAndAnualBalanceResults(entity);

                if (entity != null) return entity;

                return null;
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger<DataContext>();
                logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<Income> DeleteIncomeAsync(Income entity)
        {
            try
            {
                _context.Incomes.Remove(entity);
                await _context.SaveChangesAsync();

                await CalculateBalanceAndAnualBalanceResults(entity);

                if (entity != null) return entity;

                return null;
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger<DataContext>();
                logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<Spending> DeleteSpendingAsync(Spending entity)
        {
            try
            {
                _context.Spendings.Remove(entity);
                await _context.SaveChangesAsync();

                await CalculateBalanceAndAnualBalanceResults(entity);

                if (entity != null) return entity;

                return null;
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger<DataContext>();
                logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<Income> GetIncomeByIdAsync(int entityId)
        {
            return await _context.Incomes.Where(i => i.Id == entityId).FirstOrDefaultAsync();
        }

        public async Task<List<Income>> GetIncomesAsync()
        {
            return await _context.Incomes.ToListAsync();
        }

        public async Task<Spending> GetSpendingByIdAsync(int entityId)
        {
            return await _context.Spendings.Where(s => s.Id == entityId).FirstOrDefaultAsync();
        }

        public async Task<List<Spending>> GetSpendingsAsync()
        {
            return await _context.Spendings.ToListAsync();
        }

        public async Task<Income> UpdateIncomeAsync(Income entity, bool amountUpdated)
        {
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                if(amountUpdated)
                   await CalculateBalanceAndAnualBalanceResults(entity);

                return entity;
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger<DataContext>();
                logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<Spending> UpdateSpendingAsync(Spending entity, bool amountUpdated)
        {
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                if (amountUpdated)
                    await CalculateBalanceAndAnualBalanceResults(entity);

                return entity;
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger<DataContext>();
                logger.LogError(ex.Message);
                return null;
            }
        }

        #region Private Methods
        private async Task<ICommonEntity> CalculateBalanceAndAnualBalanceResults(ICommonEntity entity)
        {
            var balance = await _balanceRepository.GetByIdAsync(entity.BalanceId);

            if (balance == null) return null;

            await _balanceRepository.CalculateResult(balance);

            var anualBalance = await _anualBalanceRepository.GetByIdAsync(balance.AnualBalanceId);

            if (anualBalance == null) return null;

            await _anualBalanceRepository.CalculateResult(anualBalance);

            return entity;
        }
        #endregion
    }
}
