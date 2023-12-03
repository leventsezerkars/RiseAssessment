using MassTransit;
using RiseAssessment.Core.Messages;
using RiseAssessment.Services.Report.Dtos;
using RiseAssessment.Services.Report.Services;

namespace RiseAssessment.Services.Report.Consumers
{
    public class CreateLocationReportDetailConsumer : IConsumer<CreateLocationReportDetailCommand>
    {
        public CreateLocationReportDetailConsumer(ILocationReportDetailService detailService, ILocationReportService reportService)
        {
            DetailService = detailService;
            ReportService = reportService;
        }

        public ILocationReportDetailService DetailService { get; }
        public ILocationReportService ReportService { get; }

        public async Task Consume(ConsumeContext<CreateLocationReportDetailCommand> context)
        {
            var reportId = context.Message.ReportId;
            foreach (var item in context.Message.Details)
            {
                await DetailService.CreateAsync(new LocationReportDetailDto()
                {
                    ReportId = reportId,
                    Location = item.Location,
                    PersonCount = item.PersonCount,
                    TelephoneCount = item.TelephoneCount
                });

            }
            await ReportService.UpdateAsync(new LocationReportDto() { Id = reportId, FinishedDate = DateTime.Now, Status = 1 });
        }
    }
}
