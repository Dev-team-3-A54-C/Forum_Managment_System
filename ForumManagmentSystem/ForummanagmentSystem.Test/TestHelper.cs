﻿using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForummanagmentSystem.Test
{
    internal class TestHelper
    {
        internal static UserDTO CreateTestUser()
        {
            return new UserDTO()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Username = "test1",
                Email = "test@mail.com",
                Password = "test1",
                PhoneNumber = "1234567890"
            };
        }

        internal static UserLoginDTO CreateTestUserLogin()
        {
            return new UserLoginDTO()
            {
                Username = "test1",
                Password = "test1"
            };
        }
        internal static UserDb CreateTestUserDb() 
        {
            return new UserDb()
            {
                Id = Guid.NewGuid(),
                FirstName = "FirstName",
                LastName = "LastName",
                Username = "test1",
                Email = "test@mail.com",
                PasswordHash = new byte[]
                {
                    0xB0, 0x6A, 0xE7, 0x64, 0x6C, 0x1D, 0x73, 0xA1,
                    0x0E, 0x94, 0x17, 0x1E, 0xB6, 0x9E, 0xF7, 0x7B,
                    0xC9, 0x0A, 0x41, 0xCB, 0xC2, 0x0D, 0xF1, 0xB2,
                    0x70, 0x11, 0x14, 0xEA, 0x54, 0x16, 0x4E, 0xAD,
                    0xBD, 0xB3, 0x13, 0xAA, 0xDA, 0x6B, 0x5E, 0xBC,
                    0x63, 0xDE, 0xB2, 0x90, 0x02, 0x2A, 0x70, 0x3B,
                    0x41, 0x99, 0xA7, 0xA1, 0x4E, 0x26, 0xD2, 0xEE,
                    0x9A, 0xBE, 0x55, 0xE2, 0xA1, 0x64, 0x83, 0x2C
                },
                PasswordSalt = new byte[]
                {
                    0x96, 0xE2, 0xD5, 0xF6, 0x67, 0xE2, 0x40, 0xC8,
                    0xE9, 0x56, 0xD1, 0x59, 0x7F, 0x21, 0x7B, 0xA1,
                    0x56, 0xFD, 0xE3, 0xEC, 0x03, 0xC3, 0x05, 0x98,
                    0x8D, 0xC5, 0x87, 0x4E, 0xA3, 0xE8, 0x8E, 0x12,
                    0xB0, 0xB9, 0xF3, 0x2E, 0x54, 0x19, 0x30, 0xD6,
                    0xBD, 0x4D, 0x97, 0x5F, 0x93, 0x2A, 0xFC, 0xA1,
                    0x8C, 0xC2, 0xD6, 0x19, 0xE6, 0xC3, 0x1F, 0x40,
                    0x76, 0xB7, 0x98, 0x23, 0xB8, 0xDC, 0x4A, 0x95,
                    0x98, 0xBD, 0x3F, 0x2E, 0xF2, 0x06, 0x11, 0x06,
                    0x40, 0x83, 0xD8, 0x72, 0x48, 0xBE, 0x98, 0xB1,
                    0x56, 0xFC, 0xB5, 0xBC, 0x7C, 0xDE, 0x7A, 0x2A,
                    0xF6, 0xCF, 0x37, 0xF5, 0x37, 0x03, 0x49, 0x7C,
                    0xE8, 0xC8, 0xFB, 0xA7, 0x50, 0x56, 0x1B, 0x99,
                    0xB5, 0x3A, 0xB6, 0x5A, 0xA9, 0x6F, 0xD3, 0xD4,
                    0x3D, 0x3E, 0x6B, 0x05, 0xB4, 0x57, 0x2E, 0xB2,
                    0xF7, 0x09, 0x1F, 0x4E, 0xC8, 0x13, 0xB1, 0x57
                },
                PhoneNumber = "1234567890"
            };
        }

        internal static UserDb CreateUserDb()
        {
            return new UserDb()
            {
                Id = Guid.NewGuid(),
                FirstName = "FirstName",
                LastName = "LastName",
                Username = "test1",
                Email = "test@mail.com",
                PasswordHash = new byte[]
                {
                    0xB0, 0x6A, 0xE7, 0x64, 0x6C, 0x1D, 0x73, 0xA1,
                    0x0E, 0x94, 0x17, 0x1E, 0xB6, 0x9E, 0xF7, 0x7B,
                    0xC9, 0x0A, 0x41, 0xCB, 0xC2, 0x0D, 0xF1, 0xB2,
                    0x70, 0x11, 0x14, 0xEA, 0x54, 0x16, 0x4E, 0xAD,
                    0xBD, 0xB3, 0x13, 0xAA, 0xDA, 0x6B, 0x5E, 0xBC,
                    0x63, 0xDE, 0xB2, 0x90, 0x02, 0x2A, 0x70, 0x3B,
                    0x41, 0x99, 0xA7, 0xA1, 0x4E, 0x26, 0xD2, 0xEE,
                    0x9A, 0xBE, 0x55, 0xE2, 0xA1, 0x64, 0x83, 0x2C
                },
                PasswordSalt = new byte[]
                {
                    0x96, 0xE2, 0xD5, 0xF6, 0x67, 0xE2, 0x40, 0xC8,
                    0xE9, 0x56, 0xD1, 0x59, 0x7F, 0x21, 0x7B, 0xA1,
                    0x56, 0xFD, 0xE3, 0xEC, 0x03, 0xC3, 0x05, 0x98,
                    0x8D, 0xC5, 0x87, 0x4E, 0xA3, 0xE8, 0x8E, 0x12,
                    0xB0, 0xB9, 0xF3, 0x2E, 0x54, 0x19, 0x30, 0xD6,
                    0xBD, 0x4D, 0x97, 0x5F, 0x93, 0x2A, 0xFC, 0xA1,
                    0x8C, 0xC2, 0xD6, 0x19, 0xE6, 0xC3, 0x1F, 0x40,
                    0x76, 0xB7, 0x98, 0x23, 0xB8, 0xDC, 0x4A, 0x95,
                    0x98, 0xBD, 0x3F, 0x2E, 0xF2, 0x06, 0x11, 0x06,
                    0x40, 0x83, 0xD8, 0x72, 0x48, 0xBE, 0x98, 0xB1,
                    0x56, 0xFC, 0xB5, 0xBC, 0x7C, 0xDE, 0x7A, 0x2A,
                    0xF6, 0xCF, 0x37, 0xF5, 0x37, 0x03, 0x49, 0x7C,
                    0xE8, 0xC8, 0xFB, 0xA7, 0x50, 0x56, 0x1B, 0x99,
                    0xB5, 0x3A, 0xB6, 0x5A, 0xA9, 0x6F, 0xD3, 0xD4,
                    0x3D, 0x3E, 0x6B, 0x05, 0xB4, 0x57, 0x2E, 0xB2,
                    0xF7, 0x09, 0x1F, 0x4E, 0xC8, 0x13, 0xB1, 0x57
                },
                PhoneNumber = "1234567890"
            };
        }

		internal static UserDb CreateAdminUserDb()
		{
            return new UserDb()
            {
                Id = Guid.NewGuid(),
                FirstName = "FirstName",
                LastName = "LastName",
                Username = "test1",
                Email = "test@mail.com",
                PasswordHash = new byte[]
                {
                    0xB0, 0x6A, 0xE7, 0x64, 0x6C, 0x1D, 0x73, 0xA1,
                    0x0E, 0x94, 0x17, 0x1E, 0xB6, 0x9E, 0xF7, 0x7B,
                    0xC9, 0x0A, 0x41, 0xCB, 0xC2, 0x0D, 0xF1, 0xB2,
                    0x70, 0x11, 0x14, 0xEA, 0x54, 0x16, 0x4E, 0xAD,
                    0xBD, 0xB3, 0x13, 0xAA, 0xDA, 0x6B, 0x5E, 0xBC,
                    0x63, 0xDE, 0xB2, 0x90, 0x02, 0x2A, 0x70, 0x3B,
                    0x41, 0x99, 0xA7, 0xA1, 0x4E, 0x26, 0xD2, 0xEE,
                    0x9A, 0xBE, 0x55, 0xE2, 0xA1, 0x64, 0x83, 0x2C
                },
                PasswordSalt = new byte[]
                {
                    0x96, 0xE2, 0xD5, 0xF6, 0x67, 0xE2, 0x40, 0xC8,
                    0xE9, 0x56, 0xD1, 0x59, 0x7F, 0x21, 0x7B, 0xA1,
                    0x56, 0xFD, 0xE3, 0xEC, 0x03, 0xC3, 0x05, 0x98,
                    0x8D, 0xC5, 0x87, 0x4E, 0xA3, 0xE8, 0x8E, 0x12,
                    0xB0, 0xB9, 0xF3, 0x2E, 0x54, 0x19, 0x30, 0xD6,
                    0xBD, 0x4D, 0x97, 0x5F, 0x93, 0x2A, 0xFC, 0xA1,
                    0x8C, 0xC2, 0xD6, 0x19, 0xE6, 0xC3, 0x1F, 0x40,
                    0x76, 0xB7, 0x98, 0x23, 0xB8, 0xDC, 0x4A, 0x95,
                    0x98, 0xBD, 0x3F, 0x2E, 0xF2, 0x06, 0x11, 0x06,
                    0x40, 0x83, 0xD8, 0x72, 0x48, 0xBE, 0x98, 0xB1,
                    0x56, 0xFC, 0xB5, 0xBC, 0x7C, 0xDE, 0x7A, 0x2A,
                    0xF6, 0xCF, 0x37, 0xF5, 0x37, 0x03, 0x49, 0x7C,
                    0xE8, 0xC8, 0xFB, 0xA7, 0x50, 0x56, 0x1B, 0x99,
                    0xB5, 0x3A, 0xB6, 0x5A, 0xA9, 0x6F, 0xD3, 0xD4,
                    0x3D, 0x3E, 0x6B, 0x05, 0xB4, 0x57, 0x2E, 0xB2,
                    0xF7, 0x09, 0x1F, 0x4E, 0xC8, 0x13, 0xB1, 0x57
                },
                PhoneNumber = "1234567890",
                IsAdmin = true
			};
		}
		internal static PostDb CreatePostDb()
        {
            return new PostDb()
            {
                Id = Guid.NewGuid(),
                Title = "postTitle",
                Content = "postContent"
            };
        }

        internal static ReplyDb CreateReplyDb()
        {
            return new ReplyDb()
            {
                Id= Guid.NewGuid(),
                Content = "replyContent",
            };
        }

        internal static ReplyResponseDTO CreateReplyResponseDto()
        {
            return new ReplyResponseDTO()
            {
                Content = "replyContent",
                CreatedBy = "test1",
                CreatedOn = DateTime.Now,
                PostTitle = "postTitle"
            };
        }

        internal static ReplyDTO CreateReplyDto()
        {
            return new ReplyDTO()
            {
                Content = "replyContent",
                PostTitle = "bbbbbbbbbbbbbbbbb",
                CreatedBy = "test1"
            };
        }
        internal static TagDb GetTestTag()
        {
            return new TagDb()
            {
                Id = new Guid("1234"),
                Name = "MountainTestTag"
            };
        }
        internal static IEnumerable<TagDb> GetAllTestTags()
        {
            return new List<TagDb>()
            {
                new TagDb()
                {
                    Id = new Guid("1"),
                    Name = "TestName"
                },
                new TagDb()
                {
                    Id= new Guid("2"),
                    Name = "TestName2"
                },
                new TagDb()
                {
                    Id = new Guid("3"),
                    Name = "TestName3"
                }
            };
        }
        internal static TagDTO GetTestTagDTO()
        {
            return new TagDTO()
            {
                Name = "TagTest"
            };
        }
        //internal static IEnumerable<PostDb> GetMultiplePosts()
        //{

        //}
    }
}
