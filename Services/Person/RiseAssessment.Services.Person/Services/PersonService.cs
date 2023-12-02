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
            var persons = await _PersonCollection.Find(Person => true).ToListAsync();

            return Response<List<PersonDto>>.Success(_mapper.Map<List<PersonDto>>(persons), 200);
        }

        public async Task<Response<PersonDto>> CreateAsync(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            await _PersonCollection.InsertOneAsync(person);

            return Response<PersonDto>.Success(_mapper.Map<PersonDto>(person), 200);
        }

        public async Task<Response<PersonDto>> UpdateAsync(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            await _PersonCollection.ReplaceOneAsync(s => s.Id == person.Id, person);

            return Response<PersonDto>.Success(_mapper.Map<PersonDto>(person), 200);
        }

        public async Task<Response<PersonDto>> GetByIdAsync(Guid id)
        {
            var person = await _PersonCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

            if (person == null)
            {
                return Response<PersonDto>.Fail("Person not found", 404);
            }

            return Response<PersonDto>.Success(_mapper.Map<PersonDto>(person), 200);
        }

        public async Task<Response<PersonDto>> DeleteAsync(Guid id)
        {
            await _PersonCollection.DeleteOneAsync(x => x.Id == id);

            return Response<PersonDto>.Success(200);
        }

    }
}