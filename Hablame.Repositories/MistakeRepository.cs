using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Domain.Entities;
using System.Xml.Serialization;
using System.IO;

using Hablame.Repositories.Data;

using AutoMapper;


namespace Hablame.Repositories
{
    public class MistakeRepository : IMistakeRepository
    {
        private HablameDatabaseEntities db = new HablameDatabaseEntities();
        private string mockUserDataPath = @"D:\Code\priv\language\HBLM\Hablame.Repositories\Content\mock\Mistakes.xml";

        public MistakeRepository()
        {
            var mapper = new Mapping.EntityMapper();
            mapper.Initialize();
        }

        public List<Domain.Entities.Mistake> GetAllMistakes()
        {
            bool useMockData = false;
            var allMistakes = new List<Domain.Entities.Mistake>();

            if (useMockData)
            {
                using (var fs = new FileStream(mockUserDataPath, FileMode.Open, FileAccess.Read))
                {
                    var serializer = new XmlSerializer(typeof(List<Domain.Entities.Mistake>));
                    allMistakes = (List<Domain.Entities.Mistake>)serializer.Deserialize(fs);
                }
            }
            else
            {
                var allMistakesFromDb = db.Mistakes;

                var mistakeList = new List<Domain.Entities.Mistake>();

                allMistakes = Mapper.Map(allMistakesFromDb, mistakeList);
            }

            return allMistakes;
        }

        public List<Domain.Entities.Mistake> GetTopRemarksForLanguage(Guid languageId, bool isPraise)
        {
            var mistakes = new List<Domain.Entities.Mistake>();
            var response = db.vw_MistakesByLanguage.Where(m => m.LanguageId == languageId && m.IsPraise == isPraise).OrderByDescending(m => m.Count).Take(10);
            return Mapper.Map(response, mistakes);
        }

        public List<Domain.Entities.MistakeMade> GetLatestSessionRemarks(Guid conversationId, bool isPraise)
        {
            var mistakes = new List<Domain.Entities.MistakeMade>();
            var response = db.vw_MistakeMadeSummary.Where(m => m.ConversationId == conversationId && m.IsPraise == isPraise).OrderByDescending(m => m.DateTime).Take(10);
            return Mapper.Map(response, mistakes);
        }

        public List<Domain.Entities.Mistake> GetTopRemarksForSession(Guid conversationId, bool isPraise)
        {
            var mistakes = new List<Domain.Entities.Mistake>();
            var response = db.vw_MistakesByConversation.Where(m => m.ConversationId == conversationId && m.IsPraise == isPraise).OrderByDescending(m => m.Count).Take(10);
            return Mapper.Map(response, mistakes);
        }

        public List<Domain.Entities.Mistake> GetTopRemarksForStudent(Guid studentId, bool isPraise)
        {
            var mistakes = new List<Domain.Entities.Mistake>();
            var response = db.vw_MistakesByStudent.Where(m => m.StudentId == studentId && m.IsPraise == isPraise).OrderByDescending(m => m.Count).Take(10);
            return Mapper.Map(response, mistakes);
        }

        public bool CreateNewMistake(Domain.Entities.Mistake mistake, IEnumerable<Domain.Entities.MistakeType> selectedMistakeTypes)
        {
            var dbMistake = new Data.Mistake();
            var dbMistake2 = Mapper.Map(mistake, dbMistake);

            try
            {
                db.Mistakes.Add(dbMistake2);
                db.SaveChanges();
                
                foreach (var item in selectedMistakeTypes)
                {
                    var mistakeAssignedMistakeType = new Data.MistakeAssignedMistakeType
                    {
                        Id = Guid.NewGuid(),
                        MistakeId = dbMistake2.Id,
                        MistakeTypeId = item.Id
                    };

                    db.MistakeAssignedMistakeTypes.Add(mistakeAssignedMistakeType);
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<Domain.Entities.MistakeType> GetMistakeTypes(Guid languageId)
        {
            var mistakeTypes = new List<Domain.Entities.MistakeType>();
            var response = db.MistakeTypes.Where(m => m.LanguageId == languageId);
            return Mapper.Map(response, mistakeTypes);
        }

        public void CreateNewMistakeMade(Domain.Entities.MistakeMade mistakeMade)
        {
            var dbMistakeMade = new Data.MistakeMade();
            var dbMistakeMadeToInsert = Mapper.Map(mistakeMade, dbMistakeMade);

            try
            {
                db.MistakeMades.Add(dbMistakeMadeToInsert);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public Domain.Entities.MistakeMade GetMistakeMadeSummaryById(Guid mistakeId)
        {
            var mistakeMade = new Domain.Entities.MistakeMade();
            var response = db.vw_MistakeMadeSummary.Where(m => m.MistakeId == mistakeId).FirstOrDefault();
            return Mapper.Map(response, mistakeMade);
        }

        public List<Domain.Entities.MistakeType> GetSelectedMistakeTypes(IEnumerable<string> selectedMistakeTypes, int rating)
        {
            var mistakeTypes = new List<Domain.Entities.MistakeType>();

            var guidList = selectedMistakeTypes.Select(Guid.Parse).ToList();
            var response = db.MistakeTypes.Where(m => guidList.Contains(m.Id)).ToList();
            return Mapper.Map(response, mistakeTypes);
        }

        public List<Domain.Entities.Mistake> GetAllRemarksByConvoId(string conversationId, bool isPraise)
        {
            var conversationGuid = Guid.Parse(conversationId);
            var mistakes = new List<Domain.Entities.Mistake>();
            var response = db.Mistakes.Where(m => m.ConversationId == conversationGuid && m.IsPraise == isPraise);
            return Mapper.Map(response, mistakes);
        }
    }
}
