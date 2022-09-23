using Framework.Support;

namespace Framework.Models
{
    public sealed class User
    {
        public string? Email { get; set; } = Faker.Internet.Email();
        public string? Password { get; set; } = new DataGenerator().GenerateRandomString(10, CharacterSet.AlphaNumeric);
        public string? FirstName { get; set; } = Faker.Name.First();
        public string? LastName { get; set; } = Faker.Name.Last();
    }
}