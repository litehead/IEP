using IEP.BusinessLogic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEP.Services.Contracts
{
    public interface ISubjectsService
    {
        Task<List<Subject>> GetSubjectsForUser(string userName);

        void AddSubject(Subject subject);

        void AddModule(Module module);

        Task<List<Module>> GetModulesById(int subjectId);

        void AddLecture(Lecture lecture);
    }
}
