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
    
    public partial class MistakeType
    {
        public System.Guid Id { get; set; }
        public string Title { get; set; }
        public int MinimumRatingLevelVisibility { get; set; }
        public int MaximumRatingLevelVisibility { get; set; }
        public System.Guid LanguageId { get; set; }
        public bool IsGrammar { get; set; }
        public bool IsPronunciation { get; set; }
        public bool IsVocab { get; set; }
        public bool IsPraise { get; set; }
    }
}
