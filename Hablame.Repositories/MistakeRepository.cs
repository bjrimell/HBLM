using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Domain.Entities;
using System.Xml.Serialization;
using System.IO;

using Hablame.Repositories.Data;


namespace Hablame.Repositories
{
    public class MistakeRepository : IMistakeRepository
    {

        private string mockUserDataPath = @"D:\Code\priv\language\HBLM\Hablame.Repositories\Content\mock\Mistakes.xml";

        public List<Domain.Entities.Mistake> GetAllMistakes()
        {
            bool useMockData = false;
            List<Domain.Entities.Mistake> allMistakes = new List<Domain.Entities.Mistake>();

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
                var allMistakesFromDB = db.Mistakes;
                allMistakes = allMistakesFromDb
            }

            return allMistakes;
        }

        public List<Mistake> GetTopMistakesForLanguage(string languageName)
        {
            var allMistakes = this.GetAllMistakes();
            return allMistakes.Where(m => m.LanguageId == languageName).ToList();
        }

        public List<Mistake> GetLatestSessionMistakes(string conversationId)
        {
            var allMistakes = this.GetAllMistakes();
            return allMistakes.Where(m => m.ConversationId == conversationId).ToList();
        }

        public List<Mistake> GetTopMistakesForSession(string conversationId)
        {
            HablameDatabaseEntities db = new HablameDatabaseEntities();
            var allMistakes = db.Mistakes.Where(m => m.ConversationId == conversationId);

            var allMistakes = this.GetAllMistakes();
            return allMistakes.Where(m => m.ConversationId == conversationId).ToList();
        }
    }
}
