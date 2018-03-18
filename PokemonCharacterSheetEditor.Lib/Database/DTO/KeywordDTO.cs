namespace PokemonCharacterSheetEditor.Lib.Database.DTO
{

    /// <summary>
    ///     DTO for the keyword table
    /// </summary>
    public sealed class KeywordDTO
    {

        /// <summary>
        ///     Gets or sets the keyword ID.
        /// </summary>
        public int KeywordId { get; set; }

        /// <summary>
        ///     Gets or sets the name of this keyword.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the description of this keyword.
        /// </summary>
        public string Description { get; set; }

    }
}
