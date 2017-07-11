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

        List<Mistake> GetTopRemarksForLanguage(Guid languageId, bool isPraise);

        List<MistakeMade> GetLatestSessionRemarks(Guid conversationId, bool isPraise);

        List<Mistake> GetTopRemarksForSession(Guid conversationId, bool isPraise);

        List<Mistake> GetTopRemarksForStudent(Guid studentId, bool isPraise);

        bool CreateNewMistake(Mistake mistake, IEnumerable<MistakeType> selectedMistakeTypes);

        List<MistakeType> GetMistakeTypes(Guid languageId);

        void CreateNewMistakeMade(MistakeMade mistakeMade);

        MistakeMade GetMistakeMadeSummaryById(Guid mistakeId);

        List<MistakeType> GetSelectedMistakeTypes(IEnumerable<string> selectedMistakeTypes, int rating);

        List<Mistake> GetAllRemarksByConvoId(string conversationId, bool isPraise);

    }
}
