namespace CustomerCampaign.Infrastructure
{
    public static class Constants
    {
        public const int Max_Rewards_Per_Day = 5;
        public static string CSV_Write_Destination_Folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string CSV_Write_FileName = "pruchases_report";
    }
}
