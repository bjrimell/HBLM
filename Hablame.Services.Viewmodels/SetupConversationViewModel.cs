using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

using Hablame.Domain.Entities;

namespace Hablame.Services.Viewmodels
{
    public class SetupConversationViewModel
    {
        public string TeacherId { get; set; }

        public List<User> FriendsList { get; set; }

        public List<SelectListItem> FriendsSelectList { get; set; }

        public List<Language> LanguageList { get; set; }

        public List<SelectListItem> LanguageSelectList { get; set; }

        public List<MistakeTypeConfiguration> MistakeTypeConfigurationList { get; set; }

        public List<SelectListItem> MistaketypeConfigSelectList { get; set; }
    }
}
