using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonCharacterSheetEditor.Lib.Database
{

    /// <summary>
    ///     Defines how to handle queries that return more than one result set.
    /// </summary>
    /// <remarks>
    ///     <see cref="IQueryGrid"/> can be thought of as a virtual grid, where each record set that is returned is an entry on that Grid. Each individual call to any function on this Grid will return the row (usually as a given data type) and then the next row is moved up.
    /// </remarks>
    public interface IQueryGrid : IDisposable
    {

        /// <summary>
        ///     Reads out the current object result set and maps it to the specified data type.
        /// </summary>
        /// <typeparam name="TReturn">The target data type</typeparam>
        /// <returns>A collection of <typeparamref name="TReturn"/></returns>
        IEnumerable<TReturn> Read<TReturn>();

        /// <summary>
        ///     Asynchronously reads out the current object result set and maps it to the specified data type.
        /// </summary>
        /// <typeparam name="TReturn">The target data type</typeparam>
        /// <returns>A promise that will return a collection of <typeparamref name="TReturn"/></returns>
        Task<IEnumerable<TReturn>> ReadAsync<TReturn>();

        /// <summary>
        ///     Reads out the current object result set, maps it to the specified data type, and returns the first one.
        /// </summary>
        /// <typeparam name="TReturn">The target data type</typeparam>
        /// <returns><typeparamref name="TReturn"/></returns>
        TReturn ReadFirst<TReturn>();

        /// <summary>
        ///     Asynchronously reads out the current object result set, maps it to the specified data type, and returns the first one.
        /// </summary>
        /// <typeparam name="TReturn">The target data type</typeparam>
        /// <returns>A promise that will return <typeparamref name="TReturn"/></returns>
        Task<TReturn> ReadFirstAsync<TReturn>();

        /// <summary>
        ///     Reads out the current object result set, maps it to the specified data type, and returns the first one. If the record set is empty, the default value for <typeparamref name="TReturn"/> is returned instead.
        /// </summary>
        /// <typeparam name="TReturn">The target data type</typeparam>
        /// <returns><typeparamref name="TReturn"/></returns>
        TReturn ReadFirstOrDefault<TReturn>();

        /// <summary>
        ///     Asynchronously reads out the current object result set, maps it to the specified data type, and returns the first one. If the record set is empty, the default value for <typeparamref name="TReturn"/> is returned instead.
        /// </summary>
        /// <typeparam name="TReturn">The target data type</typeparam>
        /// <returns>A promise that will return <typeparamref name="TReturn"/></returns>
        Task<TReturn> ReadFirstOrDefaultAsync<TReturn>();

        /// <summary>
        ///     Reads out the current object result set, maps it to the specified data type, and returns the first one.
        /// </summary>
        /// <typeparam name="TReturn">The target data type</typeparam>
        /// <returns><typeparamref name="TReturn"/></returns>
        TReturn ReadSingle<TReturn>();

        /// <summary>
        ///     Asynchronously reads out the current object result set, maps it to the specified data type, and returns the first one.
        /// </summary>
        /// <typeparam name="TReturn">The target data type</typeparam>
        /// <returns>A promise that will return <typeparamref name="TReturn"/></returns>
        Task<TReturn> ReadSingleAsync<TReturn>();

        /// <summary>
        ///     Reads out the current object result set, maps it to the specified data type, and returns the first one. If the record set is empty, the default value for <typeparamref name="TReturn"/> is returned instead.
        /// </summary>
        /// <typeparam name="TReturn">The target data type</typeparam>
        /// <returns><typeparamref name="TReturn"/></returns>
        TReturn ReadSingleOrDefault<TReturn>();

        /// <summary>
        ///     Asynchronously reads out the current object result set, maps it to the specified data type, and returns the first one. If the record set is empty, the default value for <typeparamref name="TReturn"/> is returned instead.
        /// </summary>
        /// <typeparam name="TReturn">The target data type</typeparam>
        /// <returns>A promise that will return <typeparamref name="TReturn"/></returns>
        Task<TReturn> ReadSingleOrDefaultAsync<TReturn>();

    }

}