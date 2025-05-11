namespace Entities
{
    public class User
    {
        public int UserId { get; set; }
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String UserName { get; set; }

        public String Password { get; set; }


        public User() { }


        public User(string firstName, string lastName, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
        }
    }
}
