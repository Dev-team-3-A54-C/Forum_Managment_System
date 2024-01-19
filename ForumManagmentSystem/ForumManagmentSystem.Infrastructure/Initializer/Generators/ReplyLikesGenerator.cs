using ForumManagmentSystem.Infrastructure.Data.Models;


namespace ForumManagmentSystem.Infrastructure.Initializer.Generators
{
    internal class ReplyLikesGenerator
    {
        internal static IList<ReplyLikesDb> CreateLikes()
        {
            var repliesIds = new string[]
            {
                "370a8faa-e834-43d6-9a34-a78be008d768",
                "81560736-d320-40d6-98e0-2223268c36c6",
                "370a8faa-e834-43d6-9a34-a78be008d768",
            };

            var usersIds = new string[]
            {
                "E806AD30-83CB-4BBE-A350-AE52C1F9BF73",
                "3522894C-0F15-4F9E-B379-AB644F4E918E",
                "3522894C-0F15-4F9E-B379-AB644F4E918E"
            };

            var replieslikes = new List<ReplyLikesDb>();

            for (int i = 0; i < repliesIds.Length; i++)
            {
                var newReplyLike = new ReplyLikesDb();
                newReplyLike.ReplyId = new Guid(repliesIds[i]);
                newReplyLike.UserId = new Guid(usersIds[i]);

                replieslikes.Add(newReplyLike);
            }

            return replieslikes;
        }
    }
}
