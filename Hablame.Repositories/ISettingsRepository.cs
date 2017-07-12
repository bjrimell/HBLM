using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Domain.Entities;

namespace Hablame.Repositories
{
    public interface ISettingsRepository
    {
        List<MistakeType> GetAllMistakeTypes();

        List<MistakeTypeConfiguration> GetMistakeTypeConfigurations(Guid teacherGuid);

        void AddMistakeType(MistakeType mistakeType);

        bool AddMistakeTypeToGroup(string mistakeTypeId, string mistakeGroupId);

        void AddNewMistakeGroup(string mistakeGroupTitle, string ownerId);
    }
}
