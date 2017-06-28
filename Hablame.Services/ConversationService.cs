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
    public class ConversationService : IConversationService
    {

        private readonly IFriendService friendService;
        private readonly IMistakeRepository mistakeRepository;
        private IConversationRepository conversationRepository;

        public ConversationService(IFriendService friendService, IMistakeRepository mistakeRepository, IConversationRepository conversationRepository)
        {
            this.friendService = friendService;
            this.mistakeRepository = mistakeRepository;
            this.conversationRepository = conversationRepository;
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
                ConversationId = Guid.NewGuid().ToString(),
                Teacher = teacher,
                Student = student,
                StartDateTime = DateTime.Now,
                TopGlobalMistakesForLanguage = allMistakes,
                MostCommonSessionMistakes = allMistakes,
                LatestSessionMistakes = allMistakes,
                Language = language
            };

            return viewModel;
        }

        public ConversationViewModel RecreateConversationViewModel(string conversationId, string spokenValue, string correctValue, bool IsSuperfluousAuxVerb, bool IsMissingAuxVerb)
        {
            var savedConversation = this.conversationRepository.RetrieveConversation(conversationId);
            var teacher = this.friendService.GetUserById(savedConversation.TeacherId);
            var student = this.friendService.GetUserById(savedConversation.StudentId);
            var allMistakes = this.mistakeRepository.GetAllMistakes();
            var topGlobalMistakesForLanguage = this.mistakeRepository.GetTopMistakesForLanguage(savedConversation.Language.Name);
            var latestSessionMistakes = this.mistakeRepository.GetLatestSessionMistakes(conversationId);
            var mostCommonSessionMistakes = this.mistakeRepository.GetTopMistakesForSession(conversationId);

            var viewModel = new ConversationViewModel
            {
                ConversationId = savedConversation.ConversationId,
                Teacher = teacher,
                Student = student,
                TopGlobalMistakesForLanguage = topGlobalMistakesForLanguage,
                LatestSessionMistakes = latestSessionMistakes,
                MostCommonSessionMistakes = mostCommonSessionMistakes,
                StartDateTime = savedConversation.StartDateTime,
                EndDateTime = savedConversation.EndDateTime,
                Language = savedConversation.Language
            };

            return viewModel;
        }

        public string GetConversationStudentId(string conversationId)
        {
            var conversation = this.conversationRepository.RetrieveConversation(conversationId);
            return conversation.StudentId;
        }

        public string GetConversationTeacherId(string conversationId)
        {
            var conversation = this.conversationRepository.RetrieveConversation(conversationId);
            return conversation.TeacherId;
        }
    }
}
