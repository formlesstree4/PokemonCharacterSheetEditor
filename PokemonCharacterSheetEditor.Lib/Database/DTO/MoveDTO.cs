namespace PokemonCharacterSheetEditor.Lib.Database.DTO
{

    /// <summary>
    ///     DTO for the move table.
    /// </summary>
    public sealed class MoveDTO
    {

        /// <summary>
        ///     Gets or sets the move ID.
        /// </summary>
        public int MoveId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the move.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the type ID of the move.
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        ///     Gets or sets the roll of this move.
        /// </summary>
        public string Roll { get; set; }

        /// <summary>
        ///     Gets or sets the frequency ID.
        /// </summary>
        public int FrequencyId { get; set; }

        /// <summary>
        ///     Gets or sets the accuracy check.
        /// </summary>
        public string AccuracyCheck { get; set; }

        /// <summary>
        ///     Gets or sets the move stat ID.
        /// </summary>
        public int MoveStatId { get; set; }

        /// <summary>
        ///     Gets or sets the move range.
        /// </summary>
        public string MoveRange { get; set; }

        /// <summary>
        ///     Gets or sets the target of the move.
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        ///     Gets or sets the effect of the move.
        /// </summary>
        public string Effect { get; set; }

        /// <summary>
        ///     Gets or sets an optional script.
        /// </summary>
        public string EffectScript { get; set; }

        /// <summary>
        ///     Gets or sets the contest type ID.
        /// </summary>
        public int ContestTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the roll for the contest.
        /// </summary>
        public string ContestRoll { get; set; }

        /// <summary>
        ///     Gets or sets the keywords.
        /// </summary>
        public string ContestKeyword { get; set; }

    }

}