using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Hablame.Services.Viewmodels;
using Hablame.Services;

namespace Hablame.Controllers
{
    public class ReportController : Controller
    {

        private readonly IConversationService conversationService;

        public ReportController(IConversationService conversationService)
        {
            this.conversationService = conversationService;
        }

        // GET: Report
        public ActionResult Index(string conversationId)
        {
            var viewModel = this.conversationService.SetupConversationReportViewModel(conversationId);

            return View(viewModel);
        }
    }
}