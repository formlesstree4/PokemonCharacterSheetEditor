using PokemonCharacterSheetEditor.Lib.Database;
using System.Collections.Generic;

namespace PokemonCharacterSheetEditor.Lib.Providers
{

    /// <summary>
    ///     Base provider for all DTOs.
    /// </summary>
    /// <typeparam name="ProviderDto"></typeparam>
    public abstract class BaseProvider<ProviderDto>
    {

        /// <summary>
        ///     Gets the <see cref="IQueryRunner"/> implementation
        /// </summary>
        internal IQueryRunner QueryRunner { get; }


        /// <summary>
        ///     Creates a new base provider implementation for the given DTO type.
        /// </summary>
        /// <param name="queryRunner">Implementation of <see cref="IQueryRunner"/></param>
        public BaseProvider(IQueryRunner queryRunner) => QueryRunner = queryRunner;



        /// <summary>
        ///     Returns all instances of a <see cref="ProviderDto"/> in the database.
        /// </summary>
        /// <returns>Collection of <see cref="ProviderDto"/></returns>
        public abstract IEnumerable<ProviderDto> GetAll();

        /// <summary>
        ///     Returns the <see cref="ProviderDto"/> for the given ID.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns><see cref="ProviderDto"/></returns>
        public abstract ProviderDto GetByRowId(int id);

    }

}