using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace OLE_WEBAPP.Models
{
	public class CommunicationRecord
	{
        [Key]
        public int MessageID { get; set; }

        [Required]
        [StringLength(50)]
        public string Sender { get; set; }

        [Required]
        [StringLength(150)]
        public string Recipients { get; set; }

        [Required]
        [StringLength(150)]
        public string Subject { get; set; }

        [Required]
        [StringLength(5000)]
        public string MessageBody { get; set; }

        public DateTime TimeSent { get; set; }

        // If attachments are stored as byte array in the database
        //public Blob Attachments { get; set; }

        // If attachments are stored as a separate entity (e.g., Attachments table with a foreign key)
        // public ICollection<Attachment> Attachments { get; set; }
    }
}