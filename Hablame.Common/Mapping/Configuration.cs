using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Domain.Entities;
using Hablame.Repositories.Data;

using AutoMapper;

namespace Hablame.Common.Mapping
{
    public static class Configuration
    {
        public static bool TryConfigure()
        {
            try
            {
                Configure();
            }
            catch (Exception e)
            {
                //Logger.Log(Severity.Fatal, "Mapping Configuration Failed: {0}", e);
                return false;
            }

            return true;
        }

        public static void Configure()
        {
            Mapper.Initialize(
            cfg =>
            {
                cfg.CreateMap<Repositories.Data.Mistake, Domain.Entities.Mistake>();
            });

        }
    }
}
