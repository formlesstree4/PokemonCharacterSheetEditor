using System;
using System.Collections.Generic;

namespace PokemonCharacterSheetEditor.Lib.Models
{
    public partial class Capability
    {
        public Capability()
        {
            PokemonCapabilities = new HashSet<PokemonCapabilities>();
        }

        public long CapabilityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<PokemonCapabilities> PokemonCapabilities { get; set; }
    }
}
