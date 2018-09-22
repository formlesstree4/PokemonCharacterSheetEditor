using System;
using System.Collections.Generic;

namespace PokemonCharacterSheetEditor.Lib.Models
{
    public partial class Frequency
    {
        public Frequency()
        {
            Move = new HashSet<Move>();
        }

        public long FrequencyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Move> Move { get; set; }
    }
}
