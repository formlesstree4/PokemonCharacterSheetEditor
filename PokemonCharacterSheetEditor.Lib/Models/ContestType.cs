using System;
using System.Collections.Generic;

namespace PokemonCharacterSheetEditor.Lib.Models
{
    public partial class ContestType
    {
        public ContestType()
        {
            Move = new HashSet<Move>();
        }

        public long ContestTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Move> Move { get; set; }
    }
}
