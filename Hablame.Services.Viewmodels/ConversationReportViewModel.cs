using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hablame.Domain.Entities;

namespace Hablame.Services.Viewmodels
{
    public class ConversationReportViewModel
    {
        public ConversationSummary Conversation { get; set; }

        public List<Mistake> MistakeList { get; set; }

        public List<Mistake> PraiseList { get; set; }
    }
}
