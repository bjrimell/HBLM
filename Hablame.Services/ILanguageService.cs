using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Hablame.Domain.Entities;

namespace Hablame.Services
{
    public interface ILanguageService
    {
        List<Language> GetAllLanguages();
        List<SelectListItem> GetLanguageSelectList();
    }
}
