using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Services.Viewmodels;
using Hablame.Domain.Entities;

namespace Hablame.Services
{
    public interface IMistakeService
    {
        EnteredMistakeViewModel CreateTypedMistakeViewModel();

        MistakeMade CreateMistakeMade(Guid conversationId, int rating, string spokenValue, string correctValue, IEnumerable<string> selectedMistakeTypes, string mistakeId);
    }
}
