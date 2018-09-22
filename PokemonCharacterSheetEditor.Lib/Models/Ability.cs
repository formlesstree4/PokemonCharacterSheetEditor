using System;
using System.Collections.Generic;

namespace PokemonCharacterSheetEditor.Lib.Models
{
    public partial class Ability
    {
        public Ability()
        {
            PokemonAbility = new HashSet<PokemonAbility>();
        }

        public long AbilityId { get; set; }
        public string Name { get; set; }
        public string Activation { get; set; }
        public string Limit { get; set; }
        public long KeywordId { get; set; }
        public string Effect { get; set; }

        public Keyword Keyword { get; set; }
        public ICollection<PokemonAbility> PokemonAbility { get; set; }
    }
}
