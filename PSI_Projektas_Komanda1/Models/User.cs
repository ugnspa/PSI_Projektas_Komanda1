namespace PSI_Projektas_Komanda1.order
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public User(string id, string name, string surname, string email, string username, string password) {
            Id = id;
            Name = name;
            SurName= surname;
            Email = email;
            UserName = username;
            Password = password;
           
        }

        public void ChangePassword(string NewPassword)
        {
            Password = NewPassword;
        }
    }
}
