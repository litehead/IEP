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
    
    public partial class StudentAnswer
    {
        public int Id { get; set; }
        public int ExaminationId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    
        public virtual ChooseCorrectQuestion ChooseCorrectQuestion { get; set; }
        public virtual ChooseCorrectVariant ChooseCorrectVariant { get; set; }
        public virtual StudentExamination StudentExamination { get; set; }
    }
}
