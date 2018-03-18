namespace PokemonCharacterSheetEditor.Lib.Database.DTO
{

    /// <summary>
    ///     DTO for the MoveStat table.
    /// </summary>
    public sealed class MoveStatDTO
    {

        /// <summary>
        ///     Gets or sets the move stat ID.
        /// </summary>
        public int MoveStatId { get; set; }

        /// <summary>
        ///     Gets or sets the move stat name.
        /// </summary>
        public string Name { get; set; }

    }

}