using System;

namespace OLE_WEBAPP.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public enum Status { active, inactive }
        public int EmailSubscription { get; set; }
    }
}

