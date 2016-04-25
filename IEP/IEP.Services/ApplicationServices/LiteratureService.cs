using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using IEP.BusinessLogic.Contracts;
using IEP.BusinessLogic.Entities;
using IEP.Services.Contracts;

namespace IEP.Services.ApplicationServices
{
    public class LiteratureService : ILiteratureService
    {
        private readonly IRepository<LiteratureItem> _literatureRepository;

        public LiteratureService(IRepository<LiteratureItem> literatureRepository)
        {
            _literatureRepository = literatureRepository;
        }

        public async Task<List<LiteratureItem>> GetLiteratureItems()
        {
            return await _literatureRepository.GetAll().ToListAsync();
        }
    }
}
