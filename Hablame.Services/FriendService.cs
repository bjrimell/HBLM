using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Services.Viewmodels;
using Hablame.Domain.Entities;
using Hablame.Repositories;

using System.Web.Mvc;

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

            var allUsers = this.userRepository.GetAllUsers();

            viewModel.FriendList.AddRange(allUsers);

            return viewModel;
        }

        public List<User> GetFriendList(Guid teacherId)
        {
            // Todo: restrict to where student has friendship with techer, don't just bring them all back
            return this.userRepository.GetAllUsers();
        }

        public User GetUserById(Guid userId)
        {
            var allUsers = this.userRepository.GetAllUsers();
            return allUsers.SingleOrDefault(m => m.Id == userId);
        }

        public List<SelectListItem> GetFriendSelectList(Guid teacherId)
        {
            var allUsers = this.userRepository.GetAllUsers();
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var item in allUsers)
            {
                items.Add(new SelectListItem
                {
                    Text = item.Forename + " " +item.Surname,
                    Value = item.Id.ToString()
                });
            }
            return items;
        }
    }
}
