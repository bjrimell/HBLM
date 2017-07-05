using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hablame.Domain.Entities
{
    public class MistakeType
    {
        public string Title { get; set; }

        public int MinimumRatingLevelVisibility { get; set; }

        public int MaximumRatingLevelVisibility { get; set; }
    }
}
