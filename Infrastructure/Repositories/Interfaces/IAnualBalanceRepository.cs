using Model.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IAnualBalanceRepository : IBaseRepository<AnualBalance>
    {
        Task<AnualBalance> CalculateResult(AnualBalance entity);
        Task<Savings> AddSavingsAsync(Savings entity);
        Task<Savings> UpdateSavingsAsync(Savings entity);
        bool SavingsExists(int savingsId);
    }
}
