﻿// <auto-generated />
using System;
using ForumManagmentSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ForumManagmentSystem.Infrastructure.Migrations
{
    [DbContext(typeof(FMSContext))]
    [Migration("20240118094321_TagsSeeding")]
    partial class TagsSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ForumManagmentSystem.Infrastructure.Data.Models.PostDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(8192)
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LikesCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ForumManagmentSystem.Infrastructure.Data.Models.PostLikesDb", b =>
                {
                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PostId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("PostLikes");
                });

            modelBuilder.Entity("ForumManagmentSystem.Infrastructure.Data.Models.PostTagsDb", b =>
                {
                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PostId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTags");
                });

            modelBuilder.Entity("ForumManagmentSystem.Infrastructure.Data.Models.ReplyDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LikesCount")
                        .HasColumnType("int");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("PostId");

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("ForumManagmentSystem.Infrastructure.Data.Models.ReplyLikesDb", b =>
                {
                    b.Property<Guid>("ReplyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReplyId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ReplyLikes");
                });

            modelBuilder.Entity("ForumManagmentSystem.Infrastructure.Data.Models.TagDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = new Guid("986d165f-a9c5-4abf-830b-fde784f545b9"),
                            IsDeleted = false,
                            Name = "funny"
                        },
                        new
                        {
                            Id = new Guid("abdd7631-267f-49fe-8a82-31dbebeb9c5c"),
                            IsDeleted = false,
                            Name = "event"
                        },
                        new
                        {
                            Id = new Guid("7f23da9b-aae3-4ee2-988f-1a7372aa4a14"),
                            IsDeleted = false,
                            Name = "charity"
                        },
                        new
                        {
                            Id = new Guid("ebd7ac77-4a23-464e-a267-d34a1dafc64b"),
                            IsDeleted = false,
                            Name = "tournament"
                        },
                        new
                        {
                            Id = new Guid("35fa1269-4cde-4b32-bec5-f16aacfe7f07"),
                            IsDeleted = false,
                            Name = "science"
                        },
                        new
                        {
                            Id = new Guid("55f948a1-6462-44fb-ac09-3041b04e4190"),
                            IsDeleted = false,
                            Name = "economy"
                        },
                        new
                        {
                            Id = new Guid("6e204671-fd9b-4aff-9dc7-436541f29ddf"),
                            IsDeleted = false,
                            Name = "investment"
                        },
                        new
                        {
                            Id = new Guid("c1bfffb1-c805-415b-8475-066f441612b6"),
                            IsDeleted = false,
                            Name = "Sofiq"
                        },
                        new
                        {
                            Id = new Guid("a70902a5-61d8-4fa8-b328-37ba83cf3ca9"),
                            IsDeleted = false,
                            Name = "Plovdiv"
                        },
                        new
                        {
                            Id = new Guid("7a99a9c4-f215-4b26-9f98-c43f0242a801"),
                            IsDeleted = false,
                            Name = "Varna"
                        },
                        new
                        {
                            Id = new Guid("979d02a1-8173-448c-8f73-81b80e925de0"),
                            IsDeleted = false,
                            Name = "Burgas"
                        },
                        new
                        {
                            Id = new Guid("0ef06111-3294-4bd2-bf9a-1c7eba2c4e89"),
                            IsDeleted = false,
                            Name = "Bulgaria"
                        },
                        new
                        {
                            Id = new Guid("1b4418e8-8670-4bba-b21a-0f7c840ec869"),
                            IsDeleted = false,
                            Name = "Europe"
                        },
                        new
                        {
                            Id = new Guid("3bb0450c-97ca-4160-b184-26f8267f4e3e"),
                            IsDeleted = false,
                            Name = "Asia"
                        },
                        new
                        {
                            Id = new Guid("59cf6f09-a87b-4724-b6f9-0b1c10e57257"),
                            IsDeleted = false,
                            Name = "Africa"
                        },
                        new
                        {
                            Id = new Guid("264596ae-0cee-497e-ad53-f2c79edff147"),
                            IsDeleted = false,
                            Name = "Australia"
                        },
                        new
                        {
                            Id = new Guid("eea20146-e6cf-4113-ab48-78b6261c0d2b"),
                            IsDeleted = false,
                            Name = "North America"
                        },
                        new
                        {
                            Id = new Guid("0a02dfc6-0df5-4603-896c-28a72fc83d8d"),
                            IsDeleted = false,
                            Name = "South America"
                        });
                });

            modelBuilder.Entity("ForumManagmentSystem.Infrastructure.Data.Models.UserDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ForumManagmentSystem.Infrastructure.Data.Models.PostDb", b =>
                {
                    b.HasOne("ForumManagmentSystem.Infrastructure.Data.Models.UserDb", "User")
                        .WithMany("MyPosts")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ForumManagmentSystem.Infrastructure.Data.Models.PostLikesDb", b =>
                {
                    b.HasOne("ForumManagmentSystem.Infrastructure.Data.Models.PostDb", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ForumManagmentSystem.Infrastructure.Data.Models.UserDb", "User")
                        .WithMany("LikedPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ForumManagmentSystem.Infrastructure.Data.Models.PostTagsDb", b =>
                {
                    b.HasOne("ForumManagmentSystem.Infrastructure.Data.Models.PostDb", "Post")
                        .WithMany("Tags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ForumManagmentSystem.Infrastructure.Data.Models.TagDb", "Tag")
                        .WithMany("Posts")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("ForumManagmentSystem.Infrastructure.Data.Models.ReplyDb", b =>
                {
                    b.HasOne("ForumManagmentSystem.Infrastructure.Data.Models.UserDb", "User")
                        .WithMany("MyReplies")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ForumManagmentSystem.Infrastructure.Data.Models.PostDb", "Post")
                        .WithMany("Replies")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ForumManagmentSystem.Infrastructure.Data.Models.ReplyLikesDb", b =>
                {
                    b.HasOne("ForumManagmentSystem.Infrastructure.Data.Models.ReplyDb", "Reply")
                        .WithMany("Likes")
                        .HasForeignKey("ReplyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ForumManagmentSystem.Infrastructure.Data.Models.UserDb", "User")
                        .WithMany("MyLikedReplies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Reply");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ForumManagmentSystem.Infrastructure.Data.Models.PostDb", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("Replies");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("ForumManagmentSystem.Infrastructure.Data.Models.ReplyDb", b =>
                {
                    b.Navigation("Likes");
                });

            modelBuilder.Entity("ForumManagmentSystem.Infrastructure.Data.Models.TagDb", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("ForumManagmentSystem.Infrastructure.Data.Models.UserDb", b =>
                {
                    b.Navigation("LikedPosts");

                    b.Navigation("MyLikedReplies");

                    b.Navigation("MyPosts");

                    b.Navigation("MyReplies");
                });
#pragma warning restore 612, 618
        }
    }
}
