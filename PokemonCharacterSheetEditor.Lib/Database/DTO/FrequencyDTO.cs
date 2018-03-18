namespace PokemonCharacterSheetEditor.Lib.Database.DTO
{

    /// <summary>
    ///     DTO for the frequency table.
    /// </summary>
    public sealed class FrequencyDTO
    {

        /// <summary>
        ///     Gets or sets the unique ID of this frequency type.
        /// </summary>
        public int FrequencyId { get; set; }

        /// <summary>
        ///     Gets or sets the name of this frequency.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets a description of this frequency.
        /// </summary>
        public string Description { get; set; }

    }
}
