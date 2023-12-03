namespace RiseAssessment.Services.Report.Dtos
{
    public class LocationReportDetailDto
    {
        public string? Id { get; set; }
        public string ReportId { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int TelephoneCount { get; set; }
    }
}
