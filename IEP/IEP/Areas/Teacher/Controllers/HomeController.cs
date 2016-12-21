using IEP.Areas.Teacher.Models;
using IEP.BusinessLogic.Contracts;
using IEP.BusinessLogic.Entities;
using IEP.Services.Contracts;
using Nelibur.ObjectMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IEP.Areas.Teacher.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISubjectsService _subjectService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public HomeController(ISubjectsService subjectService, IUnitOfWork unitOfWork, IUserService userService)
        {
            _subjectService = subjectService;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        // GET: Teacher/Home
        public async Task<ActionResult> Index()
        {
            var subjects = await _subjectService.GetSubjectsForUser(User.Identity.Name);

            var model = new TeacherViewModel(subjects.Select(s => new SubjectViewModel { Id = s.Id, Name = s.Name }).ToList());

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> AddSubject()
        {
            return View(new SubjectViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> AddSubject(SubjectViewModel model)
        {
            var subject = TinyMapper.Map<Subject>(model);

            var user = await _userService.GetByName(User.Identity.Name);

            subject.UserSubjects.Add(new UserSubject { UserId = user.Id });

            _subjectService.AddSubject(subject);

            await _unitOfWork.CommitAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> GetSubject(int subjectId)
        {
            var modules = await _subjectService.GetModulesById(subjectId);

            return View("Subject", new SubjectViewModel
            {
                Id = subjectId,
                Modules = TinyMapper.Map<List<ModuleViewModel>>(modules)
            });
        }

        [HttpGet]
        public async Task<ActionResult> AddModule(int subjectId)
        {
            return View(new ModuleViewModel { SubjectId = subjectId });
        }

        [HttpPost]
        public async Task<ActionResult> AddModule(ModuleViewModel model)
        {
            var module = TinyMapper.Map<Module>(model);

            _subjectService.AddModule(module);

            await _unitOfWork.CommitAsync();

            return RedirectToAction("GetSubject", new { subjectId = model.SubjectId });
        }

        [HttpGet]
        public async Task<ActionResult> AddLecture(int subjectId)
        {
            var modules = await _subjectService.GetModulesById(subjectId);

            return View(new LectureViewModel { SubjectId = subjectId, AvailableModules = TinyMapper.Map<List<ModuleViewModel>>(modules) });
        }

        public async Task<ActionResult> AddLecture(LectureViewModel model)
        {
            var lecture = TinyMapper.Map<Lecture>(model);

            lecture.Content = "";
            _subjectService.AddLecture(lecture);

            await _unitOfWork.CommitAsync();

            return RedirectToAction("GetSubject", new { subjectId = model.SubjectId });
        }
    }
}