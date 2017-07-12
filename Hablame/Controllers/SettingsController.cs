using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Hablame.Services;

namespace Hablame.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ISettingsService settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConfigureMistakeTypes()
        {
            var viewModel = this.settingsService.SetupTeacherSettingsViewModel();
            return PartialView("_ConversationSettings", viewModel);
        }

        [HttpPost]
        public ActionResult ConfigureMistakeTypes(
            string NewMistakeGroupTitle,
            string NewMistakeTypeTitle,
            bool isGrammar=false,
            bool isVocab = false,
            bool isPronunciation = false,
            bool isPraise = false,
            string mistakeTypeId = null,
            string mistakeGroupId = null)
        {
            var viewModel = this.settingsService.RecreateTeacherSettingsViewModel(NewMistakeGroupTitle, mistakeTypeId, mistakeGroupId, NewMistakeTypeTitle, isGrammar, isVocab, isPronunciation, isPraise);
            return PartialView("_ConversationSettings", viewModel);
        }
    }
}