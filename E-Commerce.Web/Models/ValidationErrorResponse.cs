﻿namespace E_Commerce.Web.Models
{
	public class ValidationErrorResponse
	{
		public string Title { get; set; }
		public Dictionary<string, string[]> Errors { get; set; }
	}
}
