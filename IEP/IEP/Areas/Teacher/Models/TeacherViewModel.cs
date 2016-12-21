using System.Collections.Generic;

namespace IEP.Areas.Teacher.Models
{
    public class TeacherViewModel
    {
        public List<SubjectViewModel> Subjects { get; }

        public TeacherViewModel(List<SubjectViewModel> subjects)
        {
            Subjects = subjects;
        }
    }
}