using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Model.Entities;
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
        private readonly ILoggerFactory _loggerFactory;

        public IncomesAndSpendingsRepository(DataContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _loggerFactory = loggerFactory;
        }

        public Task<Income> AddIncomeAsync(Income entity)
        {
            throw new NotImplementedException();
        }

        public Task<Spending> AddSpendingAsync(Spending entity)
        {
            throw new NotImplementedException();
        }

        public Task<Income> DeleteIncomeAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Spending> DeleteSpendingAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Income>> GetIncomeByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Income> GetIncomesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Spending> GetSpendingByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Spending>> GetSpendingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Income> UpdateIncomeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Spending> UpdateSpendingAsync()
        {
            throw new NotImplementedException();
        }
    }
}
