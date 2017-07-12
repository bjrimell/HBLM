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
    public class SettingsService : ISettingsService
    {

        private readonly ISettingsRepository settingsRepository;
        private readonly ILanguageService languageService;

        public SettingsService(ISettingsRepository settingsRepository, ILanguageService languageService)
        {
            this.settingsRepository = settingsRepository;
            this.languageService = languageService;
        }

        public TeacherSettingsViewModel SetupTeacherSettingsViewModel()
        {
            var teacherId = "A3250996-FA99-4299-B44A-8FB0BE5386E5"; // Barry
            var viewModel = new TeacherSettingsViewModel
            {
                AllMistakeTypes = this.settingsRepository.GetAllMistakeTypes(),
                AllLanguages = this.GetAllLanguagesForSelectBox(),
                MistakeTypeConfigurationsForSelectBox = this.GetMistakeTypeConfigsForSelect(teacherId),
                MistakeTypesForSelect = this.GetMistakeTypesForSelect()
            };

            return viewModel;
        }

        public TeacherSettingsViewModel RecreateTeacherSettingsViewModel(string NewMistakeGroupTitle, string mistakeTypeId, string mistakeGroupId, string title, bool isGrammar, bool isVocab, bool isPronunciation, bool isPraise)
        {
            var teacherId = "A3250996-FA99-4299-B44A-8FB0BE5386E5";
            bool success = false;

            // todo: this should be done much better. Probably need two different controller methods leading to two different service methods.
            if (NewMistakeGroupTitle != null)
            {
                this.settingsRepository.AddNewMistakeGroup(NewMistakeGroupTitle, teacherId);
            }

            if (mistakeTypeId != null && mistakeGroupId != null)
            {
                success = this.AddMistakeTypeToGroup(mistakeTypeId, mistakeGroupId);
            }
            else
            {
                var mistakeType = new MistakeType
                {
                    Id = Guid.NewGuid(),
                    Title = title,
                    IsGrammar = isGrammar,
                    IsVocab = isVocab,
                    IsPronunciation= isPronunciation,
                    IsPraise = isPronunciation
                };

                this.settingsRepository.AddMistakeType(mistakeType);
            }

            var viewModel = this.SetupTeacherSettingsViewModel();
            viewModel.AddedSuccess = success;

            return viewModel;
        }

        private bool AddMistakeTypeToGroup(string mistakeTypeId, string mistakeGroupId)
        {
            return this.settingsRepository.AddMistakeTypeToGroup(mistakeTypeId, mistakeGroupId);
        }

        // todo: the below methods for selecting selectlistitems can be merged into one method
        private List<SelectListItem> GetMistakeTypesForSelect()
        {
            var allMistakeTypes = this.settingsRepository.GetAllMistakeTypes();

            var items = new List<SelectListItem>();

            foreach (var item in allMistakeTypes)
            {
                items.Add(new SelectListItem
                {
                    Text = item.Title,
                    Value = item.Id.ToString()
                });
            }
            return items;
        }

        private List<SelectListItem> GetMistakeTypeConfigsForSelect(string teacherId)
        {
            var teacherGuid = Guid.Parse(teacherId);
            var allMistakeTypeConfigs = this.settingsRepository.GetMistakeTypeConfigurations(teacherGuid);

            var items = new List<SelectListItem>();

            foreach (var item in allMistakeTypeConfigs)
            {
                items.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            return items;
        }
            

        private List<SelectListItem> GetAllLanguagesForSelectBox()
        {
            var allLanguages = this.languageService.GetAllLanguages();
            var items = new List<SelectListItem>();

            foreach (var item in allLanguages)
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
