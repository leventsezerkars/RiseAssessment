using AutoMapper;
using MongoDB.Driver;
using RiseAssessment.Core.Dtos;
using RiseAssessment.Core.Messages;
using RiseAssessment.Services.Contact.Dtos;
using RiseAssessment.Services.Contact.Settings;

namespace RiseAssessment.Services.Contact.Services
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Models.Contact> _ContactCollection;

        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _ContactCollection = database.GetCollection<Models.Contact>(databaseSettings.CollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<ContactDto>>> GetAllAsync()
        {
            var datas = await _ContactCollection.Find(d => true).ToListAsync();

            return Response<List<ContactDto>>.Success(_mapper.Map<List<ContactDto>>(datas), 200);
        }

        public async Task<Response<ContactDto>> CreateAsync(ContactDto dataDto)
        {
            var data = _mapper.Map<Models.Contact>(dataDto);
            await _ContactCollection.InsertOneAsync(data);

            return Response<ContactDto>.Success(_mapper.Map<ContactDto>(data), 200);
        }

        public async Task<Response<ContactDto>> UpdateAsync(ContactDto dataDto)
        {
            var data = _mapper.Map<Models.Contact>(dataDto);
            await _ContactCollection.ReplaceOneAsync(s => s.Id == data.Id, data);

            return Response<ContactDto>.Success(_mapper.Map<ContactDto>(data), 200);
        }

        public async Task<Response<ContactDto>> GetByIdAsync(string id)
        {
            var data = await _ContactCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

            if (data == null)
            {
                return Response<ContactDto>.Fail("Contact not found", 404);
            }

            return Response<ContactDto>.Success(_mapper.Map<ContactDto>(data), 200);
        }

        public async Task<Response<ContactDto>> DeleteAsync(string id)
        {
            await _ContactCollection.DeleteOneAsync(x => x.Id == id);

            return Response<ContactDto>.Success(200);
        }

        public async Task<Response<List<ReportDetail>>> GetLocationReportDatas()
        {
            var locations = _ContactCollection.AsQueryable().Where(s => s.Type == "Location").ToList();

            var distinct = locations.DistinctBy(x => x.Detail).ToList();

            var reportDetails = new List<ReportDetail>();

            foreach (var dst in distinct)
            {
                var count = locations.Count(s => s.Detail == dst.Detail);

                var persons = _ContactCollection.AsQueryable().Where(s => s.Type == "Location" && s.Detail == dst.Detail).Select(s => s.PersonId).ToList();
                var telephoneCount = _ContactCollection.AsQueryable().Where(s => persons.Contains(s.PersonId)).Count(s => s.Type == "Telephone");

                reportDetails.Add(new ReportDetail { Location = dst.Detail, PersonCount = count, TelephoneCount = telephoneCount });
            }

            return Response<List<ReportDetail>>.Success(reportDetails, 200);

        }
    }
}