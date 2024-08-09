namespace CustomerCampaign.Infrastructure.Settings
{
    public static class DatabaseSettings
    {
        public const string Connection_String = 
            "Server=(localdb)\\MSSQLLocalDB;Database=CustomerCampaign;TrustServerCertificate=True;";
        public const string Migrations_Assembly = "CustomerCampaign.SOAP";
    }
}
