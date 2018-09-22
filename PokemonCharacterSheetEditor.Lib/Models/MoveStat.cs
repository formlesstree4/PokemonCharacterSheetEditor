using System;
using System.Collections.Generic;

namespace PokemonCharacterSheetEditor.Lib.Models
{
    public partial class MoveStat
    {
        public MoveStat()
        {
            Move = new HashSet<Move>();
        }

        public long MoveStatId { get; set; }
        public string Name { get; set; }

        public ICollection<Move> Move { get; set; }
    }
}
