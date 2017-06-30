﻿using System;
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

        List<Mistake> GetTopMistakesForLanguage(Guid languageId);

        List<Mistake> GetLatestSessionMistakes(Guid conversationId);

        List<Mistake> GetTopMistakesForSession(Guid conversationId);

        List<Mistake> GetTopMistakesForStudent(Guid studentId);

        bool CreateNewMistake(Mistake mistake);
    }
}
