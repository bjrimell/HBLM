using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Services.Viewmodels;

namespace Hablame.Services
{
    public interface ISettingsService
    {
        TeacherSettingsViewModel SetupTeacherSettingsViewModel();

        TeacherSettingsViewModel RecreateTeacherSettingsViewModel(string NewMistakeGroupTitle, string mistakeTypeId, string mistakeGroupId, string NewMistakeTypeTitle, bool isGrammar, bool isVocab, bool isPronunciation, bool isPraise);
    }
}
