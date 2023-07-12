namespace NipSearchApp.Models
{
    public class EntityPerson
    {
        public int id { get; set; }
        public string? companyName { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? pesel { get; set; }
        public string? nip { get; set; }

        public int subjectId { get; set; }
        public Subject subject { get; set; }
    }
}
