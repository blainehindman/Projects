using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CodeWidgit.Models
{
    public partial class CodeWidgitCoreDBContext : DbContext
    {
        public CodeWidgitCoreDBContext()
        {
        }

        public CodeWidgitCoreDBContext(DbContextOptions<CodeWidgitCoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Like> Likes { get; set; } = null!;
        public virtual DbSet<PurchaseRecord> PurchaseRecords { get; set; } = null!;
        public virtual DbSet<Rating> Ratings { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Widgit> Widgits { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=CodeWidgitContext");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.RatingId).ValueGeneratedNever();

                entity.Property(e => e.AuthorUsername).IsFixedLength();

                entity.Property(e => e.CommentDate).IsFixedLength();
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.Property(e => e.LikeId).ValueGeneratedNever();

                entity.Property(e => e.AuthorUsername).IsFixedLength();

                entity.Property(e => e.LikeDate).IsFixedLength();
            });

            modelBuilder.Entity<PurchaseRecord>(entity =>
            {
                entity.Property(e => e.TransactionId).ValueGeneratedNever();

                entity.Property(e => e.CreatorUsername).IsFixedLength();

                entity.Property(e => e.PurchaseDate).IsFixedLength();

                entity.Property(e => e.PurchaserUsername).IsFixedLength();

                entity.Property(e => e.WidgitDescription).IsFixedLength();

                entity.Property(e => e.WidgitName).IsFixedLength();
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.RatingId).ValueGeneratedNever();

                entity.Property(e => e.AuthorUsername).IsFixedLength();

                entity.Property(e => e.RatingDate).IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Birthday).IsFixedLength();

                entity.Property(e => e.DateJoined).IsFixedLength();

                entity.Property(e => e.Email).IsFixedLength();

                entity.Property(e => e.FirstName).IsFixedLength();

                entity.Property(e => e.LastName).IsFixedLength();

                entity.Property(e => e.Username).IsFixedLength();
            });

            modelBuilder.Entity<Widgit>(entity =>
            {
                entity.Property(e => e.WidgitId).ValueGeneratedNever();

                entity.Property(e => e.CreatorUsername).IsFixedLength();

                entity.Property(e => e.PublishedDate).IsFixedLength();

                entity.Property(e => e.UpdatedDate).IsFixedLength();

                entity.Property(e => e.WidgitDescription).IsFixedLength();

                entity.Property(e => e.WidgitName).IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
