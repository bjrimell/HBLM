//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hablame.Repositories.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class vw_MistakeMadeSummary
    {
        public System.Guid MistakeId { get; set; }
        public string SpokenValue { get; set; }
        public string CorrectValue { get; set; }
        public System.DateTime DateTime { get; set; }
        public System.Guid ConversationId { get; set; }
        public bool IsGrammar { get; set; }
        public bool IsVocab { get; set; }
        public bool IsPronunciation { get; set; }
    }
}
