﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataBase;

namespace Logic
{
    /// <summary>
    /// Класс для обращения к базе данных
    /// </summary>
    public class DbQuery
    {
        public static LibraryEntities db;

        /// <summary>
        /// Метод для авторизации пользователя 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>Возвращает экземпляр типа User</returns>
        public static User Authorization(string login, string password)
        {
            User result = null;
            var user = new LibraryEntities().Users.Where(u => u.login == login).FirstOrDefault();
            if (user != null && PasswordHelper.GetEncryptedPassword(password) == user.password)
                result = user;

            return result;
        }

        /// <summary>
        /// Метод для поиска всех читателей
        /// </summary>
        /// <returns>Возвращает список читателей типа User</returns>
        public static List<User> ListReaders()
        {
            return LibraryEntities.GetContext().Users.Where(p => p.role == 3).ToList();
        }

        /// <summary>
        /// Метод для поиска всех библиотекарей
        /// </summary>
        /// <returns>Возвращает список читателей типа User</returns>
        public static List<User> ListLibrarians()
        {
            return LibraryEntities.GetContext().Users.Where(u => u.role == 2).ToList();
        }

        /// <summary>
        /// Метод для поиска всех книг в библиотеке
        /// </summary>
        /// <returns>Возвращает список книг типа Book</returns>
        public static List<Book> ListLiterature()
        {
            return LibraryEntities.GetContext().Books.ToList();
        }

        /// <summary>
        /// Метод для добавления в бд читателя и пользователя
        /// </summary>
        /// <param name="pers"></param>
        /// <returns>Возвращает Null если данные добавлены или ошибку, если данные не добавились</returns>
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

        /// <summary>
        /// Метод для добавления в бд пользователя
        /// </summary>
        /// <param name="currentUser"></param>
        /// <returns>Возвращает Null если данные добавлены или ошибку, если данные не добавились</returns>
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

        /// <summary>
        /// Метод для изменения записи пользователя
        /// </summary>
        /// <param name="changeUser"></param>
        /// <returns>Возвращает Null если данные изменены или ошибку, если данные не изменились</returns>
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

        /// <summary>
        /// Метод для удаления читателя и его записи в таблице пользователей
        /// </summary>
        /// <param name="deleteUser"></param>
        /// <returns>Возвращает Null, если пользователь удален или ошибку, если данные не изменены</returns>
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

        /// <summary>
        /// Метод для добавления бронирования книги
        /// </summary>
        /// <param name="currentBookid"></param>
        /// <param name="currentUserid"></param>
        /// <returns>Возвращает Null если данные добавлены или ошибку, если данные не добавились</returns>
        public static Exception AddBooking(int currentBookid, int currentUserid)
        {
            try
            {
                BookingJournal addBook = new BookingJournal()
                {
                    idBook = currentBookid,
                    idReader = currentUserid,
                    startDate = DateTime.Now,
                    endDate = DateTime.Now.AddMonths(5),
                    bookingCode = PasswordHelper.GetGeneratedPassword(),
                    status = 1
                };
                LibraryEntities.GetContext().BookingJournals.Add(addBook);
                LibraryEntities.GetContext().SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        /// <summary>
        /// Метод для поиска всех забронированных книг у читателя
        /// </summary>
        /// <param name="idReader"></param>
        /// <returns>Возвращает список книг типа BookingJournal</returns>
        public static List<BookingJournal> ListBooking(int idReader)
        {
            return DataBase.LibraryEntities.GetContext().BookingJournals.Where(b => b.idReader == idReader).ToList();
        }

        /// <summary>
        /// Метод для получения списка жанров
        /// </summary>
        /// <returns>Возвращает List<string></returns>
        public static List<string> ListGenre()
        {
            var listGenres = DataBase.LibraryEntities.GetContext().Genres.ToList();
            List<string> listResult = new List<string>();
            foreach (var genre in listGenres)
                listResult.Add(genre.genreName);

            return listResult;
        }

        /// <summary>
        /// Метод для получения списка авторов
        /// </summary>
        /// <returns>Возвращает List<string></returns>
        public static List<string> ListAuthor()
        {
            var listAuthor = LibraryEntities.GetContext().Authors.ToList();
            List<string> listResult = new List<string>();
            foreach (var author in listAuthor)
                listResult.Add(author.authorName);

            return listResult;
        }

        /// <summary>
        /// Метод для добавления книги в бд
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Возвращает Null если данные добавлены или ошибку, если данные не добавились</returns>
        public static Exception AddBook(Book book)
        {
            try
            {
                LibraryEntities.GetContext().Books.Add(book);
                LibraryEntities.GetContext().SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public static Exception DeleteBook(int bookId)
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                try
                {
                    Book deleteBook = db.Books.Where(b => b.id == bookId).FirstOrDefault();
                    db.Books.Remove(deleteBook);

                    db.SaveChanges();
                    return null;
                }
                catch (Exception ex)
                {
                    return ex;
                }
            }
        }

        public static Exception ChangeBook(Book book)
        {
            try
            {
                Book change = LibraryEntities.GetContext().Books.Where(b => b.id == book.id).FirstOrDefault();
                change = book;
                LibraryEntities.GetContext().SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
