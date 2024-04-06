using System;
using System.Collections.Generic;
using OLE_WEBAPP.Data;
using OLE_WEBAPP.Interfaces;
using OLE_WEBAPP.Models;

namespace OLE_WEBAPP.Services
{
	public class ForumServices : IForumServices
	{
		private readonly AppDbContext _context;

		public ForumServices(AppDbContext context)
		{
			_context = context;
		}

        public void CreatePost(CommunicationRecord record)
        {
            if (record != null)
            {
                record.TimeSent = DateTime.Now;
                _context.CommunicationRecords.Add(record);
                _context.SaveChanges();
            }
        }

        public IEnumerable<CommunicationRecord> GetExistingPosts()
        {
            return _context.CommunicationRecords.ToList();
        }
    }
}