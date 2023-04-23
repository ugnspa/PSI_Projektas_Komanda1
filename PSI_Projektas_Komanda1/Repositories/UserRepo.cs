namespace PSI_Projektas_Komanda1.Repositories
{
	public class UserRepo
	{
		/// <summary>
		/// Method to insert user into database. 
		/// ALWAYS MAKE SURE TO CHECK WHETHER USERNAME IS ALREADY IN USE VIA FindByUsername() method
		/// ID is always auto incremented.
		/// </summary>
		/// <param name="user">User to insert</param>
		/// <returns></returns>
		public static int InsertUser(User user)
		{
			var query = $@"INSERT INTO `users` (Name, Surname, Email, Username, Password ) 
						VALUES ( ?name, ?surname, ?email, ?username, ?password)";

			Sql.Insert(query, args => {
				args.Add("?name", user.Name);
				args.Add("?surname", user.SurName);
				args.Add("?email", user.Email);
				args.Add("?username", user.UserName);
				args.Add("?password", user.Password);
			});
			return 0;
		}

		/// <summary>
		/// Finds if a user using certain username is already registered. TWO USERS CAN NOT HAVE THE SAME USERNAME
		/// </summary>
		public static bool FindUserByUsername(string username)
		{
			var query = $@"SELECT * FROM `users` WHERE Username = ?username";
			var drc = Sql.Query(query, args =>
			{
				args.Add("?username", username);
			});

			var result = new User();
			try
			{
				result = Sql.MapOne<User>(drc, (dre, t) =>
				{
					t.ID = dre.From<int>("id_User");
					t.Name = dre.From<string>("Name");
					t.SurName = dre.From<string>("Name");
					t.Email = dre.From<string>("Name");
					t.UserName = dre.From<string>("Name");
					t.Password = dre.From<string>("Password");
				});
			}
			catch
			{
				return false;
			}

			if (result == null)
				return false;
			return true;
		}
	}
}
