using System;
using System.Collections.Generic;

namespace PokemonCharacterSheetEditor.Lib.Models
{
    public partial class PokemonCapabilities
    {
        public long PokemonCapabilityId { get; set; }
        public long PokemonId { get; set; }
        public long CapabilityId { get; set; }

        public Capability Capability { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
