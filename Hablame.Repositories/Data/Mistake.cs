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
    
    public partial class Mistake
    {
        public System.Guid Id { get; set; }
        public System.Guid ConversationId { get; set; }
        public string SpokenValue { get; set; }
        public string CorrectValue { get; set; }
        public bool IsSuperfluousAuxVerb { get; set; }
        public bool IsMissingAuxVerb { get; set; }
        public System.DateTime DateTime { get; set; }
        public int Rating { get; set; }
    
        public virtual Conversation Conversation { get; set; }
    }
}
