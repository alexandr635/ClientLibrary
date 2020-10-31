using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBase;
using System.Windows;
using System.Security.Cryptography;

namespace Logic
{
    public class DbQuery
    {
        public static LibraryEntities db;

        public static user Authorization(string login, string password)
        {
            user result = null;
            using (LibraryEntities db = new LibraryEntities())
            {
                foreach (var currentUser in db.users)
                {
                    if (login == currentUser.login)
                    {
                        MD5 md5 = MD5.Create();
                        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                        if (Convert.ToBase64String(hash) == currentUser.password)
                            result = currentUser;
                        break;
                    }
                }
            }
            return result;
        }

        public static List<user> ListReaders()
        {
            return LibraryEntities.GetContext().users.Where(p => p.role == 3).ToList();
        }

        public static List<user> ListLibrarians()
        {
            return LibraryEntities.GetContext().users.Where(u => u.role == 2).ToList();
        }

        public static List<book> ListLiterature()
        {
            return LibraryEntities.GetContext().books.ToList();
        }

        public static void AddReader(UserAndReader pers)
        {
            LibraryEntities.GetContext().readers.Add(pers.newReader);
            try
            {
                LibraryEntities.GetContext().SaveChanges();
                pers.newUser.id_reader = LibraryEntities.GetContext().readers.ToList().Last().id;
                LibraryEntities.GetContext().users.Add(pers.newUser);
                try
                {
                    LibraryEntities.GetContext().SaveChanges();
                    MessageBox.Show("Пользователь добавлен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void AddLibrarian(user currentUser)
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

        public static void ChangeReader(user changeUser)
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                user change = db.users.Where(u => u.id_user == changeUser.id_user).FirstOrDefault();
                try
                {
                    change.login = changeUser.login;
                    change.password = changeUser.password;
                    change.id_reader = changeUser.id_reader;
                    change.id_user = changeUser.id_user;
                    change.locked = changeUser.locked;
                    change.role = changeUser.role;

                    change.reader.name = changeUser.reader.name;
                    change.reader.patronymic = changeUser.reader.patronymic;
                    change.reader.surname = changeUser.reader.surname;
                    change.reader.id = changeUser.reader.id;
                    change.reader.birth_date = changeUser.reader.birth_date;
                    change.reader.phone = changeUser.reader.phone;
                    change.reader.employee = changeUser.reader.employee;
                    change.reader.rating = changeUser.reader.rating;

                    db.SaveChanges();
                    MessageBox.Show("Пользователь изменен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static void DeleteReader(user deleteUser)

        {
            using (DataBase.LibraryEntities db = new LibraryEntities())
            {
                try
                {
                    user deleteUsr = db.users.Where(u => u.id_user == deleteUser.id_user).FirstOrDefault();
                    db.users.Remove(deleteUsr);

                    reader deleteRdr = db.readers.Where(r => r.id == deleteUser.reader.id).FirstOrDefault();
                    db.readers.Remove(deleteRdr);

                    db.SaveChanges();
                    MessageBox.Show("Пользователь удален!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
