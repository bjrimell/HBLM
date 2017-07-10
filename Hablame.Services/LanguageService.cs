using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Hablame.Domain.Entities;

namespace Hablame.Services
{
    public class LanguageService : ILanguageService
    {
        public List<Language> GetAllLanguages()
        {
            var languageList = new List<Language>();

            var english = new Language
            {
                Id = Guid.Parse("f4e4b27d-eb24-43de-b9d7-f67a73ae83f8"),
                Name = "English",
                Family = "Germanic"
            };

            var spanish = new Language
            {
                Id = Guid.Parse("83189BC7-23EB-4414-B0D1-2791264AE51D"),
                Name = "Spanish",
                Family = "Romantic"
            };

            languageList.Add(english);
            languageList.Add(spanish);

            return languageList;
        }
        public List<SelectListItem> GetLanguageSelectList()
        {
            var allLanguages = this.GetAllLanguages();

            var items = new List<SelectListItem>();

            foreach (var item in allLanguages)
            {
                items.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            return items;
        }

        public Language GetLanguageById(Guid languageGuid)
        {
            var thisLanguage = this.GetAllLanguages().Where(m => m.Id == languageGuid).FirstOrDefault();
            return thisLanguage;
        }
    }
}
