namespace PokemonCharacterSheetEditor.Lib.Database.DTO
{

    /// <summary>
    ///     DTO for the TechnicalMedicine table.
    /// </summary>
    public sealed class TechnicalMedicineDTO
    {

        /// <summary>
        ///     Gets or sets the TM ID.
        /// </summary>
        public int TmRowId { get; set; }

        /// <summary>
        ///     Gets or sets the PTA TM ID.
        /// </summary>
        public int PtaId { get; set; }

        /// <summary>
        ///     Gets or sets the Move ID the TM teaches.
        /// </summary>
        public int MoveId { get; set; }

        /// <summary>
        ///     Gets or sets the price of the TM.
        /// </summary>
        public decimal Price { get; set; }

    }

}