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
    public class MistakeRepository : IMistakeRepository
    {

        private string mockUserDataPath = @"D:\Code\priv\language\Hablame\Hablame.Repositories\Content\mock\Mistakes.xml";

        public List<Mistake> GetAllMistakes()
        {
            List<Mistake> mistakes;
            using (var fs = new FileStream(mockUserDataPath, FileMode.Open, FileAccess.Read))
            {
                var serializer = new XmlSerializer(typeof(List<Mistake>));
                mistakes = (List<Mistake>)serializer.Deserialize(fs);
            }

            return mistakes;
        }
    }
}
