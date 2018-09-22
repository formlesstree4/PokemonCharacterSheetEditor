using System;
using System.Collections.Generic;

namespace PokemonCharacterSheetEditor.Lib.Models
{
    public partial class TypeEffective
    {
        public long TypeEffectiveId { get; set; }
        public long AttackingId { get; set; }
        public long DefendingId { get; set; }
        public double Modifier { get; set; }

        public Type Attacking { get; set; }
        public Type Defending { get; set; }
    }
}
