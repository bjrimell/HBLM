﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Domain.Entities;

namespace Hablame.Services.Viewmodels
{
    public class ConversationViewModel
    {
        public ConversationViewModel()
        {
            // added this here because the view was broken when conversation first starts. TODO: Might be best to think about how to change this...
            this.NewMistakeMade = new MistakeMade();
        }
        public Conversation SavedConversation { get; set; }

        public Guid ConversationId { get; set; }

        public Guid MistakeTypeOptionsConfigId { get; set; }

        public User Teacher { get; set; }

        public User Student { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int DurationMinutes { get; set; }

        public List<Mistake> TopGlobalMistakesForLanguage { get; set; }

        public List<Mistake> MostCommonSessionMistakes { get; set; }

        public List<MistakeMade> LatestSessionMistakes { get; set; }

        public List<MistakeMade> LatestSessionPraise { get; set; }

        public List<Mistake> MostCommonMistakesForStudent { get; set; }

        public Language Language { get; set; }

        public bool MistakeAdded { get; set; }

        public bool MistakeDeleted { get; set; }

        public bool MistakeRepeated { get; set; }

        public bool PraiseAdded { get; set; }

        public MistakeMade NewMistakeMade { get; set; }

        public MistakeTypeConfiguration MistakeTypeConfig { get; set; }

        public List<MistakeTypeOptions> MistakeTypeOptions {get; set;}

        public IEnumerable<string> SelectedMistakeTypes { get; set; }

    }

    public class MistakeTypeOptions
    {
        public List<MistakeType> PraiseTypeList { get; set; }

        public List<MistakeType> MistakeTypeList { get; set; }
    }
}
