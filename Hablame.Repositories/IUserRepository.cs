﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hablame.Domain.Entities;

namespace Hablame.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllMockUsers();
    }
}