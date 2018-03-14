using System.Collections.Generic;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace PokemonCharacterSheetEditor.Lib.Database
{

    /// <summary>
    ///     A private implementation of <see cref="IQueryGrid"/>
    /// </summary>
    internal sealed class QueryGrid : IQueryGrid
    {
        private readonly GridReader _reader;



        /// <summary>
        ///     Creates a new instance of the <see cref="QueryGrid"/> object.
        /// </summary>
        /// <param name="gr">The <see cref="GridReader"/> instance to pass through to</param>
        public QueryGrid(GridReader gr)
        {
            _reader = gr;
        }



        #region IQueryGrid implementation
        public void Dispose()
        {
            _reader.Dispose();
        }

        public IEnumerable<TReturn> Read<TReturn>()
        {
            return _reader.Read<TReturn>();
        }

        public Task<IEnumerable<TReturn>> ReadAsync<TReturn>()
        {
            return _reader.ReadAsync<TReturn>();
        }

        public TReturn ReadFirst<TReturn>()
        {
            return _reader.ReadFirst<TReturn>();
        }

        public Task<TReturn> ReadFirstAsync<TReturn>()
        {
            return _reader.ReadFirstAsync<TReturn>();
        }

        public TReturn ReadFirstOrDefault<TReturn>()
        {
            return _reader.ReadFirstOrDefault<TReturn>();
        }

        public Task<TReturn> ReadFirstOrDefaultAsync<TReturn>()
        {
            return _reader.ReadFirstOrDefaultAsync<TReturn>();
        }

        public TReturn ReadSingle<TReturn>()
        {
            return _reader.ReadSingle<TReturn>();
        }

        public Task<TReturn> ReadSingleAsync<TReturn>()
        {
            return _reader.ReadSingleAsync<TReturn>();
        }

        public TReturn ReadSingleOrDefault<TReturn>()
        {
            return _reader.ReadSingleOrDefault<TReturn>();
        }

        public Task<TReturn> ReadSingleOrDefaultAsync<TReturn>()
        {
            return _reader.ReadSingleOrDefaultAsync<TReturn>();
        }
        #endregion

    }

}