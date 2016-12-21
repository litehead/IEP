using System.Collections.Generic;

namespace IEP.Areas.Teacher.Models
{
    public class LectureViewModel
    {
        public int SubjectId { get; set; }

        public string Title { get; set; }

        public int ModuleId { get; set; }

        public string Content { get; set; }

        public int Id { get; set; }

        public List<ModuleViewModel> AvailableModules { get; set; }
    }
}