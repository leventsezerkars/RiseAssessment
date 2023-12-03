namespace RiseAssessment.Services.Report.Dtos
{
    public class LocationReportDto
    {
        public string? Id { get; set; }
        public int Status { get; set; } = 0;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime FinishedDate { get; set; }
    }
}
