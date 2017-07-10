using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hablame.Domain.Entities
{
    public class ConversationSummary
    {
        public Guid ConversationId { get; set; }

        public DateTime StartDateTime { get; set; }

        public string StudentForename { get; set; }

        public string StudentSurname { get; set; }

        public string TeacherForename { get; set; }

        public string TeacherSurname { get; set; }

        public string Language { get; set; }

        public string ConfigurationName { get; set; }

        public int DurationMinutes { get; set; }

        public Guid LanguageId { get; set; }

        public Guid MistakeTypeOptionsConfigId { get; set; }

        public Guid StudentId { get; set; }

        public Guid TeacherId { get; set; }
    }
}