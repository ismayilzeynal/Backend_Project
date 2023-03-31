namespace BackendProject.Models
{
    public class Speaker : BaseEntity
    {
        public string FullName { get; set; }
        public string Postition { get; set; }
        public string Company { get; set; }
        public string SpeakerImageUrl { get; set; }

        public List<EventSpeaker> EventSpeakers { get; set; }
    }
}
