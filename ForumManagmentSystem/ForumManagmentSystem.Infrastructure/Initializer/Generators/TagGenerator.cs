using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Infrastructure.Initializer.Generators
{
    internal class TagGenerator
    {
        internal static IList<TagDb> CreateTags()
        {
            string[] ids = new string[]
            {
                "bb86bd18-e65d-44b1-adb5-bd07c686070a",
                "d63cf14e-e897-499a-85fd-9bacef405f82",
                "48a0c91a-7224-47a0-a9b4-0982413cc6ef",
                "fa187072-6a28-4606-b096-9fbafd8029c7",
                "ab05d812-3753-4025-9ddd-46ca0bd92aa5",
                "6dca0270-56f0-4cde-9e44-9b5f0a94abe5",
                "98ac7668-59a5-4f8f-8c49-5641f8bf1781",
                "d92347d5-e8f5-4dc2-838b-d86a74769564",
                "c1863b7b-10c7-4cb3-b93c-7655ea299aac",
                "9864ada2-3acf-493b-bb25-25a8b684b9a9",
                "e4aa0e54-fa05-4757-a084-df0a989c5fa5",
                "2c12083b-b69b-4d0f-a181-0469e915a2a2",
                "9088ef78-e55f-4476-b91b-8c93bfbcf92f",
                "04b58ca9-5a97-45d5-ba89-17600af91ceb",
                "9fb0f687-c6ff-4ccc-b712-5b28ee566ab5",
                "6d2a98bd-6f14-4415-9cf1-51ece05c5d0d",
                "f6188a63-2a5c-4e78-b733-7d4716f84a41",
                "1e4da066-7d20-4f76-be37-1b0f3754a9d1",
            };

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

            for(int i = 0; i < ids.Length; i++)
            {
                var newTag = new TagDb();
                newTag.Id = new Guid(ids[i]);
                newTag.Name = tagNames[i];
                tags.Add( newTag );
            }
            return tags;
        }
    }
}
