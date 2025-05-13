namespace Bakery
{
    public class LoginUser
    {
            public int UserId { get; set; }


            public String UserName { get; set; }

            public String Password { get; set; }


            public LoginUser() { }


            public LoginUser(string userName, string password)
            {
                UserName = userName;
                Password = password;
            }
        }

}
