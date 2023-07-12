namespace NipSearchApp.Models
{
    public class Entry
    {
        public string identifier { get; set; }
        public List<Subject> subjects { get; set; }
        public string requestDateTime { get; set; }
        public string requestId { get; set; }
    }
}
