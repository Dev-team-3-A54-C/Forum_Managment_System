
using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Infrastructure.Initializer.Generators
{
    internal class PostGenerator
    {
        internal static IList<PostDb> CreatePosts()
        {
            var ids = new string[]
            {
                "044E86A6-FC9F-4677-98A5-BBFE475C9366",
                "E3010802-149F-4457-BD0D-E9DB557836CC",
                "1F3D1FBD-7FDA-4970-B87F-3C2F921E973A"
            };

            var titles = new string[]
            {
                "Lorem ipsum dolor sit amet.",
                "Lorem ipsum dolor sit amet, consectetur.",
                "Vestibulum vitae est sed diam."
            };

            var contents = new string[]
            {
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras suscipit justo vitae quam gravida feugiat.",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus vitae tortor vitae orci posuere bibendum. Morbi ornare a felis in.",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque et sollicitudin purus, in commodo lectus. Suspendisse nibh est, facilisis eget."
            };

            var creatorsIds = new string[]
            {
                "E806AD30-83CB-4BBE-A350-AE52C1F9BF73",
                "3522894C-0F15-4F9E-B379-AB644F4E918E",
                "B87B9540-C07F-4CE6-905D-41E2F33A6A95"
            };

            var likesCounts = new int[]
            {
                2,
                1,
                0
            };
            
            var posts = new List<PostDb>();

            for (int i = 0; i < contents.Length; i++)
            {
                var newPost = new PostDb();
                newPost.Id = new Guid(ids[i]);
                newPost.Title = titles[i];
                newPost.Content = contents[i];
                newPost.CreatedBy = new Guid(creatorsIds[i]);
                newPost.CreatedOn = DateTime.Now;
                newPost.LikesCount = likesCounts[i];

                posts.Add(newPost);
            }
            return posts;
        }
    }
}
