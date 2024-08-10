namespace CustomerCampaign.Infrastructure
{
    public static class Constants
    {
        public const int Max_Rewards_Per_Day = 5;
        public static string CSV_Destination_Folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string CSV_File_Name = "pruchases_report";
        public const string CSV_File_Date_Sufix_Format = "yyyyMMdd_HHmmss";
        public const string CSV_File_Extension = ".csv";
    }
}
