using IdentityMailProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityMailProject.DataAccessLayer.Context
{
    public class IdentityMailContext : IdentityDbContext<AppUser, AppRole, int>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-S74UGVJ;initial catalog=IdentityMail;integrated security=true; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<MessageSenderRecipient>()
                .HasKey(x => new { x.SenderId, x.RecipientId, x.MessageId });


            builder.Entity<MessageSenderRecipient>()
             .HasOne(mr => mr.SenderUser)
             .WithMany(u => u.SentMessages)
             .HasForeignKey(mr => mr.SenderId)
             .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<MessageSenderRecipient>()
                .HasOne(mr => mr.RecipientUser)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(mr => mr.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<MessageSenderRecipient>()
                .HasOne(mr => mr.Message)
                .WithMany(m => m.Recipients)
                .HasForeignKey(mr => mr.MessageId);


            builder.Entity<MessageSenderRecipient>()
             .ToTable("MessageSenderRecipients");


        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}
