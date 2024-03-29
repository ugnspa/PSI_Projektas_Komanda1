﻿namespace PSI_Projektas_Komanda1.Repositories
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
			var query = $@"INSERT INTO `users` (Name, Surname, Email, Username, Password, Admin ) 
						VALUES ( ?name, ?surname, ?email, ?username, ?password, ?admin)";

			try
			{
                return (int) Sql.Insert(query, args => {
                    args.Add("?name", user.Name);
                    args.Add("?surname", user.SurName);
                    args.Add("?email", user.Email);
                    args.Add("?username", user.UserName);
                    args.Add("?password", user.Password);
					args.Add("?admin", false);
                });
            }catch(Exception ex)
			{
				return -1;
			}			
		}

		/// <summary>
		/// Checks whether username is already in use.
		/// </summary>
		/// <param name="username">Username to check</param>
		/// <returns>If the user is found - returns true, if the user isn't found - return false</returns>
		public static bool CheckUserExistanceByUsername(string username)
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
                    t.ID = dre.From<int>("id");
                    t.Name = dre.From<string>("Name");
                    t.SurName = dre.From<string>("Name");
                    t.Email = dre.From<string>("Name");
                    t.UserName = dre.From<string>("Name");
                    t.Password = dre.From<string>("Password");
                });
				Console.WriteLine(result.Password);
			}
			catch
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Checks if user exists by username by calling the method CheckUserExistanceByUsername. 
		/// Returns reverse value of CheckUserAvailability, because the logic is opposite.
		/// </summary>
		/// <param name="username">Username to check</param>
		/// <returns>Returns true if username is available, false if the username isn't available</returns>
		public static bool CheckUsernameAvailability(string username)
		{
			return !CheckUserExistanceByUsername(username);
		}

		public static User FindUserByUsername(string username)
		{
			var query = $@"SELECT * FROM `users` WHERE Username = ?username";
			var drc = Sql.Query(query, args =>
			{
				args.Add("?username", username);
			});

			try
			{
				var result = Sql.MapOne<User>(drc, (dre, t) =>
				{
					t.ID = dre.From<int>("id");
					t.Name = dre.From<string>("Name");
					t.SurName = dre.From<string>("Surname");
					t.Email = dre.From<string>("Email");
					t.UserName = dre.From<string>("Username");
					t.Password = dre.From<string>("Password");
				});
				return result;
			}
			catch
			{
				Console.WriteLine("Username '{0}' not found", username);
				return new User();
			}
		}
	}
}
