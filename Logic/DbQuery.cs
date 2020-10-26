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
        public static LibraryEntities db;
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

        public static List<user> listReaders()
        {
            return LibraryEntities.GetContext().users.Where(p => p.role == 3).ToList();
        }

        public static List<user> listLibrarians()
        {
            return LibraryEntities.GetContext().users.Where(u => u.role == 2).ToList();
        }

        public List<book> listLiterature()
        {
            return LibraryEntities.GetContext().books.ToList();
        }

        public static void addReader(reader currentReader)
        {
            LibraryEntities.GetContext().readers.Add(currentReader);
            //LibraryEntities.GetContext().users.Add(currentReader.user);
            try
            {
                LibraryEntities.GetContext().SaveChanges();
                MessageBox.Show("Save");
            }
            catch
            {
                MessageBox.Show("bad");
            }
        }

        public static void addLibrarian(user currentUser)
        {
            LibraryEntities.GetContext().users.Add(currentUser);
            try
            {
                LibraryEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void changeReader()
        {
            //LibraryEntities.GetContext().readers.
        }
    }
}
