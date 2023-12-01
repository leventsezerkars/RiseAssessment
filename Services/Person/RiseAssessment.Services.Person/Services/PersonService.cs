using AutoMapper;
using MongoDB.Driver;
using RiseAssessment.Core.Dtos;
using RiseAssessment.Services.Person.Dtos;
using RiseAssessment.Services.Person.Models;
using RiseAssessment.Services.Person.Services;
using RiseAssessment.Services.Person.Settings;

namespace FreeCourse.Services.Catalog.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMongoCollection<Person> _PersonCollection;

        private readonly IMapper _mapper;

        public PersonService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _PersonCollection = database.GetCollection<Person>(databaseSettings.CollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<PersonDto>>> GetAllAsync()
        {
            var categories = await _PersonCollection.Find(Person => true).ToListAsync();

            return Response<List<PersonDto>>.Success(_mapper.Map<List<PersonDto>>(categories), 200);
        }

        public async Task<Response<PersonDto>> CreateAsync(PersonDto PersonDto)
        {
            var Person = _mapper.Map<Person>(PersonDto);
            await _PersonCollection.InsertOneAsync(Person);

            return Response<PersonDto>.Success(_mapper.Map<PersonDto>(Person), 200);
        }

        public async Task<Response<PersonDto>> GetByIdAsync(Guid id)
        {
            var Person = await _PersonCollection.Find<Person>(x => x.Id == id).FirstOrDefaultAsync();

            if (Person == null)
            {
                return Response<PersonDto>.Fail("Person not found", 404);
            }

            return Response<PersonDto>.Success(_mapper.Map<PersonDto>(Person), 200);
        }

    }
}