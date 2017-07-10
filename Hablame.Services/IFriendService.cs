using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Services.Viewmodels;
using Hablame.Domain.Entities;
using System.Web.Mvc;

namespace Hablame.Services
{
    public interface IFriendService
    {
        FriendListViewModel GetFriendListViewModel(Guid teacherId);

        List<User> GetFriendList(Guid teacherId);

        List<SelectListItem> GetFriendSelectList(Guid teacherId);

        User GetUserById(Guid userId);
    }
}
