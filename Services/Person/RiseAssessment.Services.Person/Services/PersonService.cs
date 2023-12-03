using AutoMapper;
using MongoDB.Driver;
using RiseAssessment.Core.Dtos;
using RiseAssessment.Core.Messages;
using RiseAssessment.Services.Person.Dtos;
using RiseAssessment.Services.Person.Settings;
using Mass = MassTransit;
namespace RiseAssessment.Services.Person.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMongoCollection<Models.Person> _PersonCollection;

        private readonly IMapper _mapper;

        public Mass.IPublishEndpoint _publishEndPoint { get; }

        public PersonService(IMapper mapper, IDatabaseSettings databaseSettings, Mass.IPublishEndpoint publishEndPoint)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _PersonCollection = database.GetCollection<Models.Person>(databaseSettings.CollectionName);
            _mapper = mapper;
            _publishEndPoint = publishEndPoint;
        }

        public async Task<Response<List<PersonDto>>> GetAllAsync()
        {
            var persons = await _PersonCollection.Find(Person => true).ToListAsync();

            return Response<List<PersonDto>>.Success(_mapper.Map<List<PersonDto>>(persons), 200);
        }

        public async Task<Response<PersonDto>> CreateAsync(PersonDto personDto)
        {
            //personDto.Id = Guid.NewGuid();
            var person = _mapper.Map<Models.Person>(personDto);
            await _PersonCollection.InsertOneAsync(person);

            return Response<PersonDto>.Success(_mapper.Map<PersonDto>(person), 200);
        }

        public async Task<Response<PersonDto>> UpdateAsync(PersonDto personDto)
        {
            var person = _mapper.Map<Models.Person>(personDto);
            await _PersonCollection.ReplaceOneAsync(s => s.Id == person.Id, person);

            //Rabbitmq Kuyruğu
            await _publishEndPoint.Publish<PersonNameChangedEvent>(new PersonNameChangedEvent { PersonId = person.Id, Name = person.Name, Surname = person.Surname });

            return Response<PersonDto>.Success(_mapper.Map<PersonDto>(person), 200);
        }

        public async Task<Response<PersonDto>> GetByIdAsync(string id)
        {
            var person = await _PersonCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

            if (person == null)
            {
                return Response<PersonDto>.Fail("Person not found", 404);
            }

            return Response<PersonDto>.Success(_mapper.Map<PersonDto>(person), 200);
        }

        public async Task<Response<PersonDto>> DeleteAsync(string id)
        {
            await _PersonCollection.DeleteOneAsync(x => x.Id == id);

            return Response<PersonDto>.Success(200);
        }

    }
}