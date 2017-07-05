using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Hablame.Services;
using Hablame.Domain.Entities;

namespace Hablame.Controllers
{
    public class MistakeController : Controller
    {
        private readonly IMistakeService mistakeService;

        public MistakeController(IMistakeService mistakeService)
        {
            this.mistakeService = mistakeService;
        }

        // GET: Mistake
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EnteredMistake()
        {
            var viewModel = this.mistakeService.CreateTypedMistakeViewModel();
            return this.PartialView("_EnteredMistake", viewModel);
        }
    }
}