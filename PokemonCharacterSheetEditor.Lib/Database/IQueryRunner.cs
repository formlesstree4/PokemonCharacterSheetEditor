using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCharacterSheetEditor.Lib.Database
{

    /// <summary>
    ///     A micro-ORM interface for database access
    /// </summary>
    public interface IQueryRunner : IDisposable
    {

        /// <summary>
        ///     Executes a parameterized SQL statement
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType"><see cref="CommandType"/></param>
        /// <returns>The number of rows affected.</returns>
        int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        /// <summary>
        ///     Executes a parameterized SQL statement asynchronously
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType"><see cref="CommandType"/></param>
        /// <returns>The number of rows affected.</returns>
        Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        /// <summary>
        ///     Executes a parameterized SQL statement and opens a <see cref="IDataReader"/>
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType"><see cref="CommandType"/></param>
        /// <returns>An instance of <see cref="IDataReader"/> for reading a stream of data</returns>
        IDataReader ExecuteReader(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        /// <summary>
        ///     Executes a parameterized SQL statement asynchronously and opens a <see cref="IDataReader"/>
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType"><see cref="CommandType"/></param>
        /// <returns>An instance of <see cref="IDataReader"/> for reading a stream of data</returns>
        Task<IDataReader> ExecuteReaderAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        /// <summary>
        ///     Executes a parameterized SQL statement and returns the first column of the first row.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType"><see cref="CommandType"/></param>
        /// <returns>An <see cref="object"/> representation of the first column on the first row</returns>
        object ExecuteScalar(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        ///     Executes a parameterized SQL statement and returns the first column of the first row.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType"><see cref="CommandType"/></param>
        /// <returns>A value of the given type (<typeparam name="T"/>)</returns>
        T ExecuteScalar<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        ///     Executes a parameterized SQL statement asynchronously and returns the first column of the first row.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType"><see cref="CommandType"/></param>
        /// <returns>An <see cref="object"/> representation of the first column on the first row</returns>
        Task<object> ExecuteScalarAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        ///     Executes a parameterized SQL statement asynchronously and returns the first column of the first row.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType"><see cref="CommandType"/></param>
        /// <returns>A value of the given type (<typeparam name="T"/>)</returns>
        Task<T> ExecuteScalarAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        ///     Executes a parameterized SQL statement and returns the result set as a collection of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="buffered">Whether to buffer results in memory.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        /// A sequence of data of the supplied type; if a basic type (int, string, etc) is queried then the data from the first column in assumed, otherwise an instance is
        /// created per row, and a direct column-name===member-name mapping is assumed (case insensitive).
        /// </returns>
        IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        /// <summary>
        ///     Executes a parameterized SQL statement asynchronously and returns the result set as a collection of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        /// A sequence of data of <typeparamref name="T"/>; if a basic type (int, string, etc) is queried then the data from the first column in assumed, otherwise an instance is
        /// created per row, and a direct column-name===member-name mapping is assumed (case insensitive).
        /// </returns>
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        /// <summary>
        ///     Executes a parameterized SQL statement and returns the data typed as <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of result to return.</typeparam>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        ///     A single instance of the supplied type, mapped out where the column names line up with the type properties. If more than result is returned from the query, this method will return the first row.
        /// </returns>
        T QueryFirst<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        /// <summary>
        ///     Executes a parameterized SQL statement asynchronously and returns the data typed as <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of result to return.</typeparam>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        ///     A single instance of the supplied type, mapped out where the column names line up with the type properties. If more than result is returned from the query, this method will return the first row.
        /// </returns>
        Task<T> QueryFirstAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        /// <summary>
        ///     Executes a parameterized SQL statement and returns the data typed as <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of result to return.</typeparam>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        ///     A single instance of the supplied type, mapped out where the column names line up with the type properties. If more than result is returned from the query, this method will return the first row. If no results are returned, then, the default value for <typeparamref name="T"/> will be returned
        /// </returns>
        T QueryFirstOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        /// <summary>
        ///     Executes a parameterized SQL statement asynchronously and returns the data typed as <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of result to return.</typeparam>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        ///     A single instance of the supplied type, mapped out where the column names line up with the type properties. If more than result is returned from the query, this method will return the first row. If no results are returned, then, the default value for <typeparamref name="T"/> will be returned
        /// </returns>
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        /// <summary>
        ///     Executes a parameterized SQL statement and returns the data typed as <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of result to return.</typeparam>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        ///     A single instance of the supplied type, mapped out where the column names line up with the type properties. If more than result is returned from the query, this method should throw.
        /// </returns>
        T QuerySingle<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        /// <summary>
        ///     Executes a parameterized SQL statement asynchronously and returns the data typed as <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of result to return.</typeparam>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        ///     A single instance of the supplied type, mapped out where the column names line up with the type properties. If more than result is returned from the query, this method should throw.
        /// </returns>
        Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        /// <summary>
        ///     Executes a parameterized SQL statement and returns the data typed as <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of result to return.</typeparam>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        ///     A single instance of the supplied type, mapped out where the column names line up with the type properties. If more than result is returned from the query, this method should throw. If no results are returned, then, the default value for <typeparamref name="T"/> will be returned.
        /// </returns>
        T QuerySingleOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        /// <summary>
        ///     Executes a parameterized SQL statement asynchronously and returns the data typed as <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of result to return.</typeparam>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        ///     A single instance of the supplied type, mapped out where the column names line up with the type properties. If more than result is returned from the query, this method should throw. If no results are returned, then, the default value for <typeparamref name="T"/> will be returned.
        /// </returns>
        Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        /// <summary>
        ///     Executes a parameterized SQL statement and returns the multiple record sets as a single <see cref="IQueryGrid"/> instance.
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns><see cref="IQueryGrid"/></returns>
        IQueryGrid QueryMultiple(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        /// <summary>
        ///     Executes a parameterized SQL statement and returns the multiple record sets as a single <see cref="IQueryGrid"/> instance.
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns><see cref="IQueryGrid"/></returns>
        Task<IQueryGrid> QueryMultipleAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        /// <summary>
        ///     Creates a new transaction against the underlying database connection.
        /// </summary>
        IDbTransaction CreateTransaction();

    }

}
