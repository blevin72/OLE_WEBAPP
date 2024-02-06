using System;
using Microsoft.EntityFrameworkCore;
using OLE_WEBAPP.Models;
using Org.BouncyCastle.Asn1.X509;

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

        public DbSet<Accounts> Accounts { get; set; }
    }
}

