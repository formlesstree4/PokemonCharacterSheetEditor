namespace PokemonCharacterSheetEditor.Lib.Database.DTO
{

    /// <summary>
    ///     DTO for the capability table.
    /// </summary>
    public sealed class CapabilityDTO
    {

        /// <summary>
        ///     Gets or sets the capability ID.
        /// </summary>
        public int CapabilityId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the capability.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the description of the capability.
        /// </summary>
        public string Description { get; set; }

    }

}