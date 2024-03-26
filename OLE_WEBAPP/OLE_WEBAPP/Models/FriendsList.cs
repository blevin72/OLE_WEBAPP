using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OLE_WEBAPP.Models;

namespace OLE_WEBAPP.Models
{
    public class FriendsList
    {
        [Key]
        public int FriendshipId { get; set; }

        // Foreign key properties
        public int Account1Id { get; set; }
        public int Account2Id { get; set; }

        // Navigation properties
        [ForeignKey("Account1Id")]
        public virtual Account Account1 { get; set; }

        [ForeignKey("Account2Id")]
        public virtual Account Account2 { get; set; }

        public DateTime FriendshipTimeStamp { get; set; }
    }
}