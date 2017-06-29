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

        private string mockUserDataPath = @"D:\Code\priv\language\HBLM\Hablame.Repositories\Content\mock\Mistakes.xml";

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
                HablameDatabaseEntities db = new HablameDatabaseEntities();
                var allMistakesFromDb = db.Mistakes;

                var mistakeList = new List<Domain.Entities.Mistake>();

                Mapper.Initialize(
                    cfg =>
                    {
                        cfg.CreateMap<Data.Mistake, Domain.Entities.Mistake>();
                    });

                allMistakes = Mapper.Map(allMistakesFromDb, mistakeList);
                
            }

            return allMistakes;
        }

        public List<Domain.Entities.Mistake> GetTopMistakesForLanguage(string languageName)
        {
            var allMistakes = this.GetAllMistakes();
            return allMistakes.Where(m => m.LanguageId == languageName).ToList();
        }

        public List<Domain.Entities.Mistake> GetLatestSessionMistakes(string conversationId)
        {
            var allMistakes = this.GetAllMistakes();
            return allMistakes.Where(m => m.ConversationId == conversationId).ToList();
        }

        public List<Domain.Entities.Mistake> GetTopMistakesForSession(string conversationId)
        {
            HablameDatabaseEntities db = new HablameDatabaseEntities();

            var allMistakes = this.GetAllMistakes();
            return allMistakes.Where(m => m.ConversationId == conversationId).ToList();
        }
    }
}
