﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Класс для работы с паролями
    /// </summary>
    public static class PasswordHelper
    {
        /// <summary>
        /// Класс для генерации пароля от 6 до 12 символов
        /// </summary>
        /// <returns>Возвращает сгенерированный пароль (string)</returns>
        public static string GetGeneratedPassword()
        {
            Random rand = new Random();
            int countSimbols = rand.Next(6, 13);
            char simbol = new char();
            string password = "";
            for (int i = 0; i < countSimbols; i++)
            {
                if (i % 2 == 0)
                    simbol = (char)rand.Next(97, 122);
                else
                    simbol = (char)rand.Next(33, 64);
                password += simbol;
            }
            return password;
        }

        /// <summary>
        /// Класс для шифрования пароля
        /// </summary>
        /// <param name="password"></param>
        /// <returns>Возвращает зашифрованный пароль MD5 (Base64String)</returns>
        public static string GetEncryptedPassword(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
    }
}
