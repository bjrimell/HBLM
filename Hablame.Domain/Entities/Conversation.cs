using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hablame.Domain.Entities
{
    public class Conversation
    {
        public string ConversationId { get; set; }

        public string TeacherId { get; set; }

        public string StudentId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int DurationMinutes { get; set; }

        public Language Language { get; set; }
    }
}
