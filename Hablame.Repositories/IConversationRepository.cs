using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

using Hablame.Domain.Entities;

namespace Hablame.Repositories
{
    public interface IConversationRepository
    {
        string CreateNewConversation(Conversation conversation);

        Conversation RetrieveConversation(Guid sessionId);

        List<MistakeTypeConfiguration> GetAvailableMistakeTypeSettings(Guid teacherId);

        MistakeTypeConfiguration GetConversationMistakeTypeSettings(Guid configId);

        void CreateNewMistakeTypeConfig(MistakeTypeConfiguration mistakeTypeOptionsConfiguration);

        List<Conversation> GetRecentConversationsForTeacher(string teacherId);
    }
}
