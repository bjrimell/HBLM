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
        public User Teacher { get; set; }

        public User Student { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int DurationMinutes { get; set; }

        public List<Mistake> Mistakes { get; set; }

        public Language Language { get; set; }

    }
}
