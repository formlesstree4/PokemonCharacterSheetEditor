namespace PokemonCharacterSheetEditor.Lib.Database.DTO
{

    /// <summary>
    ///     DTO for TypeEffective table.
    /// </summary>
    public sealed class TypeEffectiveDTO
    {

        /// <summary>
        ///     Row ID.
        /// </summary>
        public int TypeEffectiveId { get; set; }

        /// <summary>
        ///     Gets or sets the attacking type ID.
        /// </summary>
        public int AttackingId { get; set; }

        /// <summary>
        ///     Gets or sets the defending type ID.
        /// </summary>
        public int DefendingId { get; set; }

        /// <summary>
        ///     Gets or sets the damage modifier.
        /// </summary>
        public decimal Modifier { get; set; }

    }

}