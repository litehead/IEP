using System.Collections.Generic;
using System.Threading.Tasks;
using IEP.BusinessLogic.Entities;

namespace IEP.Services.Contracts
{
    public interface ILiteratureService
    {
        Task<List<LiteratureItem>> GetLiteratureItems();
    }
}