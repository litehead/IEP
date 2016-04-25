using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IEP.BusinessLogic.Contracts;
using IEP.Services.Contracts;

namespace IEP.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILiteratureService _literatureService;

        public HomeController(IUnitOfWork unitOfWork, ILiteratureService literatureService)
        {
            _unitOfWork = unitOfWork;
            _literatureService = literatureService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> Library()
        {
            var literature = await _literatureService.GetLiteratureItems();
            return View(literature);
        }
    }
}