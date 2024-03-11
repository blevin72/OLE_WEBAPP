using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OLE_WEBAPP.Models
{
    [Table("players")]
    public class Player
	{
        public int Id { get; set; }

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

        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}