using System.Threading.Tasks;
using IEP.BusinessLogic.Entities;

namespace IEP.Services.Contracts
{
    public interface IUserService
    {
        Task<bool> Authorize(User user);

        void Create(User user);
    }
}
