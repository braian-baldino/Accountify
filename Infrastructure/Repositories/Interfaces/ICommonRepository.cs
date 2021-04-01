using Model.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface ICommonRepository<I,S> where I : ICommonEntity where S : ICommonEntity
    {
        #region Incomes 
        Task<I> AddIncomeAsync(I entity);
        Task<List<I>> GetIncomesAsync();
        Task<I> GetIncomeByIdAsync(int entityId);
        Task<I> UpdateIncomeAsync(I entity, bool amountUpdated);
        Task<I> DeleteIncomeAsync(I entity);
        #endregion

        #region Spendings
        Task<S> AddSpendingAsync(S entity);
        Task<List<S>> GetSpendingsAsync();      
        Task<S> GetSpendingByIdAsync(int entityId);
        Task<S> UpdateSpendingAsync(S entity, bool amountUpdated);
        Task<S> DeleteSpendingAsync(S entity);
        #endregion
    }
}
