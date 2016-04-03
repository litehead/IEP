//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IEP.BusinessLogic.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentExamination
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentExamination()
        {
            this.StudentAnswers = new HashSet<StudentAnswer>();
        }
    
        public int Id { get; set; }
        public int TestId { get; set; }
        public int StudentId { get; set; }
        public short Mark { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }
        public virtual Student Student { get; set; }
        public virtual Test Test { get; set; }
    }
}
