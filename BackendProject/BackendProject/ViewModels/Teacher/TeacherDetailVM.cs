using BackendProject.Models;

namespace BackendProject.ViewModels.Teacher
{
    public class TeacherDetailVM
    {
        public Models.Teacher Teacher { get; set; }
        public Models.Contacts Contacts { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
