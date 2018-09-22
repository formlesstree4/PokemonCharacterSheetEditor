using System;
using System.Collections.Generic;

namespace PokemonCharacterSheetEditor.Lib.Models
{
    public partial class Move
    {
        public Move()
        {
            PokemonMove = new HashSet<PokemonMove>();
        }

        public long MoveId { get; set; }
        public string Name { get; set; }
        public long TypeId { get; set; }
        public string Roll { get; set; }
        public long FrequencyId { get; set; }
        public string AccuracyCheck { get; set; }
        public long MoveStatId { get; set; }
        public string MoveRange { get; set; }
        public string Target { get; set; }
        public string Effect { get; set; }
        public string EffectScript { get; set; }
        public long ContestTypeId { get; set; }
        public string ContestRoll { get; set; }
        public string ContestKeyword { get; set; }

        public ContestType ContestType { get; set; }
        public Frequency Frequency { get; set; }
        public MoveStat MoveStat { get; set; }
        public Type Type { get; set; }
        public TechnicalMedicine TechnicalMedicine { get; set; }
        public ICollection<PokemonMove> PokemonMove { get; set; }
    }
}
