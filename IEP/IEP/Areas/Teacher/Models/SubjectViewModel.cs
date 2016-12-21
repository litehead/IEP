using System.Collections.Generic;

namespace IEP.Areas.Teacher.Models
{
    public class SubjectViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ModuleViewModel> Modules { get; set; }
    }
}