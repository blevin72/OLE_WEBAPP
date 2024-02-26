using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OLE_WEBAPP.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Username")]
        public string Username { get; set; }

        [Required]
        [ForeignKey("Email")]
        [EmailAddress]
        public string Email { get; set; }

        public string Hash { get; set; }

        public string Salt { get; set; }

        public DateTime AccountCreationDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        public enum Status { active, inactive }

        public int EmailSubscription { get; set; }

        // Navigation property for FriendsList
        public virtual ICollection<FriendsList> FriendsList1 { get; set; }
        public virtual ICollection<FriendsList> FriendsList2 { get; set; }

        // Navigation property for FriendRequest
        public virtual ICollection<FriendRequest> SentFriendRequests { get; set; }
        public virtual ICollection<FriendRequest> ReceivedFriendRequests { get; set; }
    }
}