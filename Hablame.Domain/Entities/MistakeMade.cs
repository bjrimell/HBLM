﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hablame.Domain.Entities
{
    public class MistakeMade
    {
        public Guid Id { get; set; }

        public Guid MistakeId { get; set; }
        public Guid StudentId { get; set; }

        public Guid TeacherId { get; set; }
        public Guid ConversationId { get; set; }

        public Guid LanguageId { get; set; }

        public DateTime DateTime { get; set; }

        public int MinutesAgo
        {
            get
            {
                return DateTime.Now.Subtract(DateTime).Minutes;
            }
        }

        public bool IsWordMistake { get; set; }

        public bool IsPhraseMistake { get; set; }

        public bool IsGrammarMistake { get; set; }

        public bool IsPronunciationMistake { get; set; }

        public string SpokenValue { get; set; }

        public string CorrectValue { get; set; }

        public string Comment { get; set; }

        public int Count { get; set; }

        public int Rating { get; set; }

        public bool PronunciationError { get; set; }
    }
}