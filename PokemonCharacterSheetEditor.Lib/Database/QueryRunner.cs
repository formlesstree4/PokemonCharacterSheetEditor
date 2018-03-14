using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCharacterSheetEditor.Lib.Database
{

    /// <summary>
    ///     A basic implementation of <see cref="IQueryRunner"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public class QueryRunner : IQueryRunner
    {

        private readonly IDbConnection _connection;



        /// <summary>
        ///     Creates a new instance of <see cref="QueryRunner"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IDbConnection"/></param>
        public QueryRunner(IDbConnection connection)
        {
            _connection = connection;
        }



        /// <summary>
        ///     Creates a new transaction against the underlying database connection.
        /// </summary>
        public IDbTransaction CreateTransaction()
        {
            return _connection.BeginTransaction();
        }

        /// <summary>
        ///     Disposes of the <see cref="IQueryRunner"/> and releases all managed and unmanaged resources
        /// </summary>
        public void Dispose()
        {
            _connection.Dispose();
        }

        /// <summary>
        ///     Executes a parameterized SQL statement
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType"><see cref="CommandType"/></param>
        /// <returns>The number of rows affected.</returns>
        public int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            var rows = _connection.Execute(sql, param, transaction, commandTimeout, commandType);
            QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
            return rows;
        }

        /// <summary>
        ///     Executes a parameterized SQL statement asynchronously
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType"><see cref="CommandType"/></param>
        /// <returns>The number of rows affected.</returns>
        public Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            return _connection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType).ContinueWith((t) =>
            {
                QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
                return t.Result;
            });
        }

        /// <summary>
        ///     Executes a parameterized SQL statement and opens a <see cref="IDataReader"/>
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType"><see cref="CommandType"/></param>
        /// <returns>An instance of <see cref="IDataReader"/> for reading a stream of data</returns>
        public IDataReader ExecuteReader(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            var reader = _connection.ExecuteReader(sql, param, transaction, commandTimeout, commandType);
            QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
            return reader;
        }

        /// <summary>
        ///     Executes a parameterized SQL statement asynchronously and opens a <see cref="IDataReader"/>
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType"><see cref="CommandType"/></param>
        /// <returns>An instance of <see cref="IDataReader"/> for reading a stream of data</returns>
        public Task<IDataReader> ExecuteReaderAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            return _connection.ExecuteReaderAsync(sql, param, transaction, commandTimeout, commandType).ContinueWith((t) =>
            {
                QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
                return t.Result;
            });
        }

        /// <summary>
        ///     Executes a parameterized SQL statement and returns the first column of the first row.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType"><see cref="CommandType"/></param>
        /// <returns>An <see cref="object"/> representation of the first column on the first row</returns>
        public object ExecuteScalar(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            var obj = _connection.ExecuteScalar(sql, param, transaction, commandTimeout, commandType);
            QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
            return obj;
        }

        /// <summary>
        ///     Executes a parameterized SQL statement asynchronously and returns the first column of the first row.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType"><see cref="CommandType"/></param>
        /// <returns>An <see cref="object"/> representation of the first column on the first row</returns>
        public Task<object> ExecuteScalarAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            return _connection.ExecuteScalarAsync(sql, param, transaction, commandTimeout, commandType).ContinueWith((t) =>
            {
                QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
                return t.Result;
            });
        }

        /// <summary>
        ///     Executes a parameterized SQL statement and returns the first column of the first row.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType"><see cref="CommandType"/></param>
        /// <returns>A value of the given type (<typeparam name="T"/>)</returns>
        public T ExecuteScalar<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            var obj = _connection.ExecuteScalar<T>(sql, param, transaction, commandTimeout, commandType);
            QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
            return obj;
        }

        /// <summary>
        ///     Executes a parameterized SQL statement asynchronously and returns the first column of the first row.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType"><see cref="CommandType"/></param>
        /// <returns>A value of the given type (<typeparam name="T"/>)</returns>
        public Task<T> ExecuteScalarAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            return _connection.ExecuteScalarAsync<T>(sql, param, transaction, commandTimeout, commandType).ContinueWith((t) =>
            {
                QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
                return t.Result;
            });
        }

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
        public IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            var collections = _connection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
            QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
            return collections;
        }

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
        public Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            return _connection.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType).ContinueWith((t) =>
            {
                QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
                return t.Result;
            });
        }

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
        public T QueryFirst<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            var first = _connection.QueryFirst<T>(sql, param, transaction, commandTimeout, commandType);
            QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
            return first;
        }

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
        public Task<T> QueryFirstAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            return _connection.QueryFirstAsync<T>(sql, param, transaction, commandTimeout, commandType).ContinueWith((t) =>
            {
                QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
                return t.Result;
            });
        }

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
        public T QueryFirstOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            var first = _connection.QueryFirstOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
            QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
            return first;
        }

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
        public Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            return _connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType).ContinueWith((t) =>
            {
                QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
                return t.Result;
            });
        }

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
        public T QuerySingle<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            var single = _connection.QuerySingle<T>(sql, param, transaction, commandTimeout, commandType);
            QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
            return single;
        }

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
        public Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            return _connection.QuerySingleAsync<T>(sql, param, transaction, commandTimeout, commandType).ContinueWith((t) =>
            {
                QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
                return t.Result;
            });
        }

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
        public T QuerySingleOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            var single = _connection.QuerySingleOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
            QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
            return single;
        }

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
        public Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            return _connection.QuerySingleOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType).ContinueWith((t) =>
            {
                QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
                return t.Result;
            });
        }

        /// <summary>
        ///     Executes a parameterized SQL statement and returns the multiple record sets as a single <see cref="IQueryGrid"/> instance.
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns><see cref="IQueryGrid"/></returns>
        public IQueryGrid QueryMultiple(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            var qm = _connection.QueryMultiple(sql, param, transaction, commandTimeout, commandType);
            QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
            return new QueryGrid(qm);
        }

        /// <summary>
        ///     Executes a parameterized SQL statement and returns the multiple record sets as a single <see cref="IQueryGrid"/> instance.
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns><see cref="IQueryGrid"/></returns>
        public async Task<IQueryGrid> QueryMultipleAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var sw = Stopwatch.StartNew();
            return new QueryGrid(await _connection.QueryMultipleAsync(sql, param, transaction, commandTimeout, commandType).ContinueWith((t) =>
            {
                QueryResults(sql, param, transaction, commandTimeout, commandType, sw.Elapsed);
                return t.Result;
            }));
        }

        /// <summary>
        ///     Method of logging after a query has been run. Asynchronous methods are not guaranteed to be accurate.
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <param name="queryRuntime">How long the query ran</param>
        /// <param name="source">The calling method</param>
        /// <remarks><paramref name="source"/> may not be accurate if the caller method was asynchronous</remarks>
        internal virtual void QueryResults(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?), TimeSpan? queryRuntime = default(TimeSpan?), [CallerMemberName]string source = "")
        {

        }

    }

}