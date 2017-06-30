using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hablame.Domain.Entities
{
    public class Conversation
    {
        public Guid Id { get; set; }

        public Guid TeacherId { get; set; }

        public Guid StudentId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int DurationMinutes { get; set; }

        public Language Language { get; set; }

        public Guid LanguageId { get; set; }
    }
}
