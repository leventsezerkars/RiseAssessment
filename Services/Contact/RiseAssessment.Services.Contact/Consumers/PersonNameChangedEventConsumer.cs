using MassTransit;
using RiseAssessment.Core.Messages;
using RiseAssessment.Services.Contact.Services;

namespace RiseAssessment.Services.Contact.Consumers
{
    public class PersonNameChangedEventConsumer : IConsumer<PersonNameChangedEvent>
    {

        public PersonNameChangedEventConsumer(IContactService contactService)
        {
            ContactService = contactService;
        }

        public IContactService ContactService { get; }

        public async Task Consume(ConsumeContext<PersonNameChangedEvent> context)
        {
            var allPersonContacts = await ContactService.GetAllAsync();
            var currentPersonContact = allPersonContacts.Data.Where(s => s.PersonId == context.Message.PersonId).ToList();

            currentPersonContact.ForEach(async s =>
            {
                s.Name = context.Message.Name;
                s.Surname = context.Message.Surname;
                await ContactService.UpdateAsync(s);
            });
        }
    }
}
