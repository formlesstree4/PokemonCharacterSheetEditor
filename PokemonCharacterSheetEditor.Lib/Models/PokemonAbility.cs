using System;
using System.Collections.Generic;

namespace PokemonCharacterSheetEditor.Lib.Models
{
    public partial class PokemonAbility
    {
        public long PokemonAbilityId { get; set; }
        public long PokemonId { get; set; }
        public long AbilityId { get; set; }
        public string IsHighAbility { get; set; }

        public Ability Ability { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
