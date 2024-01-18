using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Infrastructure.Initializer.Generators
{
    internal class TagGenerator
    {
        internal static IList<TagDb> CreateTags()
        {
            string[] tagNames = new string[]
            {
                "funny",
                "event",
                "charity",
                "tournament",
                "science",
                "economy",
                "investment",
                "Sofiq",
                "Plovdiv",
                "Varna",
                "Burgas",
                "Bulgaria",
                "Europe",
                "Asia",
                "Africa",
                "Australia",
                "North America",
                "South America",
            };
            
            var tags = new List<TagDb>();

            foreach ( var name in tagNames )
            {
                var newTag = new TagDb();
                newTag.Id = Guid.NewGuid();
                newTag.Name = name;
                tags.Add( newTag );
            }
            return tags;
        }
    }
}
