﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DB.Entities
{
	public  class User
	{
		public int Id { get; set; }
		public string Username { get; set; } = string.Empty;
		public string Password{ get; set; } = string.Empty;
	}
}
