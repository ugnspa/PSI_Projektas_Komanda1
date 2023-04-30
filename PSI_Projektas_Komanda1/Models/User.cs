public class User
{
	public int ID { get; set; }
	public string Name { get; set; }
	public string SurName { get; set; }
	public string Email { get; set; }

	public string UserName { get; set; }

	public string Password { get; set; }

	//public User(string id, string name, string surname, string email, string username, string password) {
	//    Id = id;
	//    Name = name;
	//    SurName= surname;
	//    Email = email;
	//    UserName = username;
	//    Password = password;

	//}

	public void ChangePassword(string NewPassword)
	{
		Password = NewPassword;
	}
}
