using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Domain.Entities;
using System.Xml.Serialization;
using System.IO;

namespace Hablame.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private string mockUserDataPath = @"D:\Code\priv\language\HBLM\Hablame.Repositories\Content\mock\Conversations.xml";

        public string CreateNewConversation()
        {
            // TODO:
            return "123456";
        }

        public Conversation RetrieveConversation(string sessionId)
        {
            var conversations = new List<Conversation>();

            using (var fs = new FileStream(mockUserDataPath, FileMode.Open, FileAccess.Read))
            {
                var serializer = new XmlSerializer(typeof(List<Conversation>));
                conversations = (List<Conversation>)serializer.Deserialize(fs);
            }

            return conversations.FirstOrDefault(m => m.ConversationId == sessionId);
        }
    }
}
