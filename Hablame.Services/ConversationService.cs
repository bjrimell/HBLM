using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Services.Viewmodels;
using Hablame.Repositories;
using Hablame.Domain.Entities;

using System.Web.Mvc;

namespace Hablame.Services
{
    public class ConversationService : IConversationService
    {

        private readonly IFriendService friendService;
        private readonly ILanguageService languageService;
        private readonly IMistakeRepository mistakeRepository;
        private readonly IConversationRepository conversationRepository;

        public ConversationService(IFriendService friendService, ILanguageService languageService, IMistakeRepository mistakeRepository, IConversationRepository conversationRepository)
        {
            this.friendService = friendService;
            this.languageService = languageService;
            this.mistakeRepository = mistakeRepository;
            this.conversationRepository = conversationRepository;
        }

        public string SetupNewConversation(string teacherId, string studentId, string languageId, string mistakeTypeConfigurationId)
        {
            // TODO: Make this current logged-in user
            var student = this.friendService.GetUserById(Guid.Parse(studentId));

            var language = this.languageService.GetLanguageById(Guid.Parse(languageId));

            var conversation = new Conversation
            {
                Id = Guid.NewGuid(),
                TeacherId = Guid.Parse(teacherId),
                StudentId = Guid.Parse(studentId),
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now,
                LanguageId = Guid.Parse(languageId),
                MistakeTypeOptionsConfigId = Guid.Parse(mistakeTypeConfigurationId)
            };

            return this.conversationRepository.CreateNewConversation(conversation); // returns the new ConversationID
        }

        public ConversationViewModel CreateConversationViewModel(string conversationId)
        {
            var conversationGuid = Guid.Parse(conversationId);
            var conversation = this.conversationRepository.RetrieveConversation(conversationGuid);
            var student = this.friendService.GetUserById(conversation.StudentId);
            var language = this.languageService.GetLanguageById(conversation.LanguageId);
            var mistakeTypeConfig = this.conversationRepository.GetConversationMistakeTypeSettings(conversation.MistakeTypeOptionsConfigId);

            var viewModel = new ConversationViewModel
            {
                ConversationId = conversationGuid,
                Teacher = this.friendService.GetUserById(conversation.TeacherId),
                Student = student,
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now,
                TopGlobalMistakesForLanguage = this.mistakeRepository.GetTopMistakesForLanguage(conversation.LanguageId),
                LatestSessionMistakes = this.mistakeRepository.GetLatestSessionMistakes(conversation.Id),
                MostCommonSessionMistakes = this.mistakeRepository.GetTopMistakesForSession(conversation.Id),
                MostCommonMistakesForStudent = this.mistakeRepository.GetTopMistakesForStudent(student.Id),
                Language = language,
                MistakeTypeOptions = this.GetMistakeTypeOptions(conversation.LanguageId),
                MistakeTypeOptionsConfigId = conversation.MistakeTypeOptionsConfigId,
                MistakeTypeConfig = mistakeTypeConfig
            };

            return viewModel;
        }

        public ConversationViewModel RecreateConversationViewModel(Guid conversationId, string spokenValue, string correctValue)
        {
            var savedConversation = this.conversationRepository.RetrieveConversation(conversationId);
            var student = this.friendService.GetUserById(savedConversation.StudentId);
            var mistakeTypeConfig = this.conversationRepository.GetConversationMistakeTypeSettings(savedConversation.MistakeTypeOptionsConfigId);
            var language = this.languageService.GetLanguageById(savedConversation.LanguageId);

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
                Language = language,
                MistakeTypeOptions = this.GetMistakeTypeOptions(savedConversation.LanguageId),
                MistakeTypeOptionsConfigId = savedConversation.MistakeTypeOptionsConfigId,
                MistakeTypeConfig = mistakeTypeConfig
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

        public SetupConversationViewModel SetupConversationViewModel(string teacherId)
        {
            var teacherGuid = Guid.Parse(teacherId);

            var languageList = this.languageService.GetAllLanguages();


            var viewModel = new SetupConversationViewModel()
            {
                FriendsList = this.friendService.GetFriendList(teacherGuid),
                FriendsSelectList = this.friendService.GetFriendSelectList(teacherGuid),
                MistakeTypeConfigurationList = this.conversationRepository.GetAvailableMistakeTypeSettings(teacherGuid),
                LanguageSelectList = this.languageService.GetLanguageSelectList(),
                MistaketypeConfigSelectList = this.GetAvailableMistakeTypeSelectList(teacherGuid),
                LanguageList = languageList
            };

            return viewModel;
        }

        public RecentConversationsViewModel SetupRecentConversationsViewModel(string teacherId)
        {
            var viewModel = new RecentConversationsViewModel
            {
                ConversationSummaries = this.conversationRepository.GetRecentConversationSummaryForTeacher(teacherId)
            };

            return viewModel;
        }

        public ConversationReportViewModel SetupConversationReportViewModel(string conversationId)
        {
            var viewModel = new ConversationReportViewModel
            {
                Conversation = this.conversationRepository.GetConversationReport(conversationId),
                MistakeList = this.mistakeRepository.GetAllRemarksByConvoId(conversationId, false),
                PraiseList = this.mistakeRepository.GetAllRemarksByConvoId(conversationId, true)
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

            var praiseOptions = allMistakes.Where(m => m.IsPraise == true).ToList();
            var mistakeOptions = allMistakes.Where(m => m.IsPraise == false).ToList();
            var mistakeTypeOptions = new MistakeTypeOptions
            {
                MistakeTypeList = mistakeOptions,
                PraiseTypeList = praiseOptions
            };

            response.Add(mistakeTypeOptions);

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

        private List<SelectListItem> GetAvailableMistakeTypeSelectList(Guid teacherGuid)
        {
            var allMistakeTypes = this.conversationRepository.GetAvailableMistakeTypeSettings(teacherGuid);

            var items = new List<SelectListItem>();

            foreach (var item in allMistakeTypes)
            {
                items.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            return items;
        }
    }
}
