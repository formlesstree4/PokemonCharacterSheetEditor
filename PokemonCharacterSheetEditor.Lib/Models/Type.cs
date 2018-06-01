using System;
using System.Collections.Generic;

namespace PokemonCharacterSheetEditor.Lib.Models
{
    public partial class Type
    {
        public Type()
        {
            Move = new HashSet<Move>();
            PokemonTypeOne = new HashSet<Pokemon>();
            PokemonTypeTwo = new HashSet<Pokemon>();
            TypeEffectiveAttacking = new HashSet<TypeEffective>();
            TypeEffectiveDefending = new HashSet<TypeEffective>();
        }

        public long TypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Move> Move { get; set; }
        public ICollection<Pokemon> PokemonTypeOne { get; set; }
        public ICollection<Pokemon> PokemonTypeTwo { get; set; }
        public ICollection<TypeEffective> TypeEffectiveAttacking { get; set; }
        public ICollection<TypeEffective> TypeEffectiveDefending { get; set; }
    }
}
