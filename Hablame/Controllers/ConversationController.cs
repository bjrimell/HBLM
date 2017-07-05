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
            IEnumerable<string> SelectedMistakeTypes,
            int rating = 0,
            bool IsSuperfluousAuxVerb = false,
            bool IsMissingAuxVerb = false)
        {
            var conversationGuid = Guid.Parse(conversationId);

            var viewModel = this.conversationService.RecreateConversationViewModel(conversationGuid, spokenValue, correctValue, IsSuperfluousAuxVerb, IsMissingAuxVerb);

            var newMistake = this.mistakeService.CreateMistake(
                conversationGuid,
                rating,
                spokenValue,
                correctValue,
                SelectedMistakeTypes);

            this.conversationService.SetMessaging(viewModel, newMistake);

            return this.PartialView("_Conversation", viewModel);
        }
    }
}