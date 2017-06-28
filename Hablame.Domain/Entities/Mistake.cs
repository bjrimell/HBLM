using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hablame.Domain.Entities
{
    public class Mistake
    {
        public string StudentId { get; set; }

        public string TeacherId { get; set; }
        public string ConversationId { get; set; }

        public string LanguageId { get; set; }

        public bool IsWordMistake { get; set; }

        public bool IsPhraseMistake { get; set; }

        public bool IsGrammarMistake { get; set; }

        public bool IsPronunciationMistake { get; set; }

        public string SpokenValue { get; set; }

        public string CorrectValue { get; set; }

        public string Comment { get; set; }
    }
}
