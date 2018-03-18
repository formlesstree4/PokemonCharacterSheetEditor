using System.Data;
using System.Data.Common;

namespace PokemonCharacterSheetEditor.Lib.Database.SQLite
{

    /// <summary>
    ///     Implementation of <see cref="IQueryRunnerFactory"/> for SQLite connections.
    /// </summary>
    public sealed class SqliteQueryRunnerFactory : IQueryRunnerFactory
    {

        public IQueryRunner Get(DbConnectionStringBuilder connectionStringBuilder)
        {
            return Get(connectionStringBuilder.ToString());
        }

        public IQueryRunner Get(string connectionString)
        {
            return Get(new System.Data.SQLite.SQLiteConnection(connectionString));
        }

        public IQueryRunner Get(IDbConnection connection)
        {
            return new QueryRunner(connection);
        }

    }

}