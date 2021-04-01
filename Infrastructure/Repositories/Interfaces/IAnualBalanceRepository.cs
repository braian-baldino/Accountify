using Model.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IAnualBalanceRepository : IBaseRepository<AnualBalance>
    {
        Task<AnualBalance> CalculateResult(AnualBalance entity);
    }
}
