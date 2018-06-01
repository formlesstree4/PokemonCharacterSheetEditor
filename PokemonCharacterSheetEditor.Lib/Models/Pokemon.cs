using System;
using System.Collections.Generic;

namespace PokemonCharacterSheetEditor.Lib.Models
{
    public partial class Pokemon
    {
        public Pokemon()
        {
            PokemonAbility = new HashSet<PokemonAbility>();
            PokemonCapabilities = new HashSet<PokemonCapabilities>();
            PokemonMove = new HashSet<PokemonMove>();
        }

        public long PokemonId { get; set; }
        public string Name { get; set; }
        public long EntryId { get; set; }
        public long Hp { get; set; }
        public long Attack { get; set; }
        public long Defense { get; set; }
        public long SpecialAttack { get; set; }
        public long SpecialDefense { get; set; }
        public long Speed { get; set; }
        public long TypeOneId { get; set; }
        public long TypeTwoId { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string MaleChance { get; set; }
        public string FemaleChance { get; set; }
        public long AvgHatchRate { get; set; }
        public string Diets { get; set; }
        public string Habitats { get; set; }
        public long Burrow { get; set; }
        public long Intelligence { get; set; }
        public long Jump { get; set; }
        public long Overland { get; set; }
        public long Power { get; set; }
        public long Sky { get; set; }
        public long Surface { get; set; }
        public long Underwater { get; set; }
        public long CaptureRate { get; set; }
        public long ExperienceDrop { get; set; }
        public string LevelUpScript { get; set; }
        public byte[] Sprite { get; set; }
        public byte[] Picture { get; set; }

        public Type TypeOne { get; set; }
        public Type TypeTwo { get; set; }
        public ICollection<PokemonAbility> PokemonAbility { get; set; }
        public ICollection<PokemonCapabilities> PokemonCapabilities { get; set; }
        public ICollection<PokemonMove> PokemonMove { get; set; }
    }
}
