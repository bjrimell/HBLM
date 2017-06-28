using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Hablame.Services;

namespace Hablame.Controllers
{
    public class TalkController : Controller
    {
        private readonly IConversationService talkService;

        private readonly IMistakeService mistakeService;

        public TalkController(IConversationService talkService, IMistakeService mistakeService)
        {
            this.talkService = talkService;
            this.mistakeService = mistakeService;
        }

        // GET: Talk
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult StartConversation(string studentId)
        {
            var viewModel = talkService.CreateConversationViewModel(studentId);
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
            var viewModel = this.talkService.RecreateConversationViewModel(conversationId, spokenValue, correctValue, IsSuperfluousAuxVerb, IsMissingAuxVerb);

            var newMistake = this.mistakeService.CreateMistake(
                conversationId,
                spokenValue,
                correctValue,
                IsSuperfluousAuxVerb,
                IsMissingAuxVerb);

            viewModel.TopGlobalMistakesForLanguage.Add(newMistake);

            return this.PartialView("_Conversation", viewModel);
        }
    }
}