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

        public List<Domain.Entities.Mistake> GetTopMistakesForLanguage(Guid languageId)
        {
            var mistakes = new List<Domain.Entities.Mistake>();
            var response = db.vw_MistakesByLanguage.Where(m => m.LanguageId == languageId).OrderByDescending(m => m.Count).Take(10);
            return Mapper.Map(response, mistakes);
        }

        public List<Domain.Entities.Mistake> GetLatestSessionMistakes(Guid conversationId)
        {
            var mistakes = new List<Domain.Entities.Mistake>();
            var response = db.vw_MistakesByConversation.Where(m => m.ConversationId == conversationId).Take(10);
            return Mapper.Map(response, mistakes);
        }

        public List<Domain.Entities.Mistake> GetTopMistakesForSession(Guid conversationId)
        {
            var mistakes = new List<Domain.Entities.Mistake>();
            var response = db.vw_MistakesByConversation.Where(m => m.ConversationId == conversationId).OrderByDescending(m => m.Count).Take(10);
            return Mapper.Map(response, mistakes);
        }

        public List<Domain.Entities.Mistake> GetTopMistakesForStudent(Guid studentId)
        {
            var mistakes = new List<Domain.Entities.Mistake>();
            var response = db.vw_MistakesByStudent.Where(m => m.StudentId == studentId).OrderByDescending(m => m.Count).Take(10);
            return Mapper.Map(response, mistakes);
        }

        public bool CreateNewMistake(Domain.Entities.Mistake mistake)
        {
            var dbMistake = new Data.Mistake();
            var dbMistake2 = Mapper.Map(mistake, dbMistake);

            try
            {
                db.Mistakes.Add(dbMistake2);
                db.SaveChanges();
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
    }
}
