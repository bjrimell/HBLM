using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Services.Viewmodels;

namespace Hablame.Services
{
    public interface IConversationService
    {
        ConversationViewModel CreateConversationViewModel(string studentId);

        ConversationViewModel RecreateConversationViewModel(string conversationId, string spokenValue, string correctValue, bool IsSuperfluousAuxVerb, bool IsMissingAuxVerb);

        string GetConversationStudentId(string conversationId);

        string GetConversationTeacherId(string conversationId);

    }
}
