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
        private readonly ITalkService talkService;

        public TalkController(ITalkService talkService)
        {
            this.talkService = talkService;
        }

        // GET: Talk
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StartConversation(string studentId)
        {
            var viewModel = talkService.CreateConversationViewModel(studentId);
            return this.PartialView("_Conversation", viewModel);
        }
    }
}