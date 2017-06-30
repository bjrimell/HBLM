using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Services.Viewmodels;
using Hablame.Domain.Entities;
using Hablame.Repositories;

namespace Hablame.Services
{
    public class FriendService : IFriendService
    {
        private readonly IUserRepository userRepository;

        public FriendService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public FriendListViewModel GetFriendListViewModel(Guid teacherId)
        {
            var viewModel = new FriendListViewModel();

            var allUsers = this.userRepository.GetAllMockUsers();

            viewModel.FriendList.AddRange(allUsers);

            return viewModel;
        }

        public User GetUserById(Guid userId)
        {
            var allUsers = this.userRepository.GetAllMockUsers();
            return allUsers.SingleOrDefault(m => m.Id == userId);
        }
    }
}
