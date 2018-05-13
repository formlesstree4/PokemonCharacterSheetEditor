using PokemonCharacterSheetEditor.Lib.Database;
using System.Collections.Generic;

namespace PokemonCharacterSheetEditor.Lib.Providers
{

    /// <summary>
    ///     Provides type mappings for Pokemon.
    /// </summary>
    public sealed class TypeProvider
    {

        private readonly IDictionary<int, string> _mappings;


        /// <summary>
        ///     Creates a new instance of the <see cref="TypeProvider"/>
        /// </summary>
        /// <param name="query"><see cref="IQueryRunner"/></param>
        public TypeProvider(IQueryRunner query)
        {
            _mappings = new Dictionary<int, string>();
        }


    }

}