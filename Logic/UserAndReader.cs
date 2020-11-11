namespace Logic
{
    /// <summary>
    /// Класс для объединения таблиц пользователя и читателя
    /// </summary>
    public class UserAndReader
    {
        public DataBase.User newUser { set; get; }
        public DataBase.Reader newReader { set; get; }

        public UserAndReader()
        {
            newUser = new DataBase.User();
            newReader = new DataBase.Reader();
        }
    }
}
