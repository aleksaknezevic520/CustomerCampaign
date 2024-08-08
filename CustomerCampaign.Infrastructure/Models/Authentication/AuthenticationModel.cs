namespace CustomerCampaign.Infrastructure.Models.Authentication
{
    public class AuthenticationModel
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public AuthenticationModel(string name, string password)
        {
            Name = name?.Trim();
            Password = password?.Trim();
        }
    }
}
