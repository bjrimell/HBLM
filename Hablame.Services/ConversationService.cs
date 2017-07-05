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
        private readonly IConversationRepository conversationRepository;

        public ConversationService(IFriendService friendService, IMistakeRepository mistakeRepository, IConversationRepository conversationRepository)
        {
            this.friendService = friendService;
            this.mistakeRepository = mistakeRepository;
            this.conversationRepository = conversationRepository;
        }
        public ConversationViewModel CreateConversationViewModel(Guid studentId)
        {
            // TODO: Make this current logged-in user
            var currentUserId = new Guid("a3250996-fa99-4299-b44a-8fb0be5386e5");
            var student = this.friendService.GetUserById(studentId);
            var teacher = this.friendService.GetUserById(currentUserId);

            var allMistakes = this.mistakeRepository.GetAllMistakes();

            // TODO: Make this be the selected language when the convo was initiated
            var language = new Language
            {
                Id = Guid.Parse("f4e4b27d-eb24-43de-b9d7-f67a73ae83f8"),
                Name = "English",
                Family = "Germanic"
            };

            var conversation = new Conversation
            {
                Id = Guid.NewGuid(),
                TeacherId = currentUserId,
                StudentId = studentId,
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now,
                LanguageId = Guid.Parse("f4e4b27d-eb24-43de-b9d7-f67a73ae83f8") //English
            };

            var convoId = this.conversationRepository.CreateNewConversation(conversation);

            var viewModel = new ConversationViewModel
            {
                ConversationId = Guid.Parse(convoId),
                Teacher = teacher,
                Student = student,
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now,
                TopGlobalMistakesForLanguage = this.mistakeRepository.GetTopMistakesForLanguage(conversation.LanguageId),
                LatestSessionMistakes = this.mistakeRepository.GetLatestSessionMistakes(conversation.Id),
                MostCommonSessionMistakes = this.mistakeRepository.GetTopMistakesForSession(conversation.Id),
                MostCommonMistakesForStudent = this.mistakeRepository.GetTopMistakesForStudent(student.Id),
                Language = language,
                MistakeTypeOptions = this.GetMistakeTypeOptions(conversation.LanguageId)
            };

            return viewModel;
        }

        public ConversationViewModel RecreateConversationViewModel(Guid conversationId, string spokenValue, string correctValue, bool IsSuperfluousAuxVerb, bool IsMissingAuxVerb)
        {
            var savedConversation = this.conversationRepository.RetrieveConversation(conversationId);
            var teacher = this.friendService.GetUserById(savedConversation.TeacherId);
            var student = this.friendService.GetUserById(savedConversation.StudentId);
            var allMistakes = this.mistakeRepository.GetAllMistakes();

            var viewModel = new ConversationViewModel
            {
                ConversationId = savedConversation.Id,
                Teacher = teacher,
                Student = student,
                TopGlobalMistakesForLanguage = this.mistakeRepository.GetTopMistakesForLanguage(savedConversation.LanguageId),
                LatestSessionMistakes = this.mistakeRepository.GetLatestSessionMistakes(conversationId),
                MostCommonSessionMistakes = this.mistakeRepository.GetTopMistakesForSession(conversationId),
                MostCommonMistakesForStudent = this.mistakeRepository.GetTopMistakesForStudent(student.Id),
                StartDateTime = savedConversation.StartDateTime,
                EndDateTime = savedConversation.EndDateTime,
                Language = savedConversation.Language,
                MistakeTypeOptions = this.GetMistakeTypeOptions(savedConversation.LanguageId)
            };

            return viewModel;
        }

        public Guid GetConversationStudentId(Guid conversationId)
        {
            var conversation = this.conversationRepository.RetrieveConversation(conversationId);
            return conversation.StudentId;
        }

        public Guid GetConversationTeacherId(Guid conversationId)
        {
            var conversation = this.conversationRepository.RetrieveConversation(conversationId);
            return conversation.TeacherId;
        }

        public void SetMessaging(ConversationViewModel viewModel, Mistake newMistake)
        {
            viewModel.NewMistake = newMistake;
            viewModel.MistakeAdded = newMistake.Rating < 5;
            viewModel.PraiseAdded = newMistake.Rating == 5;
        }

        private List<MistakeTypeOptions> GetMistakeTypeOptions(Guid languageId)
        {
            var response = new List<MistakeTypeOptions>();
            var allMistakes = this.mistakeRepository.GetMistakeTypes(languageId);

            // Started with 1 rather than the traditional 0 as it will be used for the rating levels 1 -5
            for (int i = 1; i <= 5; i++)
            {
                var mistakeTypeOptions = new MistakeTypeOptions
                {
                    RatingVisibleFor = i,
                    MistakeTypeList = allMistakes.Where(m => m.MaximumRatingLevelVisibility >= i && m.MinimumRatingLevelVisibility <= i).ToList()
                };
                response.Add(mistakeTypeOptions);
            }
            return response;
        }
    }
}
