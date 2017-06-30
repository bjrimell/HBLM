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
                // Mistake Mappings
                cfg.CreateMap<Data.Mistake, Domain.Entities.Mistake>();
                cfg.CreateMap<Domain.Entities.Mistake, Data.Mistake>();
                cfg.CreateMap<Data.getTopMistakesByLanguageId_Result, Domain.Entities.Mistake>();
                cfg.CreateMap<Data.getTopMistakesByConversationId_Result, Domain.Entities.Mistake>();
                cfg.CreateMap<Data.vw_MistakesByConversation, Domain.Entities.Mistake>();
                cfg.CreateMap<Data.vw_Mistakes, Domain.Entities.Mistake>();
                cfg.CreateMap<Data.vw_MistakesByStudent, Domain.Entities.Mistake>();
                cfg.CreateMap<Data.vw_MistakesByLanguage, Domain.Entities.Mistake>();

                // Conversation Mappings
                cfg.CreateMap<Domain.Entities.Conversation, Data.Conversation>();
                cfg.CreateMap<Data.Conversation, Domain.Entities.Conversation>();
            });
        }
    }
}
