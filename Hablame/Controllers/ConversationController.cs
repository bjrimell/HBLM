using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Hablame.Services;

using Hablame.Domain.Entities;
using Hablame.Services.Viewmodels;

namespace Hablame.Controllers
{
    public class ConversationController : Controller
    {
        private readonly IConversationService conversationService;

        private readonly IMistakeService mistakeService;

        public ConversationController(IConversationService conversationService, IMistakeService mistakeService)
        {
            this.conversationService = conversationService;
            this.mistakeService = mistakeService;
        }

        // GET: Talk
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult StartConversation(Guid studentId, string mistakeTypeConfigurationId)
        {
            var viewModel = conversationService.CreateConversationViewModel(studentId, mistakeTypeConfigurationId);
            return this.PartialView("_Conversation", viewModel);
        }

        [HttpPost]
        public ActionResult StartConversation(
            string conversationId,
            string spokenValue,
            string correctValue,
            IEnumerable<string> SelectedMistakeTypes,
            int rating = 0,
            string mistakeId = null)
        {
            var conversationGuid = Guid.Parse(conversationId);

            var newMistakeMade = this.mistakeService.CreateMistakeMade(
                conversationGuid,
                rating,
                spokenValue,
                correctValue,
                SelectedMistakeTypes,
                mistakeId);

            //var validMistakeTypes = this.mistakeService.GenerateValidMistakeTypes(SelectedMistakeTypes, rating);

            var viewModel = this.conversationService.RecreateConversationViewModel(conversationGuid, spokenValue, correctValue);

            this.conversationService.SetMessaging(viewModel, newMistakeMade, mistakeId);

            return this.PartialView("_Conversation", viewModel);
        }

        public ActionResult ConversationConfiguration(string conversationId, string teacherId, string mistakeTypeOptionsConfigId)
        {
            var viewModel = this.conversationService.SetupConvoSettingsViewModel(conversationId, teacherId, mistakeTypeOptionsConfigId);

            return this.PartialView("_ConversationSettings", viewModel);
        }

        public ActionResult SetupConversation(string teacherId)
        {
            var viewModel = this.conversationService.SetupConversationViewModel(teacherId);

            return this.PartialView("_SetupConversation", viewModel);
        }

        [HttpPost]
        public ActionResult SetupConversation(string teacherId, string studentId, string languageId, string mistakeTypeConfigId)
        {
            var hey = true;

            return null;

        }
    }
}