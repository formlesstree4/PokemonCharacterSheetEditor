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
    
    public partial class PokemonAbility
    {
        public long PokemonId { get; set; }
        public long AbilityId { get; set; }
        public bool IsHighAbility { get; set; }
    
        public virtual Ability Ability { get; set; }
        public virtual Pokemon Pokemon { get; set; }
    }
}
