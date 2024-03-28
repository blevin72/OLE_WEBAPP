using System;
using System.Collections.Generic;
using OLE_WEBAPP.Models;

namespace OLE_WEBAPP.Interfaces
{
	public interface IForumServices
	{
		void CreatePost(CommunicationRecord record);
		IEnumerable<CommunicationRecord> GetExistingPosts();
	}
}