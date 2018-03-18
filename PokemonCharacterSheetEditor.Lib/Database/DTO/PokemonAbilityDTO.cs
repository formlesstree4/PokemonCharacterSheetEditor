namespace PokemonCharacterSheetEditor.Lib.Database.DTO
{

    /// <summary>
    ///     DTO for PokemonAbility table.
    /// </summary>
    public sealed class PokemonAbilityDTO
    {

        /// <summary>
        ///     Gets or sets the Pokemon ID.
        /// </summary>
        public int PokemonId { get; set; }

        /// <summary>
        ///     Gets or sets the Ability ID.
        /// </summary>
        public int AbilityId { get; set; }

        /// <summary>
        ///     Gets or sets whether the given ability is a high ability.
        /// </summary>
        public bool IsHighAbility { get; set; }

    }

}