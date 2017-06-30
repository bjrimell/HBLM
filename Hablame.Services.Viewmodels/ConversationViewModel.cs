using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Domain.Entities;

namespace Hablame.Services.Viewmodels
{
    public class ConversationViewModel
    {
        public Conversation SavedConversation { get; set; }

        public Guid ConversationId { get; set; }
        public User Teacher { get; set; }

        public User Student { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int DurationMinutes { get; set; }

        public List<Mistake> TopGlobalMistakesForLanguage { get; set; }

        public List<Mistake> MostCommonSessionMistakes { get; set; }

        public List<Mistake> LatestSessionMistakes { get; set; }

        public Language Language { get; set; }

    }
}
