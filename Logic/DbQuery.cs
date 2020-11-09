using System;
using System.Collections.Generic;
using System.Linq;
using DataBase;

namespace Logic
{
    public class DbQuery
    {
        public static LibraryEntities db;

        public static User Authorization(string login, string password)
        {
            User result = null;
            var user = new LibraryEntities().Users.Where(u => u.login == login).FirstOrDefault();
            if (user != null && PasswordHelper.GetEncryptedPassword(password) == user.password)
               result = user;
            
            return result;
        }

        public static List<User> ListReaders()
        {
            return LibraryEntities.GetContext().Users.Where(p => p.role == 3).ToList();
        }

        public static List<User> ListLibrarians()
        {
            return LibraryEntities.GetContext().Users.Where(u => u.role == 2).ToList();
        }

        public static List<Book> ListLiterature()
        {
            return LibraryEntities.GetContext().Books.ToList();
        }

        public static Exception AddReader(UserAndReader pers)
        {
            LibraryEntities.GetContext().Readers.Add(pers.newReader);
            try
            {
                LibraryEntities.GetContext().SaveChanges();
                pers.newUser.idReader = LibraryEntities.GetContext().Readers.ToList().Last().id;
                LibraryEntities.GetContext().Users.Add(pers.newUser);
                
                LibraryEntities.GetContext().SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
            
        }

        public static Exception AddLibrarian(User currentUser)
        {
            LibraryEntities.GetContext().Users.Add(currentUser);
            try
            {
                LibraryEntities.GetContext().SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public static Exception ChangeReader(User changeUser)
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                User change = db.Users.Where(u => u.idUser == changeUser.idUser).FirstOrDefault();
                try
                {
                    change.login = changeUser.login;
                    change.password = changeUser.password;
                    change.idReader = changeUser.idReader;
                    change.idUser = changeUser.idUser;
                    change.locked = changeUser.locked;
                    change.role = changeUser.role;

                    change.Reader.name = changeUser.Reader.name;
                    change.Reader.patronymic = changeUser.Reader.patronymic;
                    change.Reader.surname = changeUser.Reader.surname;
                    change.Reader.id = changeUser.Reader.id;
                    change.Reader.birthDate = changeUser.Reader.birthDate;
                    change.Reader.phone = changeUser.Reader.phone;
                    change.Reader.employee = changeUser.Reader.employee;
                    change.Reader.rating = changeUser.Reader.rating;

                    db.SaveChanges();
                    return null;
                }
                catch (Exception ex)
                {
                    return ex;
                }
            }
        }

        public static Exception DeleteReader(User deleteUser)
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                try
                {
                    User deleteUsr = db.Users.Where(u => u.idUser == deleteUser.idUser).FirstOrDefault();
                    db.Users.Remove(deleteUsr);

                    Reader deleteRdr = db.Readers.Where(r => r.id == deleteUser.Reader.id).FirstOrDefault();
                    db.Readers.Remove(deleteRdr);

                    db.SaveChanges();
                    return null;
                }
                catch (Exception ex)
                {
                    return ex;
                }
            }
        }

    }
}
