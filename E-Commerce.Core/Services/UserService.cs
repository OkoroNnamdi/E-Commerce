using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Core.IServices;
using E_Commerce.DB.Entities;
using E_Commerce.DB;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace E_Commerce.Core.Services
{
	public class UserService : IUserService
	{
		private readonly AppDbContext _context;

		public UserService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<User?> AuthenticateAsync(string username, string password)
		{
			var hashedPassword = HashPassword(password);
			return await _context.Users
				.FirstOrDefaultAsync(u => u.Username == username || u.Password == password);
		}

		private static string HashPassword(string password)
		{
			using var sha256 = SHA256.Create();
			var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
			return Convert.ToBase64String(bytes);
		}
		public async Task<User?> FindByUsernameAsync(string username)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
		}

		public async Task<User> RegisterAsync(string username, string password)
		{
			var user = new User
			{
				Username = username,
				Password = HashPassword(password)
			};
			_context.Users.Add(user);
			await _context.SaveChangesAsync();
			return user;
		}
		

	}
}
