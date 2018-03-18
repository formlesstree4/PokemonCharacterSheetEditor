namespace PokemonCharacterSheetEditor.Lib.Database.DTO
{

    /// <summary>
    ///     DTO for the Pokemon table.
    /// </summary>
    public sealed class PokemonDTO
    {

        /// <summary>
        ///     Gets or sets the Pokemon ID.
        /// </summary>
        public int PokemonId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the Pokemon.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the Pokedex Entry.
        /// </summary>
        public int EntryId { get; set; }

        /// <summary>
        ///     Gets or sets the HP stat.
        /// </summary>
        public int HP { get; set; }

        /// <summary>
        ///     Gets or sets the ATK stat.
        /// </summary>
        public int Attack { get; set; }

        /// <summary>
        ///     Gets or sets the DEF stat.
        /// </summary>
        public int Defense { get; set; }

        /// <summary>
        ///     Gets or sets the SP ATK stat.
        /// </summary>
        public int SpecialAttack { get; set; }

        /// <summary>
        ///     Gets or sets the SP DEF stat.
        /// </summary>
        public int SpecialDefense { get; set; }

        /// <summary>
        ///     Gets or sets the SPD stat.
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        ///     Gets or sets the first type ID.
        /// </summary>
        public int TypeOneId { get; set; }

        /// <summary>
        ///     Gets or sets the second type ID.
        /// </summary>
        public int TypeTwoId { get; set; }

        /// <summary>
        ///     Gets or sets the height of the Pokemon.
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        ///     Gets or sets the weight of the Pokemon.
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        ///     Gets or sets the male percentage.
        /// </summary>
        public decimal MaleChance { get; set; }

        /// <summary>
        ///     Gets or sets the female percentage.
        /// </summary>
        public decimal FemaleChance { get; set; }

        /// <summary>
        ///     Gets or sets the average hatch rate in days.
        /// </summary>
        public int AvgHatchRate { get; set; }

        /// <summary>
        ///     Gets or sets the diet of this Pokemon.
        /// </summary>
        public string Diets { get; set; }

        /// <summary>
        ///     Gets or sets the habitat of this Pokemon.
        /// </summary>
        public string Habitats { get; set; }

        /// <summary>
        ///     Gets or sets the burrow value.
        /// </summary>
        public int Burrow { get; set; }

        /// <summary>
        ///     Gets or sets the intelligence value.
        /// </summary>
        public int Intelligence { get; set; }

        /// <summary>
        ///     Gets or sets the jump value.
        /// </summary>
        public int Jump { get; set; }

        /// <summary>
        ///     Gets or sets the overland value.
        /// </summary>
        public int Overland { get; set; }

        /// <summary>
        ///     Gets or sets the power value.
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        ///     Gets or sets the Sky value.
        /// </summary>
        public int Sky { get; set; }

        /// <summary>
        ///     Gets or sets the Surface value.
        /// </summary>
        public int Surface { get; set; }

        /// <summary>
        ///     Gets or sets the Underwater value.
        /// </summary>
        public int Underwater { get; set; }

        /// <summary>
        ///     Gets or sets the Capture Rate.
        /// </summary>
        public int CaptureRate { get; set; }

        /// <summary>
        ///     Gets or sets the EXP drop value.
        /// </summary>
        public int ExperienceDrop { get; set; }

        /// <summary>
        ///     Gets or sets a script for determining if a Pokemon can level up.
        /// </summary>
        public string LevelUpScript { get; set; }

    }

}