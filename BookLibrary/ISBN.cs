using System;

namespace BookLibrary
{
    public static class ISBN
    {
        public static int GetUniqueCode(string numbers)
        {
            int sum = 0;
            int iterator = 10;
            foreach (char simbol in numbers)
            {
                sum += Convert.ToInt32(Convert.ToString(simbol)) * iterator;
                iterator--;
            }
            sum = 11 - (sum % 11);
            return sum;
        }

        public static string GetGeneratedISBN()
        {
            Random rand = new Random();
            string code = "";
            int countryCode = rand.Next(0, 10);
            int publisherCode = rand.Next(0, 9999999);

            string uniqueCode = "";
            for (int i = 0; i < 8 - publisherCode.ToString().Length; i++)
            {
                uniqueCode += rand.Next(0, 10);
            }
            code += countryCode.ToString() + publisherCode.ToString() + uniqueCode.ToString();
            
            return $"{countryCode}-{publisherCode}-{uniqueCode}-{GetUniqueCode(code)}";
        }

        public static bool ValidationISBN(string isbn)
        {
            if (isbn.Length < 10 || isbn.Length > 10)
                return false;

            if (GetUniqueCode(isbn) != Convert.ToInt32(isbn[9]))
                return false;

            return true;
        }

    }
}
