namespace ORM.Model
{
    public class Users
    {
        public string Username { set; get; } = String.Empty;
        public string Password { set; get; } = String.Empty;
        public DateTime DateLogin { set; get; } = DateTime.Now;
    }
}
