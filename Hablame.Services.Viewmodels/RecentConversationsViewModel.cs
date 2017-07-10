using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hablame.Domain.Entities;

namespace Hablame.Services.Viewmodels
{
    public class RecentConversationsViewModel
    {
        public List<Conversation> Conversations { get; set; }
    }
}
