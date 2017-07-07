using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hablame.Domain.Entities
{
    public class MistakeTypeOptionsConfiguration
    {
        public MistakeTypeConfiguration MistakeTypeOptionsConfig { get; set; }

        public bool Enabled { get; set; }
    }
}
