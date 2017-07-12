using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Common;
using System.Xml.Serialization;
using Hablame.Domain.Entities;

using Hablame.Repositories.Data;
using AutoMapper;

namespace Hablame.Repositories
{
    public class UserRepository : IUserRepository
    {
        private HablameDatabaseEntities db = new HablameDatabaseEntities();

        private string mockUserDataPath = @"D:\Code\priv\language\HBLM\Hablame.Repositories\Content\mock\User.xml";
        public List<User> GetAllMockUsers()
        {
            List<User> users;
            using (var fs = new FileStream(mockUserDataPath, FileMode.Open, FileAccess.Read))
            {
                var serializer = new XmlSerializer(typeof(List<User>));
                users = (List<User>)serializer.Deserialize(fs);
            }

            return users;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            var dbResponse = db.People.ToList();

            return Mapper.Map(dbResponse, users);
        }
    }
}
