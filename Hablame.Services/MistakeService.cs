using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hablame.Services.Viewmodels;

namespace Hablame.Services
{
    public class MistakeService : IMistakeService
    {
        public EnteredMistakeViewModel CreateTypedMistakeViewModel()
        {
            var viewModel = new EnteredMistakeViewModel();
            return viewModel;
        }
    }
}
