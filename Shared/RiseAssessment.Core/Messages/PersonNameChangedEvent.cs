namespace RiseAssessment.Core.Messages
{
    public class PersonNameChangedEvent
    {
        public string PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
