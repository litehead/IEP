using System.Threading.Tasks;
using IEP.BusinessLogic.Entities;

namespace IEP.Services.Contracts
{
    public interface IUserService
    {
        Task<User> Authorize(User user);

        void Create(User user);

        Task<User> GetByName(string name);
    }
}
