using MassTransit;
using MassTransit.Transports;
using RiseAssessment.Core.Messages;
using RiseAssessment.Services.Contact.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RiseAssessment.Services.Contact.Consumers
{
    public class GetLocationReportDatasConsumer : IConsumer<CreateLocationReportCommand>
    {
        private readonly ISendEndpointProvider sendEndPointProvider;
        public IContactService Service { get; }

        public GetLocationReportDatasConsumer(IContactService service, ISendEndpointProvider sendEndPointProvider)
        {
            Service = service;
            this.sendEndPointProvider = sendEndPointProvider;
        }


        public async Task Consume(ConsumeContext<CreateLocationReportCommand> context)
        {
            var reportId = context.Message.ReportId;

            var datas = await Service.GetLocationReportDatas();

            var reportDatas = new CreateLocationReportDetailCommand();

            reportDatas.ReportId = reportId;
            reportDatas.Details.AddRange(datas.Data);

            var sendEndPoint = await sendEndPointProvider.GetSendEndpoint(new Uri("queue:create-location-report-detail-service"));
            await sendEndPoint.Send<CreateLocationReportDetailCommand>(reportDatas);
        }
    }
}
