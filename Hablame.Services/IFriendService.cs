﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Services.Viewmodels;
using Hablame.Domain.Entities;

namespace Hablame.Services
{
    public interface IFriendService
    {
        FriendListViewModel GetFriendListViewModel(string teacherId);

        User GetUserById(string userId);
    }
}
