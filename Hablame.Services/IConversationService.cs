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
        ConversationViewModel CreateConversationViewModel(Guid studentId);

        ConversationViewModel RecreateConversationViewModel(Guid conversationId, string spokenValue, string correctValue);

        Guid GetConversationStudentId(Guid conversationId);

        Guid GetConversationTeacherId(Guid conversationId);

        void SetMessaging(ConversationViewModel viewModel, MistakeMade newMistakeMade, string mistakeId);

    }
}
