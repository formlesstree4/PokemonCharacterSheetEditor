//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PtaSheet_Provider
{
    using System;
    using System.Collections.Generic;
    
    public partial class TypeEffective
    {
        public long TypeEffectiveId { get; set; }
        public long AttackingId { get; set; }
        public long DefendingId { get; set; }
        public double Modifier { get; set; }
    
        public virtual Type Type { get; set; }
        public virtual Type Type1 { get; set; }
    }
}
