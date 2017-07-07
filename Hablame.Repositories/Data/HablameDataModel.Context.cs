﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hablame.Repositories.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HablameDatabaseEntities : DbContext
    {
        public HablameDatabaseEntities()
            : base("name=HablameDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Conversation> Conversations { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LanguageFamily> LanguageFamilies { get; set; }
        public virtual DbSet<Mistake> Mistakes { get; set; }
        public virtual DbSet<MistakeMade> MistakeMades { get; set; }
        public virtual DbSet<MistakeType> MistakeTypes { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<vw_Mistakes> vw_Mistakes { get; set; }
        public virtual DbSet<vw_MistakesByConversation> vw_MistakesByConversation { get; set; }
        public virtual DbSet<vw_MistakesByLanguage> vw_MistakesByLanguage { get; set; }
        public virtual DbSet<vw_MistakesByStudent> vw_MistakesByStudent { get; set; }
        public virtual DbSet<vw_MistakeMadeSummary> vw_MistakeMadeSummary { get; set; }
        public virtual DbSet<MistakeAssignedMistakeType> MistakeAssignedMistakeTypes { get; set; }
        public virtual DbSet<MistakeTypeConfiguration> MistakeTypeConfigurations { get; set; }
    
        public virtual ObjectResult<getTopMistakesByLanguageId_Result> getTopMistakesByLanguageId(Nullable<System.Guid> languageId)
        {
            var languageIdParameter = languageId.HasValue ?
                new ObjectParameter("languageId", languageId) :
                new ObjectParameter("languageId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getTopMistakesByLanguageId_Result>("getTopMistakesByLanguageId", languageIdParameter);
        }
    
        public virtual ObjectResult<getTopMistakesByConversationId_Result> getTopMistakesByConversationId(Nullable<System.Guid> conversationId)
        {
            var conversationIdParameter = conversationId.HasValue ?
                new ObjectParameter("conversationId", conversationId) :
                new ObjectParameter("conversationId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getTopMistakesByConversationId_Result>("getTopMistakesByConversationId", conversationIdParameter);
        }
    }
}
