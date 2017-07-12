using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Domain.Entities;

using Hablame.Repositories.Data;
using AutoMapper;

namespace Hablame.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        private HablameDatabaseEntities db = new HablameDatabaseEntities();

        public List<Domain.Entities.MistakeType> GetAllMistakeTypes()
        {
            var dbResponse = db.MistakeTypes.ToList();

            var mapTo = new List<Domain.Entities.MistakeType>();

            return Mapper.Map(dbResponse, mapTo);
        }

        public List<Domain.Entities.MistakeTypeConfiguration> GetMistakeTypeConfigurations(Guid teacherGuid)
        {
            var dbResponse = db.MistakeTypeConfigurations.Where(m => m.OwnerId == teacherGuid).ToList();
            var mapTo = new List<Domain.Entities.MistakeTypeConfiguration>();

            return Mapper.Map(dbResponse, mapTo);
        }

        public void AddMistakeType(Domain.Entities.MistakeType mistakeType)
        {
            var dbmistakeType = Mapper.Map(mistakeType, new Data.MistakeType());

            try
            {
                db.MistakeTypes.Add(dbmistakeType);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public bool AddMistakeTypeToGroup(string mistakeTypeId, string mistakeGroupId)
        {
            var mistakeTypeGuid = Guid.Parse(mistakeTypeId);
            var mistakeGroupGuid = Guid.Parse(mistakeGroupId);

            var mistakeTypeGroup = db.MistakeTypeConfigurations.Where(m => m.Id == mistakeGroupGuid).FirstOrDefault();

            if (mistakeTypeGroup.FirstMistakeTypeId == null)
            {
                mistakeTypeGroup.FirstMistakeTypeId = mistakeTypeGuid;
            }

            if (mistakeTypeGroup.SecondMistakeTypeId == null)
            {
                mistakeTypeGroup.SecondMistakeTypeId = mistakeTypeGuid;
            }

            if (mistakeTypeGroup.ThirdMistakeTypeId == null)
            {
                mistakeTypeGroup.ThirdMistakeTypeId = mistakeTypeGuid;
            }

            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void AddNewMistakeGroup(string mistakeGroupTitle, string ownerId)
        {
            var ownerGuid = Guid.Parse(ownerId);
            var mistakeTypeConfig = new Domain.Entities.MistakeTypeConfiguration
            {
                Id = Guid.NewGuid(),
                Name = mistakeGroupTitle,
                OwnerId = ownerGuid
            };

            try
            {
                db.MistakeTypeConfigurations.Add(Mapper.Map(mistakeTypeConfig, new Data.MistakeTypeConfiguration()));
                db.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
