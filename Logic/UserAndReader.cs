namespace Logic
{
    public class UserAndReader
    {
        public DataBase.user newUser { set; get; }
        public DataBase.reader newReader { set; get; }

        public UserAndReader()
        {
            newUser = new DataBase.user();
            newReader = new DataBase.reader();
        }
    }
}
