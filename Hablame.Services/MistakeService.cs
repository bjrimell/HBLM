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
        public class MistakeService : IMistakeService
    {
        private readonly IConversationService conversationService;
        private readonly IMistakeRepository mistakeRepository;

        public MistakeService(IConversationService conversationService, IMistakeRepository mistakeRepository)
        {
            this.conversationService = conversationService;
            this.mistakeRepository = mistakeRepository;
        }
        public EnteredMistakeViewModel CreateTypedMistakeViewModel()
        {
            var viewModel = new EnteredMistakeViewModel();
            return viewModel;
        }

        public MistakeMade CreateMistakeMade(Guid conversationId, int rating, string spokenValue, string correctValue, IEnumerable<string> selectedMistakeTypes, string repeatedMistakeId)
        {
            var mistakeMade = new MistakeMade
            {
                Id = Guid.NewGuid(),
                MistakeId = this.SetMistakeId(repeatedMistakeId, correctValue, spokenValue, rating, conversationId, selectedMistakeTypes),
                ConversationId = conversationId,
                DateTime = DateTime.Now,
            };

            this.mistakeRepository.CreateNewMistakeMade(mistakeMade);

            return mistakeMade;
        }

        private Guid SetMistakeId(string repeatedMistakeId, string correctValue, string spokenValue, int rating, Guid conversationId, IEnumerable<string> selectedMistakeTypes)
        {
            // If we are repeating an existing mistake, just use that ID
            // If not, see if a matching Mistake already exists in the DB
            // If it does not, create a new one

            if (repeatedMistakeId != null)
            {
                return Guid.Parse(repeatedMistakeId);
                // early out if we know we are reusing an existing Mistake
            }

            var matchingMistake = this.mistakeRepository.GetAllMistakes().Where(m => m.CorrectValue == correctValue && m.SpokenValue == spokenValue && m.Rating == rating).FirstOrDefault();
            if (matchingMistake != null)
            {
                return matchingMistake.Id;
            }
            else
            {
                // get all the user selected mistake types that can be applied to this mistake
                var validMistakeTypesSelected = this.GenerateValidMistakeTypes(selectedMistakeTypes, rating);

                // Create brand new mistake
                var mistake = new Mistake
                {
                    Id = Guid.NewGuid(),
                    DateTime = DateTime.Now,
                    ConversationId = conversationId,
                    SpokenValue = spokenValue,
                    CorrectValue = correctValue,
                    StudentId = this.conversationService.GetConversationStudentId(conversationId),
                    TeacherId = this.conversationService.GetConversationTeacherId(conversationId),
                    Rating = rating,
                    IsGrammar = validMistakeTypesSelected.Any(m => m.IsGrammar),
                    IsPronunciation = validMistakeTypesSelected.Any(m => m.IsPronunciation),
                    IsVocab = validMistakeTypesSelected.Any(m => m.IsVocab)
                };

                this.mistakeRepository.CreateNewMistake(mistake, validMistakeTypesSelected);
                return mistake.Id;
            }
        }

        private List<MistakeType> GenerateValidMistakeTypes(IEnumerable<string> selectedMistakeTypeIds, int rating)
        {
            var validSelectedMistakeTypes = new List<MistakeType>();

            var selectedMistakeTypes = this.mistakeRepository.GetSelectedMistakeTypes(selectedMistakeTypeIds, rating);

            validSelectedMistakeTypes = selectedMistakeTypes.Where(m => m.MinimumRatingLevelVisibility <= rating && m.MaximumRatingLevelVisibility >= rating).ToList();

            return validSelectedMistakeTypes;
        }
    }
}
