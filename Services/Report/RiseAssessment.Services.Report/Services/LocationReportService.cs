using AutoMapper;
using MongoDB.Driver;
using RiseAssessment.Core.Dtos;
using RiseAssessment.Core.Messages;
using RiseAssessment.Services.Report.Dtos;
using RiseAssessment.Services.Report.Models;
using RiseAssessment.Services.Report.Settings;
using Mass = MassTransit;
namespace RiseAssessment.Services.Report.Services
{
    public class LocationReportService : ILocationReportService
    {
        private readonly IMongoCollection<LocationReport> _LocationReportCollection;

        private readonly IMapper _mapper;

        public Mass.ISendEndpointProvider _sendEndPointProvider { get; }

        public LocationReportService(IMapper mapper, IDatabaseSettings databaseSettings, Mass.ISendEndpointProvider sendEndPoint)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _LocationReportCollection = database.GetCollection<LocationReport>(databaseSettings.LocationReportCollectionName);
            _mapper = mapper;
            _sendEndPointProvider = sendEndPoint;
        }

        public async Task<Response<List<LocationReportDto>>> GetAllAsync()
        {
            var datas = await _LocationReportCollection.Find(d => true).ToListAsync();
            return Response<List<LocationReportDto>>.Success(_mapper.Map<List<LocationReportDto>>(datas), 200);
        }

        public async Task<Response<LocationReportDto>> CreateAsync(LocationReportDto dataDto)
        {

            var data = _mapper.Map<LocationReport>(dataDto);
            await _LocationReportCollection.InsertOneAsync(data);

            var sendEndPoint = await _sendEndPointProvider.GetSendEndpoint(new Uri("queue:create-location-report-service"));
            await sendEndPoint.Send<CreateLocationReportCommand>(new CreateLocationReportCommand() { ReportId = data.Id });

            return Response<LocationReportDto>.Success(_mapper.Map<LocationReportDto>(data), 200);
        }

        public async Task<Response<LocationReportDto>> UpdateAsync(LocationReportDto dataDto)
        {
            var data = _mapper.Map<LocationReport>(dataDto);
            await _LocationReportCollection.ReplaceOneAsync(s => s.Id == data.Id, data);

            return Response<LocationReportDto>.Success(_mapper.Map<LocationReportDto>(data), 200);
        }
        public async Task<Response<LocationReportDto>> GetByIdAsync(string id)
        {
            var data = await _LocationReportCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

            if (data == null)
            {
                return Response<LocationReportDto>.Fail("Report not found", 404);
            }

            return Response<LocationReportDto>.Success(_mapper.Map<LocationReportDto>(data), 200);
        }

        public async Task<Response<LocationReportDto>> DeleteAsync(string id)
        {
            await _LocationReportCollection.DeleteOneAsync(x => x.Id == id);

            return Response<LocationReportDto>.Success(200);
        }

    }
}