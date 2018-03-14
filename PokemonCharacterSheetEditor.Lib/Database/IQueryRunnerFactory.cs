using System.Data;
using System.Data.Common;

namespace PokemonCharacterSheetEditor.Lib.Database
{

    /// <summary>
    ///     Declaration of how <see cref="IQueryRunner"/> implementations are to be created for various endpoints
    /// </summary>
    public interface IQueryRunnerFactory
    {

        /// <summary>
        ///     Creates instances of <see cref="IQueryRunner"/> that use the supplied builder to generate a connection string
        /// </summary>
        /// <param name="connectionStringBuilder">An instance of <see cref="DbConnectionStringBuilder"/></param>
        /// <returns><see cref="IQueryRunner"/></returns>
        IQueryRunner Get(DbConnectionStringBuilder connectionStringBuilder);

        /// <summary>
        ///     Creates instances of <see cref="IQueryRunner"/> that point to the specified connection string
        /// </summary>
        /// <param name="connectionString">The well-formed connection string</param>
        /// <returns><see cref="IQueryRunner"/></returns>
        IQueryRunner Get(string connectionString);

        /// <summary>
        ///     Creates instances of <see cref="IQueryRunner"/> that wrap around the specified <see cref="IDbConnection"/>
        /// </summary>
        /// <param name="connection">The <see cref="IDbConnection"/> to wrap around</param>
        /// <returns><see cref="IQueryRunner"/></returns>
        IQueryRunner Get(IDbConnection connection);

    }

}