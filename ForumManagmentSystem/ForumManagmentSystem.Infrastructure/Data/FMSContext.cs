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
                .HasMaxLength(15);
            });

            builder.Entity<UserDb>()
                .HasIndex(u => u.Email)
                .IsUnique();
            builder.Entity<UserDb>()
                .HasIndex(u => u.Username)
                .IsUnique();

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

                e.HasMany(p => p.LikedBy)
                .WithMany(u => u.LikedPosts)
                .UsingEntity("LikesFromUsers");

                e.HasMany(p => p.Tags)
                .WithMany(t => t.Posts);
            });

            builder.Entity<PostDb>()
                .HasIndex(p =>p.Title)
                .IsUnique();

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

            //Tag entity config
            builder.Entity<TagDb>(e =>
            {
                e.HasKey(t => t.Id);

                e.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(20);
            });
        }
    }
}
