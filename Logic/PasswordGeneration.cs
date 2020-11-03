using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PasswordGeneration
    {
        public static string returnNewPassword()
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
    }
}
