using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Hablame.Services;

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
        public ActionResult StartConversation(Guid studentId)
        {
            var viewModel = conversationService.CreateConversationViewModel(studentId);
            return this.PartialView("_Conversation", viewModel);
        }

        [HttpPost]
        public ActionResult StartConversation(
            string conversationId,
            string spokenValue,
            string correctValue,
            bool IsSuperfluousAuxVerb = false,
            bool IsMissingAuxVerb = false)
        {
            var conversationGuid = Guid.Parse(conversationId);

            var newMistake = this.mistakeService.CreateMistake(
                conversationGuid,
                spokenValue,
                correctValue,
                IsSuperfluousAuxVerb,
                IsMissingAuxVerb);

            var viewModel = this.conversationService.RecreateConversationViewModel(conversationGuid, spokenValue, correctValue, IsSuperfluousAuxVerb, IsMissingAuxVerb);

            viewModel.TopGlobalMistakesForLanguage.Add(newMistake);

            return this.PartialView("_Conversation", viewModel);
        }
    }
}