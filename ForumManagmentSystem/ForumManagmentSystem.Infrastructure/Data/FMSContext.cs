using ForumManagmentSystem.Infrastructure.Data.Interceptors;
using ForumManagmentSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace ForumManagmentSystem.Infrastructure.Data
{
    public class FMSContext : DbContext
    {
        public FMSContext() { }

        public FMSContext(DbContextOptions<FMSContext> options) : base(options) { }

        public DbSet<UserDb> Users { get; set; }
        public DbSet<PostDb> Posts { get; set; }
        public DbSet<ReplyDb> Replies { get; set; }
        public DbSet<TagDb> Tags { get; set; }
        public DbSet<PostTagsDb> PostTags { get; set; }
        public DbSet<PostLikesDb> PostLikes { get; set; }
        public DbSet<ReplyLikesDb> ReplyLikes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
            .AddInterceptors(new SoftDeletionInterceptor());

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //User entity config
            builder.Entity<UserDb>(e =>
            {
                e.HasKey(u => u.Id);

                e.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(32);

                e.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(32);

                e.Property(u => u.Email)
                .IsRequired();

                e.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(32);

                e.Property(u => u.Password)
                .IsRequired();

                e.Property(u => u.PhoneNumber)
                .IsRequired(false)
                .HasMaxLength(15);
            });

            builder.Entity<UserDb>()
                .HasIndex(u => u.Email)
                .IsUnique();
            builder.Entity<UserDb>()
                .HasIndex(u => u.Username)
                .IsUnique();

            builder.Entity<UserDb>().HasQueryFilter(e => e.IsDeleted == false);

            //Post entity config
            builder.Entity<PostDb>(e =>
            {
                e.HasKey(p => p.Id);

                e.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(64);

                e.Property(p => p.Content)
                .IsRequired()
                .HasMaxLength(8192);

                e.HasOne(p => p.User)
                .WithMany(u => u.MyPosts)
                .HasForeignKey(p => p.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            });

            builder.Entity<PostDb>()
                .HasIndex(p =>p.Title)
                .IsUnique();

            builder.Entity<PostDb>().HasQueryFilter(e => e.IsDeleted == false);

            //Reply entity config
            builder.Entity<ReplyDb>(e =>
            {
                e.HasKey(r => r.Id);

                e.Property(r => r.Content)
                .IsRequired()
                .HasMaxLength(3000);

                e.HasOne(r => r.Post)
                .WithMany(p => p.Replies)
                .HasForeignKey(p => p.PostId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

                e.HasOne(r => r.User)
                .WithMany(u => u.MyReplies)
                .HasForeignKey(r => r.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<ReplyDb>().HasQueryFilter(e => e.IsDeleted == false);

            //Tag entity config
            builder.Entity<TagDb>(e =>
            {
                e.HasKey(t => t.Id);

                e.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(20);                  
            });

            builder.Entity<TagDb>().HasQueryFilter(e => e.IsDeleted == false);

            //PostTags entity config
            builder.Entity<PostTagsDb>(e =>
            {
                e.HasKey(e => new
                {
                    e.PostId,
                    e.TagId
                });

                e.HasOne<TagDb>(pt => pt.Tag)
                .WithMany(t => t.Posts)
                .HasForeignKey(pt => pt.TagId)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne<PostDb>(pt => pt.Post)
                .WithMany(t => t.Tags)
                .HasForeignKey(pt => pt.PostId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            //PostLikes entity config
            builder.Entity<PostLikesDb>(e =>
            {
                e.HasKey(e => new
                {
                    e.PostId,
                    e.UserId
                });

                e.HasOne<PostDb>(pl => pl.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(pl => pl.PostId)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne<UserDb>(pl => pl.User)
                .WithMany(p => p.LikedPosts)
                .HasForeignKey(pl => pl.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            //ReplyLikes entity config
            builder.Entity<ReplyLikesDb>(e =>
            {
                e.HasKey(e => new
                {
                    e.ReplyId,
                    e.UserId
                });

                e.HasOne(rl => rl.Reply)
                .WithMany(r => r.Likes)
                .HasForeignKey(rl => rl.ReplyId)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(rl => rl.User)
                .WithMany(u => u.MyLikedReplies)
                .HasForeignKey(rl => rl.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
