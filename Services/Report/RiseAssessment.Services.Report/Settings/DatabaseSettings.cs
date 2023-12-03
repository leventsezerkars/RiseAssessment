namespace RiseAssessment.Services.Report.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string LocationReportCollectionName { get; set; }
        public string LocationReportDetailCollectionName { get; set; }
    }
}