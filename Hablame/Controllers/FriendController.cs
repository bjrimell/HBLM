using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Hablame.Services;

namespace Hablame.Controllers
{
    public class FriendController : Controller
    {
        private readonly IFriendService friendService;

        public FriendController(IFriendService friendService)
        {
            this.friendService = friendService;
        }

        // GET: Friend
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FriendList(string teacherId)
        {
            var viewModel = this.friendService.GetFriendListViewModel(teacherId);
            return this.PartialView("_FriendList", viewModel);
        }
    }
}