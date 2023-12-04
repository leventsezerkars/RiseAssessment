namespace RiseAssessment.FrontEnd.Web.Models
{
    public class PersonDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string FullName => Name + " " + Surname;

        public string Company { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
