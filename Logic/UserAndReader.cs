namespace Logic
{
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
