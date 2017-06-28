using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Domain.Entities;

namespace Hablame.Repositories
{
    public interface IMistakeRepository
    {
        List<Mistake> GetAllMistakes();

        List<Mistake> GetTopMistakesForLanguage(string languageName);

        List<Mistake> GetLatestSessionMistakes(string conversationId);

        List<Mistake> GetTopMistakesForSession(string conversationId);
    }
}
