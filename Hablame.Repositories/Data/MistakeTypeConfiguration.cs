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
    
    public partial class MistakeTypeConfiguration
    {
        public System.Guid Id { get; set; }
        public System.Guid OwnerId { get; set; }
        public string Name { get; set; }
        public System.Guid FirstMistakeTypeId { get; set; }
        public System.Guid SecondMistakeTypeId { get; set; }
        public System.Guid ThirdMistakeTypeId { get; set; }
    }
}
