using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Domain.Entities;
using System.Web.Mvc;

namespace Hablame.Services.Viewmodels
{
    public class TeacherSettingsViewModel
    {
        public List<MistakeType> AllMistakeTypes { get; set; }

        public List<SelectListItem> AllLanguages { get; set; }

        public List<SelectListItem> MistakeTypeConfigurationsForSelectBox { get; set; }

        public List<SelectListItem> MistakeTypesForSelect { get; set; }

        public string NewMistakeGroupTitle { get; set; }

        public string NewMistakeTypeTitle { get; set; }

        public string NewMistakeTypeLanguageId { get; set; }

        public bool NewMistakeTypeIsGrammar { get; set; }

        public bool NewMistakeTypeIsVocab { get; set; }

        public bool NewMistakeTypeIsPronunciation { get; set; }

        public bool NewMistakeTypeIsPraise { get; set; }

        public bool AddedSuccess { get; set; }
    }
}
