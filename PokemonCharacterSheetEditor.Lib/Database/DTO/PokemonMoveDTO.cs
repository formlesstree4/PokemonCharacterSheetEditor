namespace PokemonCharacterSheetEditor.Lib.Database.DTO
{

    /// <summary>
    ///     DTO for the PokemonMove table.
    /// </summary>
    public sealed class PokemonMoveDTO
    {

        /// <summary>
        ///     Gets or sets the Pokemon ID this move belongs to.
        /// </summary>
        public int PokemonId { get; set; }

        /// <summary>
        ///     Gets or sets the move ID.
        /// </summary>
        public int MoveId { get; set; }

        /// <summary>
        ///     Gets or sets the type ID.
        /// </summary>
        public int MoveListType { get; set; }

        /// <summary>
        ///     Gets or sets the Level this move can be learned at.
        /// </summary>
        /// <remarks>
        ///     -1 = Not a level up
        ///     +0 = Immediately qualified
        /// </remarks>
        public int Level { get; set; }

    }

}