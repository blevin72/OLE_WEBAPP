using System;
using System.ComponentModel.DataAnnotations;

namespace OLE_WEBAPP.Models
{
	public class Player
	{
		[Key]
		public int id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public DateOnly Dob { get; set; }

		public byte[] Avatar { get; set; }

		public enum Language
		{
			English,
			Spanish,
			French,
			German,
			Japanese,
			Chinese,
			Russian,
			Italian
		}
	}
}