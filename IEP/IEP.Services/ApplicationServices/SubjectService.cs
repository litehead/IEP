using IEP.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEP.BusinessLogic.Entities;
using IEP.BusinessLogic.Contracts;
using IEP.BusinessLogic.Enums;
using System.Data.Entity;

namespace IEP.Services.ApplicationServices
{
    public class SubjectService : ISubjectsService
    {
        private readonly IRepository<Subject> _subjectRepository;
        private readonly IRepository<Module> _moduleRepository;
        private readonly IRepository<Lecture> _lectureRepository;

        public SubjectService(IRepository<Subject> subjectRepository, IRepository<Module> moduleRepository, IRepository<Lecture> lectureRepository)
        {
            _subjectRepository = subjectRepository;
            _moduleRepository = moduleRepository;
            _lectureRepository = lectureRepository;
        }

        public void AddSubject(Subject subject)
        {
            _subjectRepository.Add(subject);
        }

        public void AddModule(Module module)
        {
            _moduleRepository.Add(module);
        }

        public async Task<List<Subject>> GetSubjectsForUser(string userName)
        {
            return await _subjectRepository.GetAll(x => x.UserSubjects.Any(us => us.User.Role == (int)Roles.Teacher && us.User.Login == userName)).ToListAsync();
        }

        public async Task<List<Module>> GetModulesById(int subjectId)
        {
            return await _subjectRepository.GetAll(x => x.Id == subjectId).SelectMany(x => x.Modules).Include(x => x.Lectures).ToListAsync();
        }

        public void AddLecture(Lecture lecture)
        {
            _lectureRepository.Add(lecture);
        }
    }
}
