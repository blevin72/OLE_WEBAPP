using System;
namespace OLE_WEBAPP.Models
{
	public class FriendRequest
	{
		public int RequestId { get; set; }
		public int SenderId { get; set; }
		public int ReceiverId { get; set; }
		public enum Status
		{
			Pending,
			Accepted,
			Declined
		}
		public DateTime RequestTimeStamp { get; set; }
	}
}

