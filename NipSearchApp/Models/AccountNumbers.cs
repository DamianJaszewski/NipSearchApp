namespace NipSearchApp.Models
{
    public class AccountNumbers
    {
        public int id { get; set; }
        public string number { get; set; }
        public int subjectId { get; set; }
        public Subject subject { get; set; }
    }
}
