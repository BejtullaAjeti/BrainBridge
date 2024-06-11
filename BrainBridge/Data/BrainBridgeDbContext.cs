using BrainBridge.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace BrainBridge.Data
{
    public class BrainBridgeDbContext : DbContext
    {
        public BrainBridgeDbContext(DbContextOptions<BrainBridgeDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bridge> Bridges { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<BridgeRule> BridgeRules { get; set; }
        public DbSet<BridgeMembership> BridgeMemberships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships

            // User - Post relationship
            modelBuilder.Entity<Post>()
                .HasOne(p => p.CreatedBy)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.CreatedById);

            // User - Comment relationship
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.CreatedBy)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.CreatedById);

            // Bridge - Post relationship
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Bridge)
                .WithMany(b => b.Posts)
                .HasForeignKey(p => p.BridgeId);

            // Bridge - BridgeRule relationship
            modelBuilder.Entity<BridgeRule>()
                .HasOne(br => br.Bridge)
                .WithMany(b => b.Rules)
                .HasForeignKey(br => br.BridgeId);

            // Bridge - BridgeMembership relationship
            modelBuilder.Entity<BridgeMembership>()
                .HasOne(bm => bm.Bridge)
                .WithMany(b => b.Members)
                .HasForeignKey(bm => bm.BridgeId);

            // User - BridgeMembership relationship
            modelBuilder.Entity<BridgeMembership>()
                .HasOne(bm => bm.User)
                .WithMany()
                .HasForeignKey(bm => bm.UserId);

            // Comment - Comment relationship (for comment threading)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.ParentComment)
                .WithMany(c => c.Replies)
                .HasForeignKey(c => c.ParentCommentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Bridge - User (CreatedBy) relationship
            modelBuilder.Entity<Bridge>()
                .HasOne(b => b.CreatedBy)
                .WithMany()
                .HasForeignKey(b => b.CreatedById);

            // Bridge - User (Moderators) relationship
            modelBuilder.Entity<Bridge>()
                .HasMany(b => b.Moderators)
                .WithMany(u => u.ModeratedBridges)
                .UsingEntity(j => j.ToTable("BridgeModerators"));
        }
    }
}