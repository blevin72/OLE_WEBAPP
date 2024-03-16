using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OLE_WEBAPP.Models;

namespace OLE_WEBAPP.Data
{
    public class AppDbContext : IdentityDbContext<Account>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
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

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>().ToTable("accounts").HasKey(u => u.Id);
            modelBuilder.Entity<Player>().ToTable("players");
            modelBuilder.Entity<FriendsList>().ToTable("friends_list");
            modelBuilder.Entity<FriendRequest>().ToTable("friend_requests");
        }

        // DbSets for application entities
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<FriendsList> FriendsList { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
    }
}












//using System;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using OLE_WEBAPP.Models;
//using Org.BouncyCastle.Asn1.X509;
//using Microsoft.Extensions.Configuration;
//using System.IO;


//namespace OLE_WEBAPP.Data
//{
//    public class AppDbContext : IdentityDbContext<Account>
//    {
//        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
//        {

//        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                // Build configuration
//                var config = new ConfigurationBuilder()
//                    .SetBasePath(Directory.GetCurrentDirectory())
//                    .AddJsonFile("appsettings.json")
//                    .Build();

//                // Get connection string from configuration
//                var connectionString = config.GetConnectionString("DefaultConnection");

//                // Use MySQL provider with specified server version
//                var serverVersion = new MySqlServerVersion(new Version(5, 7, 39));
//                optionsBuilder.UseMySql(connectionString, serverVersion);
//            }

//            base.OnConfiguring(optionsBuilder);
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            // Configure the relationship between Account and FriendsList
//            modelBuilder.Entity<Account>()
//                .HasMany(a => a.FriendsList1)
//                .WithOne(fl => fl.Account1)
//                .HasForeignKey(fl => fl.Account1Id)
//                .OnDelete(DeleteBehavior.Restrict); // Modify this according to your requirement

//            modelBuilder.Entity<Account>()
//                .HasMany(a => a.FriendsList2)
//                .WithOne(fl => fl.Account2)
//                .HasForeignKey(fl => fl.Account2Id)
//                .OnDelete(DeleteBehavior.Restrict); // Modify this according to your requirement

//            // Configure the relationship between Account and FriendRequest
//            modelBuilder.Entity<FriendRequest>()
//                .HasOne(fr => fr.Sender)
//                .WithMany(a => a.SentFriendRequests)
//                .HasForeignKey(fr => fr.SenderId)
//                .OnDelete(DeleteBehavior.Restrict); // Modify this according to your requirement

//            modelBuilder.Entity<FriendRequest>()
//                .HasOne(fr => fr.Receiver)
//                .WithMany(a => a.ReceivedFriendRequests)
//                .HasForeignKey(fr => fr.ReceiverId)
//                .OnDelete(DeleteBehavior.Restrict); // Modify this according to your requirement

//            base.OnModelCreating(modelBuilder);
//        }

//        // DbSets for application entities
//        public DbSet<Account> Accounts { get; set; }
//        public DbSet<Player> Players { get; set; }
//        public DbSet<FriendsList> FriendsList { get; set; }
//        public DbSet<FriendRequest> FriendRequests { get; set; }
//    }
//}