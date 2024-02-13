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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship between Account and FriendsList
            modelBuilder.Entity<Account>()
                .HasMany(a => a.FriendsList1)
                .WithOne(fl => fl.Account1)
                .HasForeignKey(fl => fl.Account1Id)
                .OnDelete(DeleteBehavior.Restrict); // Modify this according to your requirement

            modelBuilder.Entity<Account>()
                .HasMany(a => a.FriendsList2)
                .WithOne(fl => fl.Account2)
                .HasForeignKey(fl => fl.Account2Id)
                .OnDelete(DeleteBehavior.Restrict); // Modify this according to your requirement

            // Configure the relationship between Account and FriendRequest
            modelBuilder.Entity<FriendRequest>()
                .HasOne(fr => fr.Sender)
                .WithMany(a => a.SentFriendRequests)
                .HasForeignKey(fr => fr.SenderId)
                .OnDelete(DeleteBehavior.Restrict); // Modify this according to your requirement

            modelBuilder.Entity<FriendRequest>()
                .HasOne(fr => fr.Receiver)
                .WithMany(a => a.ReceivedFriendRequests)
                .HasForeignKey(fr => fr.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict); // Modify this according to your requirement
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<FriendsList> FriendsList { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
    }
}