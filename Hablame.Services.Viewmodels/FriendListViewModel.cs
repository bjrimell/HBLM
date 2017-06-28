using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Domain.Entities;
using Hablame.Domain;

namespace Hablame.Services.Viewmodels
{
    public class FriendListViewModel
    {
        public FriendListViewModel()
        {
            this.FriendList = new List<User>();
        }
        public List<User> FriendList { get; set; }
    }
}
