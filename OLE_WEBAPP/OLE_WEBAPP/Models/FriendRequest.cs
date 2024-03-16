using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OLE_WEBAPP.Models
{
	public class FriendRequest
    {
        [Key]
        public int RequestId { get; set; }

        // Foreign key properties
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }

        // Navigation properties
        [ForeignKey("SenderId")]
        public virtual Account Sender { get; set; }

        [ForeignKey("ReceiverId")]
        public virtual Account Receiver { get; set; }

        public enum Status
        {
            Pending,
            Accepted,
            Declined
        }
        public DateTime RequestTimeStamp { get; set; }
    }
}