

using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Infrastructure.Initializer.Generators
{
    internal class PostTagsGenerator
    {
        internal static IList<PostTagsDb> CreatePostTags()
        {
            var postsIds = new string[]
            {
                "044E86A6-FC9F-4677-98A5-BBFE475C9366",
                "E3010802-149F-4457-BD0D-E9DB557836CC",
                "044E86A6-FC9F-4677-98A5-BBFE475C9366"
            };

            var tagsIds = new string[]
            {
                "bb86bd18-e65d-44b1-adb5-bd07c686070a",
                "bb86bd18-e65d-44b1-adb5-bd07c686070a",
                "48a0c91a-7224-47a0-a9b4-0982413cc6ef",                
            };

            var postsTags = new List<PostTagsDb>();

            for (int i = 0; i < postsIds.Length; i++)
            {
                var newPostLike = new PostTagsDb();
                newPostLike.PostId = new Guid(postsIds[i]);
                newPostLike.TagId = new Guid(tagsIds[i]);

                postsTags.Add(newPostLike);
            }

            return postsTags;
        }
    }
}
