using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Domain.Entities;
using System.Xml.Serialization;
using System.IO;

using System.Web.Mvc;

using Hablame.Repositories.Data;

using AutoMapper;

namespace Hablame.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private HablameDatabaseEntities db = new HablameDatabaseEntities();
        private string mockUserDataPath = @"D:\Code\priv\language\HBLM\Hablame.Repositories\Content\mock\Conversations.xml";

        public string CreateNewConversation()
        {
            // TODO:
            return "10766ac7-a101-4265-9233-16c50c6f6186";
        }

        public Domain.Entities.Conversation RetrieveConversation(Guid sessionId)
        {
            var response = db.Conversations.FirstOrDefault(m => m.Id == sessionId);

            var conversation = new Domain.Entities.Conversation();

            return Mapper.Map(response, conversation);
        }

        public string CreateNewConversation(Domain.Entities.Conversation conversation)
        {
            var dbConversation = new Data.Conversation();
            var dbConversation2 = Mapper.Map(conversation, dbConversation);

            try
            {
                db.Conversations.Add(dbConversation2);
                db.SaveChanges();
                return dbConversation2.Id.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Domain.Entities.MistakeTypeConfiguration> GetAvailableMistakeTypeSettings(Guid teacherId)
        {
            var dbResponse = db.MistakeTypeConfigurations.Where(m => m.OwnerId == teacherId).ToList();

            var configurations = new List<Domain.Entities.MistakeTypeConfiguration>();

            return Mapper.Map(dbResponse, configurations);
        }

        public Domain.Entities.MistakeTypeConfiguration GetConversationMistakeTypeSettings(Guid configId)
        {
            var dbResponse = db.MistakeTypeConfigurations.Where(m => m.Id == configId).FirstOrDefault();
            var config = new Domain.Entities.MistakeTypeConfiguration();

            return Mapper.Map(dbResponse, config);
        }

        public void CreateNewMistakeTypeConfig(Domain.Entities.MistakeTypeConfiguration mistakeTypeConfiguration)
        {
            var dbmistakeTypeConfig = new Data.MistakeTypeConfiguration();

            var dbmistakeTypeConfig2 = Mapper.Map(mistakeTypeConfiguration, dbmistakeTypeConfig);

            try
            {
                db.MistakeTypeConfigurations.Add(dbmistakeTypeConfig2);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public List<ConversationSummary> GetRecentConversationSummaryForTeacher(string teacherId)
        {
            var teacherGuid = Guid.Parse(teacherId);
            var dbResponse = db.vw_ConversationSummary.Where(m => m.TeacherId == teacherGuid).ToList().OrderByDescending(m => m.StartDateTime).Take(10);
            var convos = new List<ConversationSummary>();

            return Mapper.Map(dbResponse, convos);
        }

        public ConversationSummary GetConversationReport(string conversationId)
        {
            var conversationGuid = Guid.Parse(conversationId);
            var dbResponse = db.vw_ConversationSummary.Where(m => m.ConversationId == conversationGuid).FirstOrDefault();
            var conversationReport = new ConversationSummary();

            return Mapper.Map(dbResponse, conversationReport);
        }
    }
}
