using System;
using System.Collections.Generic;

namespace PokemonCharacterSheetEditor.Lib.Models
{
    public partial class Keyword
    {
        public Keyword()
        {
            Ability = new HashSet<Ability>();
        }

        public long KeywordId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Ability> Ability { get; set; }
    }
}
