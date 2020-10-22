using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using System.Windows;

namespace Logic
{
    public class DbQuery
    {
        public static user authorization(string login, string password)
        {
            user result = null;
            using (LibraryEntities db = new LibraryEntities())
            {
                foreach (var currentUser in db.users)
                {
                    if (login == currentUser.login && password == currentUser.password)
                    {
                        result = currentUser;
                    }
                }
            }
            return result;
        }

        public List<reader> listReaders()
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                return db.readers.ToList();
            }
        }

        public List<user> listLibrarians()
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                List<user> listUser = new List<user>();
                foreach (var currentUser in db.users)
                    if (currentUser.role == 2)
                        listUser.Add(currentUser);
                return listUser;
            }
        }

        public List<book> listLiterature()
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                return db.books.ToList();
            }
        }
    }
}
