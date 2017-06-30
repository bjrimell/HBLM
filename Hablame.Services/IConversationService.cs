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
        ConversationViewModel CreateConversationViewModel(Guid studentId);

        ConversationViewModel RecreateConversationViewModel(Guid conversationId, string spokenValue, string correctValue, bool IsSuperfluousAuxVerb, bool IsMissingAuxVerb);

        Guid GetConversationStudentId(Guid conversationId);

        Guid GetConversationTeacherId(Guid conversationId);

    }
}
