using Model.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface ICommonRepository<I,S> where I : ICommonEntity where S : ICommonEntity
    {
        #region Incomes 
        Task<I> AddIncomeAsync(I entity);
        Task<I> GetIncomesAsync();
        Task<List<I>> GetIncomeByIdAsync(int entityId);
        Task<I> UpdateIncomeAsync();
        Task<I> DeleteIncomeAsync(int entityId);
        #endregion

        #region Spendings
        Task<S> AddSpendingAsync(S entity);
        Task<List<S>> GetSpendingsAsync();      
        Task<S> GetSpendingByIdAsync(int entityId);
        Task<S> UpdateSpendingAsync();
        Task<S> DeleteSpendingAsync(int entityId);
        #endregion
    }
}
