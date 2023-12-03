namespace RiseAssessment.Services.Report.Settings
{
    public interface IDatabaseSettings
    {
        public string LocationReportCollectionName { get; set; }
        public string LocationReportDetailCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}