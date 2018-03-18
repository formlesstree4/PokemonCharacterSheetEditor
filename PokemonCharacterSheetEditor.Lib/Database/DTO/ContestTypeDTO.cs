namespace PokemonCharacterSheetEditor.Lib.Database.DTO
{

    /// <summary>
    ///     DTO for the Contest Type table.
    /// </summary>
    public sealed class ContestTypeDTO
    {

        /// <summary>
        ///     Gets or sets the contest type ID.
        /// </summary>
        public int ContestTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the contest.
        /// </summary>
        public string Name { get; set; }

    }

}