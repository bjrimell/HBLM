using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hablame.Domain.Entities
{
    public class MistakeAssignedMistakeType
    {
        public Guid Id { get; set; }

        public Guid MistakeId { get; set; }

        public Guid MistakeTypeId { get; set; }
    }
}
