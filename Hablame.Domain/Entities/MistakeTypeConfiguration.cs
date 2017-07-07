using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hablame.Domain.Entities
{
    public class MistakeTypeConfiguration
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid OwnerId { get; set; }

        public Guid FirstMistakeTypeId { get; set; }

        public Guid SecondMistakeTypeId { get; set; }

        public Guid ThirdMistakeTypeId { get; set; }

    }
}
