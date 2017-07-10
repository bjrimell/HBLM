using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Services.Viewmodels;
using Hablame.Domain.Entities;

namespace Hablame.Services
{
    public interface IConversationService
    {
        string SetupNewConversation(string teacherId, string studentId, string languageId, string mistakeTypeConfigurationId);
        ConversationViewModel CreateConversationViewModel(string conversationId);

        ConversationViewModel RecreateConversationViewModel(Guid conversationId, string spokenValue, string correctValue);

        Guid GetConversationStudentId(Guid conversationId);

        Guid GetConversationTeacherId(Guid conversationId);

        void SetMessaging(ConversationViewModel viewModel, MistakeMade newMistakeMade, string mistakeId);

        ConversationSettingsViewModel SetupConvoSettingsViewModel(string conversationId, string teacherId, string mistakeTypeOptionsConfigId);

        SetupConversationViewModel SetupConversationViewModel(string teacherId);

        RecentConversationsViewModel SetupRecentConversationsViewModel(string teacherId);
    }
}
