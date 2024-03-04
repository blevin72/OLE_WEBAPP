using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OLE_WEBAPP.Models
{
    public class Account : IdentityUser
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Username")]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [ForeignKey("Email")]
        [EmailAddress]
        [Column("email")]
        public string Email { get; set; }

        [Column("hash")]
        public string Hash { get; set; }

        [Column("salt")]
        public string Salt { get; set; }

        [Column("account creation date")]
        public DateTime AccountCreationDate { get; set; }

        [Column("last login date")]
        public DateTime LastLoginDate { get; set; }

        public enum Status { active, inactive }

        [Column("email_subscription")]
        public int EmailSubscription { get; set; }

        // Navigation property for FriendsList
        public virtual ICollection<FriendsList> FriendsList1 { get; set; }
        public virtual ICollection<FriendsList> FriendsList2 { get; set; }

        // Navigation property for FriendRequest
        public virtual ICollection<FriendRequest> SentFriendRequests { get; set; }
        public virtual ICollection<FriendRequest> ReceivedFriendRequests { get; set; }
    }
}