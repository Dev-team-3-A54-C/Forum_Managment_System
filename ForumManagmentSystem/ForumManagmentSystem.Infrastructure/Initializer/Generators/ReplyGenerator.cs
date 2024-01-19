
using ForumManagmentSystem.Infrastructure.Data.Models;
using System.Net.Http.Headers;

namespace ForumManagmentSystem.Infrastructure.Initializer.Generators
{
    internal class ReplyGenerator
    {
        internal static IList<ReplyDb> CreateReplies() 
        {
            var ids = new string[]
            {
                "370a8faa-e834-43d6-9a34-a78be008d768",
                "81560736-d320-40d6-98e0-2223268c36c6",
                "36bf0e5f-d891-4ce5-9a75-83ae737ddc58",
            };

            var contents = new string[]
            {
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur sit.",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean mattis turpis quis urna congue, finibus dignissim dolor vestibulum. Nullam aliquet.",
                "Nam ipsum est, vulputate non leo sed, gravida gravida est. Vivamus pharetra porta dolor, ac pharetra dolor lacinia quis. Donec ut vestibulum mauris. Praesent ornare a lorem vel ultrices. Pellentesque."
            };

            var postsIds = new string[]
            {
                "044E86A6-FC9F-4677-98A5-BBFE475C9366",
                "E3010802-149F-4457-BD0D-E9DB557836CC",
                "E3010802-149F-4457-BD0D-E9DB557836CC"
            };

            var creatorsIds = new string[]
            {
                "E806AD30-83CB-4BBE-A350-AE52C1F9BF73",
                "3522894C-0F15-4F9E-B379-AB644F4E918E",
                "E806AD30-83CB-4BBE-A350-AE52C1F9BF73"
            };

            var likesCounts = new int[]
            {
                2,
                1,
                0
            };

            var replies = new List<ReplyDb>();

            for(int i = 0; i < contents.Length; i++)
            {
                var newReply = new ReplyDb();
                newReply.Id = new Guid(ids[i]);
                newReply.Content = contents[i];
                newReply.PostId = new Guid(postsIds[i]);
                newReply.CreatedBy = new Guid(creatorsIds[i]);
                newReply.CreatedOn = DateTime.Now;
                newReply.LikesCount = likesCounts[i];

                replies.Add(newReply);
            }

            return replies;
        }
    }
}
