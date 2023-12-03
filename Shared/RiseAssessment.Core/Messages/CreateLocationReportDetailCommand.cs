namespace RiseAssessment.Core.Messages
{
    public class CreateLocationReportDetailCommand
    {
        public CreateLocationReportDetailCommand()
        {
            Details = new List<ReportDetail>();
        }
        public string ReportId { get; set; }

        public List<ReportDetail> Details { get; set; }

    }

    public class ReportDetail
    {
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int TelephoneCount { get; set; }
    }
}
