using System;
using System.Collections.Generic;

namespace PokemonCharacterSheetEditor.Lib.Models
{
    public partial class MoveListType
    {
        public MoveListType()
        {
            PokemonMove = new HashSet<PokemonMove>();
        }

        public long MoveListTypeId { get; set; }
        public string Type { get; set; }

        public ICollection<PokemonMove> PokemonMove { get; set; }
    }
}
