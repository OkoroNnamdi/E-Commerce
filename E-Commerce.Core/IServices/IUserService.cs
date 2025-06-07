using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.DB.Entities;

namespace E_Commerce.Core.IServices
{
	public  interface IUserService
	{
		Task<User?> AuthenticateAsync(string username, string password);
		Task<User?> FindByUsernameAsync(string username);
		Task<User> RegisterAsync(string username, string password);

	}
}
