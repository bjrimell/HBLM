using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hablame.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Forename { get; set; }

        public string Surname { get; set; }

        public string EmailAddress {get; set; }
    }
}
