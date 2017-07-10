using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

namespace Hablame.Repositories.Mapping
{
    public class EntityMapper
    {
        public EntityMapper()
        {
        }

        public void Initialize()
        {
            Mapper.Initialize(
            cfg =>
            {
                // Conversation Reports Mappings
                cfg.CreateMap<Data.vw_ConversationSummary, Domain.Entities.ConversationSummary>();

                // Conversation Mappings
                cfg.CreateMap<Domain.Entities.Conversation, Data.Conversation>();
                cfg.CreateMap<Data.Conversation, Domain.Entities.Conversation>();

                // MistakeTypeOptionsConfig Mappings
                cfg.CreateMap<Domain.Entities.MistakeTypeOptionsConfiguration, Data.MistakeTypeConfiguration>();
                cfg.CreateMap<Data.MistakeTypeConfiguration, Domain.Entities.MistakeTypeConfiguration>();
                cfg.CreateMap<Domain.Entities.MistakeTypeConfiguration, Data.MistakeTypeConfiguration>();

                // Mistake Type Mappings
                cfg.CreateMap<Domain.Entities.MistakeType, Data.MistakeType>();
                cfg.CreateMap<Data.MistakeType, Domain.Entities.MistakeType>();

                // Mistake Mappings
                cfg.CreateMap<Data.Mistake, Domain.Entities.Mistake>();
                cfg.CreateMap<Domain.Entities.Mistake, Data.Mistake>();
                cfg.CreateMap<Data.getTopMistakesByLanguageId_Result, Domain.Entities.Mistake>();
                cfg.CreateMap<Data.getTopMistakesByConversationId_Result, Domain.Entities.Mistake>();
                cfg.CreateMap<Data.vw_MistakesByConversation, Domain.Entities.Mistake>();
                cfg.CreateMap<Data.vw_Mistakes, Domain.Entities.Mistake>();
                cfg.CreateMap<Data.vw_MistakesByStudent, Domain.Entities.Mistake>();
                cfg.CreateMap<Data.vw_MistakesByLanguage, Domain.Entities.Mistake>();

                // Mistake Made Mappings
                cfg.CreateMap<Domain.Entities.MistakeMade, Data.MistakeMade>();
                cfg.CreateMap<Data.MistakeMade, Domain.Entities.MistakeMade>();
                cfg.CreateMap<Data.vw_MistakeMadeSummary, Domain.Entities.MistakeMade>();

            });
        }
    }
}
