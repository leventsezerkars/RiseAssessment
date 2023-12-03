using AutoMapper;
using MongoDB.Driver;
using RiseAssessment.Core.Dtos;
using RiseAssessment.Services.Report.Dtos;
using RiseAssessment.Services.Report.Models;
using RiseAssessment.Services.Report.Settings;
using Mass = MassTransit;
namespace RiseAssessment.Services.Report.Services
{
    public class LocationReportDetailService : ILocationReportDetailService
    {
        private readonly IMongoCollection<LocationReportDetail> _LocationReportDetailCollection;

        private readonly IMapper _mapper;

        public LocationReportDetailService(IMapper mapper, IDatabaseSettings databaseSettings, Mass.IPublishEndpoint publishEndPoint)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _LocationReportDetailCollection = database.GetCollection<LocationReportDetail>(databaseSettings.LocationReportDetailCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<LocationReportDetailDto>>> GetAllAsync()
        {
            var datas = await _LocationReportDetailCollection.Find(d => true).ToListAsync();
            return Response<List<LocationReportDetailDto>>.Success(_mapper.Map<List<LocationReportDetailDto>>(datas), 200);
        }

        public async Task<Response<LocationReportDetailDto>> CreateAsync(LocationReportDetailDto dataDto)
        {

            var data = _mapper.Map<LocationReportDetail>(dataDto);
            await _LocationReportDetailCollection.InsertOneAsync(data);

            return Response<LocationReportDetailDto>.Success(_mapper.Map<LocationReportDetailDto>(data), 200);
        }

        public async Task<Response<LocationReportDetailDto>> UpdateAsync(LocationReportDetailDto dataDto)
        {
            var data = _mapper.Map<LocationReportDetail>(dataDto);
            await _LocationReportDetailCollection.ReplaceOneAsync(s => s.Id == data.Id, data);

            return Response<LocationReportDetailDto>.Success(_mapper.Map<LocationReportDetailDto>(data), 200);
        }

        public async Task<Response<LocationReportDetailDto>> GetByIdAsync(string id)
        {
            var data = await _LocationReportDetailCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

            if (data == null)
            {
                return Response<LocationReportDetailDto>.Fail("Report Detail not found", 404);
            }

            return Response<LocationReportDetailDto>.Success(_mapper.Map<LocationReportDetailDto>(data), 200);
        }

        public async Task<Response<LocationReportDetailDto>> DeleteAsync(string id)
        {
            await _LocationReportDetailCollection.DeleteOneAsync(x => x.Id == id);

            return Response<LocationReportDetailDto>.Success(200);
        }

    }
}