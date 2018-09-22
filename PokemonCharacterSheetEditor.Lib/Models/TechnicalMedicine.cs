using System;
using System.Collections.Generic;

namespace PokemonCharacterSheetEditor.Lib.Models
{
    public partial class TechnicalMedicine
    {
        public long TmRowId { get; set; }
        public string PtaId { get; set; }
        public long MoveId { get; set; }
        public double Price { get; set; }

        public Move Move { get; set; }
    }
}
