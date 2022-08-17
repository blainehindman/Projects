using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CodeWidgitCore.Models
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
        public virtual DbSet<DownloadRecord> DownloadRecords { get; set; } = null!;
        public virtual DbSet<Follower> Followers { get; set; } = null!;
        public virtual DbSet<Hashtag> Hashtags { get; set; } = null!;
        public virtual DbSet<Like> Likes { get; set; } = null!;
        public virtual DbSet<Rating> Ratings { get; set; } = null!;
        public virtual DbSet<UserCreationDate> UserCreationDates { get; set; } = null!;
        public virtual DbSet<UserFollowersCount> UserFollowersCounts { get; set; } = null!;
        public virtual DbSet<Widgit> Widgits { get; set; } = null!;
        public virtual DbSet<WidgitContent> WidgitContents { get; set; } = null!;

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

                entity.Property(e => e.CommentDate).IsFixedLength();
            });

            modelBuilder.Entity<DownloadRecord>(entity =>
            {
                entity.HasKey(e => e.DownloadId)
                    .HasName("PK_Purchase_Record");

                entity.Property(e => e.DownloadId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Follower>(entity =>
            {
                entity.Property(e => e.FollowId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Hashtag>(entity =>
            {
                entity.Property(e => e.HashtagId).ValueGeneratedNever();

                entity.Property(e => e.Hashtag1).IsFixedLength();
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.Property(e => e.LikeId).ValueGeneratedNever();

                entity.Property(e => e.LikeDate).IsFixedLength();
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.RatingId).ValueGeneratedNever();

                entity.Property(e => e.RatingDate).IsFixedLength();
            });

            modelBuilder.Entity<Widgit>(entity =>
            {
                entity.Property(e => e.WidgitId).ValueGeneratedNever();

                entity.Property(e => e.PublishedDate).IsFixedLength();

                entity.Property(e => e.UpdatedDate).IsFixedLength();

                entity.Property(e => e.WidgitDescription).IsFixedLength();

                entity.Property(e => e.WidgitName).IsFixedLength();
            });

            modelBuilder.Entity<WidgitContent>(entity =>
            {
                entity.Property(e => e.WidgitFileId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
