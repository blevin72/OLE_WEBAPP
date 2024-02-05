using System;
using Microsoft.EntityFrameworkCore;

namespace OLE_WEBAPP.Data
{
	public class AppDbContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost:8889;Database=UnityAccess;User=root;Password=root";

            var serverVersion = new MySqlServerVersion(new Version(5, 7, 39));
            optionsBuilder.UseMySql(connectionString, serverVersion);
            base.OnConfiguring(optionsBuilder);
        }
    }
}

