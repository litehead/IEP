using System.Collections.Generic;

namespace IEP.Areas.Teacher.Models
{
    public class ModuleViewModel
    {
        public int SubjectId { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public List<LectureViewModel> Lectures { get; set; }
    }
}