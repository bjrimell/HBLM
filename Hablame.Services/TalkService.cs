using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Services.Viewmodels;
using Hablame.Repositories;
using Hablame.Domain.Entities;

namespace Hablame.Services
{
    public class TalkService : ITalkService
    {

        private readonly IFriendService friendService;
        private readonly IMistakeRepository mistakeRepository;

        public TalkService(IFriendService friendService, IMistakeRepository mistakeRepository)
        {
            this.friendService = friendService;
            this.mistakeRepository = mistakeRepository;
        }
        public ConversationViewModel CreateConversationViewModel(string studentId)
        {
            // TODO: Make this current logged-in user
            var currentUserId = "En01"; // Barry
            var student = this.friendService.GetUserById(studentId);
            var teacher = this.friendService.GetUserById(currentUserId);

            var allMistakes = this.mistakeRepository.GetAllMistakes();

            // TODO: Make this be the selected language when the convo was initiated
            var language = new Language
            {
                Name = "Spanish",
                Family = "Romance"
            };

            var viewModel = new ConversationViewModel
            {
                Teacher = teacher,
                Student = student,
                StartDateTime = DateTime.Now,
                Mistakes = allMistakes,
                Language = language
            };

            return viewModel;
        }
    }
}
