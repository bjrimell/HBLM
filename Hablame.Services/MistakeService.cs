using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Services.Viewmodels;
using Hablame.Domain.Entities;

namespace Hablame.Services
{
        public class MistakeService : IMistakeService
    {
        private readonly IConversationService conversationService;

        public MistakeService(IConversationService conversationService)
        {
            this.conversationService = conversationService;
        }
        public EnteredMistakeViewModel CreateTypedMistakeViewModel()
        {
            var viewModel = new EnteredMistakeViewModel();
            return viewModel;
        }

        public Mistake CreateMistake(string conversationId, string spokenValue, string correctValue, bool IsSuperfluousAuxVerb, bool IsMissingAuxVerb)
        {
            var mistake = new Mistake
            {
                ConversationId = conversationId,
                SpokenValue = spokenValue,
                CorrectValue = correctValue,
                StudentId = this.conversationService.GetConversationStudentId(conversationId),
                TeacherId = this.conversationService.GetConversationTeacherId(conversationId)
            };

            return mistake;
        }
    }
}
