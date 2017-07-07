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

            // TODO: Make this be the selected language when the convo was initiated
            var language = new Language
            {
                Id = Guid.Parse("f4e4b27d-eb24-43de-b9d7-f67a73ae83f8"),
                Name = "English",
                Family = "Germanic"
            };

            var mistakeTypeOptionConfigurationId = this.CreateMistakeTypeOptionsConfig(currentUserId);

            var conversation = new Conversation
            {
                Id = Guid.NewGuid(),
                TeacherId = currentUserId,
                StudentId = studentId,
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now,
                LanguageId = Guid.Parse("f4e4b27d-eb24-43de-b9d7-f67a73ae83f8"), //English
                MistakeTypeOptionsConfigId = mistakeTypeOptionConfigurationId
            };

            var convoId = this.conversationRepository.CreateNewConversation(conversation);

            var viewModel = new ConversationViewModel
            {
                ConversationId = Guid.Parse(convoId),
                Teacher = this.friendService.GetUserById(currentUserId),
                Student = student,
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now,
                TopGlobalMistakesForLanguage = this.mistakeRepository.GetTopMistakesForLanguage(conversation.LanguageId),
                LatestSessionMistakes = this.mistakeRepository.GetLatestSessionMistakes(conversation.Id),
                MostCommonSessionMistakes = this.mistakeRepository.GetTopMistakesForSession(conversation.Id),
                MostCommonMistakesForStudent = this.mistakeRepository.GetTopMistakesForStudent(student.Id),
                Language = language,
                MistakeTypeOptions = this.GetMistakeTypeOptions(conversation.LanguageId),
                MistakeTypeOptionsConfigId = conversation.MistakeTypeOptionsConfigId
            };

            return viewModel;
        }

        public ConversationViewModel RecreateConversationViewModel(Guid conversationId, string spokenValue, string correctValue)
        {
            var savedConversation = this.conversationRepository.RetrieveConversation(conversationId);
            var student = this.friendService.GetUserById(savedConversation.StudentId);

            var viewModel = new ConversationViewModel
            {
                ConversationId = savedConversation.Id,
                Teacher = this.friendService.GetUserById(savedConversation.TeacherId),
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

        public void SetMessaging(ConversationViewModel viewModel, MistakeMade newMistakeMade, string mistakeId)
        {
            if (mistakeId != null)
            {
                viewModel.NewMistakeMade = this.mistakeRepository.GetMistakeMadeSummaryById(Guid.Parse(mistakeId));
            }
            else
            {
                viewModel.NewMistakeMade = newMistakeMade;
            }
            
            viewModel.MistakeAdded = newMistakeMade.Rating < 5;
            viewModel.PraiseAdded = newMistakeMade.Rating == 5;
        }

        public ConversationSettingsViewModel SetupConvoSettingsViewModel(string conversationId, string teacherId, string mistakeTypeOptionsConfigId)
        {
            var teacherGuid = Guid.Parse(teacherId);
            var conversationGuid = Guid.Parse(conversationId);
            var mistakeTypeOptions = new List<MistakeTypeOptionsConfiguration>();
            //mistakeTypeOptions = conversationRepository.GetMistakeTypeOptionsConfig(conversationId);

            var availableMistakeTypeConfigs = conversationRepository.GetAvailableMistakeTypeSettings(teacherGuid);
            var conversationConfig = this.CreateConversationConfig(conversationId, teacherId, mistakeTypeOptionsConfigId);

            var viewModel = new ConversationSettingsViewModel
            {
                ConversationId = conversationGuid,
                ConversationConfiguration = conversationConfig,
                AvailableMistakeTypeConfigs = availableMistakeTypeConfigs
            };

            return viewModel;
        }

        private ConversationConfiguration CreateConversationConfig(string conversationId, string teacherId, string mistakeTypeOptionsConfigId)
        {
            var teacherGuid = Guid.Parse(teacherId);
            var conversationGuid = Guid.Parse(conversationId);
            var mistakeTypeOptionsConfigGuid = Guid.Parse(mistakeTypeOptionsConfigId);

            var availableMistakeTypeConfigs = conversationRepository.GetAvailableMistakeTypeSettings(teacherGuid);

            var mistakeTypeOptions = new List<MistakeTypeOptionsConfiguration>();

            foreach (var item in availableMistakeTypeConfigs)
            {
                // add all the config sets available to the teacher to the list, but only mark the one matching this convo as Active
                var mtoc = new MistakeTypeOptionsConfiguration
                {
                    MistakeTypeOptionsConfig = item,
                    Enabled = item.Id == mistakeTypeOptionsConfigGuid
                };

                mistakeTypeOptions.Add(mtoc);
            }

            var config = new ConversationConfiguration
            {
                MistakeTypeOptions = mistakeTypeOptions
            };

            return config;
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

        private Guid CreateMistakeTypeOptionsConfig(Guid teacherId)
        {
            var mistakeTypeConfiguration = new MistakeTypeConfiguration
            {
                Id = Guid.NewGuid(),
                Name = "Default",
                OwnerId = teacherId,
                FirstMistakeTypeId = Guid.Parse("fafb46df-e97d-4fac-a016-9c9151e26280"),
                SecondMistakeTypeId = Guid.Parse("3eb190de-2d05-4d76-b261-dc980c9fbd2e"),
                ThirdMistakeTypeId = Guid.Parse("fca1ff37-4b73-4a84-866c-41ce322448ab")
            };

            this.conversationRepository.CreateNewMistakeTypeConfig(mistakeTypeConfiguration);

            return mistakeTypeConfiguration.Id;
        }
    }
}
