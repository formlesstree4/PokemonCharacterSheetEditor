namespace PokemonCharacterSheetEditor.Lib.Database.DTO
{

    /// <summary>
    ///     DTO for the ability table.
    /// </summary>
    public sealed class AbilityDTO
    {

        /// <summary>
        ///     Gets or sets the ability ID.
        /// </summary>
        public int AbilityId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the ability.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the activation of this ability.
        /// </summary>
        public string Activation { get; set; }

        /// <summary>
        ///     Gets or sets the limit of this ability.
        /// </summary>
        public string Limit { get; set; }

        /// <summary>
        ///     Gets or sets the keyword ID.
        /// </summary>
        public int? KeywordId { get; set; }

        /// <summary>
        ///     Gets or sets the effect of the ability.
        /// </summary>
        public string Effect { get; set; }

    }

}