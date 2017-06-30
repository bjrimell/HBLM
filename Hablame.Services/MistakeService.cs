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

        public Mistake CreateMistake(Guid conversationId, string spokenValue, string correctValue, bool IsSuperfluousAuxVerb, bool IsMissingAuxVerb)
        {
            var mistake = new Mistake
            {
                Id = Guid.NewGuid(),
                DateTime = DateTime.Now,
                ConversationId = conversationId,
                SpokenValue = spokenValue,
                CorrectValue = correctValue,
                StudentId = this.conversationService.GetConversationStudentId(conversationId),
                TeacherId = this.conversationService.GetConversationTeacherId(conversationId)
            };

            this.mistakeRepository.CreateNewMistake(mistake);

            return mistake;
        }
    }
}
