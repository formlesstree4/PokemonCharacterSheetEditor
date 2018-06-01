using System;
using System.Collections.Generic;

namespace PokemonCharacterSheetEditor.Lib.Models
{
    public partial class PokemonMove
    {
        public long PokemonMoveId { get; set; }
        public long PokemonId { get; set; }
        public long MoveId { get; set; }
        public long MoveListType { get; set; }

        public Move Move { get; set; }
        public MoveListType MoveListTypeNavigation { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
