namespace RiseAssessment.FrontEnd.Web.Models
{
    public class ContactDto
    {
        public string? Id { get; set; }
        public string PersonId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Type { get; set; }
        public string Detail { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
