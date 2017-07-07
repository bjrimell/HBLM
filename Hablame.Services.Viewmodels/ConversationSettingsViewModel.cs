using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Domain.Entities;

namespace Hablame.Services.Viewmodels
{
    public class ConversationSettingsViewModel
    {
        public Guid ConversationId { get; set; }

        public ConversationConfiguration ConversationConfiguration { get; set; }

        public List<MistakeTypeConfiguration> AvailableMistakeTypeConfigs { get; set; }

    }
}
