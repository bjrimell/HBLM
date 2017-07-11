using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hablame.Domain.Entities
{
    public class MistakeType
    {
        public Guid Id {get; set; }
        public string Title { get; set; }

        public int MinimumRatingLevelVisibility { get; set; }

        public int MaximumRatingLevelVisibility { get; set; }

        public bool IsGrammar { get; set; }

        public bool IsVocab { get; set; }

        public bool IsPronunciation { get; set; }

        public bool IsPraise { get; set; }
    }
}
