
using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Infrastructure.Initializer.Generators
{
    internal class PostLikesGenerator
    {
        internal static IList<PostLikesDb> CreateLikes()
        {
            var postsIds = new string[] 
            {
                "044E86A6-FC9F-4677-98A5-BBFE475C9366",
                "E3010802-149F-4457-BD0D-E9DB557836CC",
                "044E86A6-FC9F-4677-98A5-BBFE475C9366"
            };

            var usersIds = new string[] 
            {
                "E806AD30-83CB-4BBE-A350-AE52C1F9BF73",
                "3522894C-0F15-4F9E-B379-AB644F4E918E",
                "3522894C-0F15-4F9E-B379-AB644F4E918E"
            };

            var postslikes = new List<PostLikesDb>();

            for (int i = 0; i < postsIds.Length; i++)
            {
                var newPostLike = new PostLikesDb();
                newPostLike.PostId = new Guid(postsIds[i]);
                newPostLike.UserId = new Guid(usersIds[i]);

                postslikes.Add(newPostLike);
            }

            return postslikes;
        }
    }
}
