using Model.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IBalanceRepository : IBaseRepository<Balance>
    {
        Task<Balance> CalculateResult(Balance entity);
    }
}
