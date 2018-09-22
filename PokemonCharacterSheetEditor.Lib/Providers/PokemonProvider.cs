using PokemonCharacterSheetEditor.Lib.Database;
using PokemonCharacterSheetEditor.Lib.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonCharacterSheetEditor.Lib.Providers
{

    /// <summary>
    ///     Provides Pokemon details.
    /// </summary>
    public sealed class PokemonProvider : BaseProvider<PokemonDTO>
    {

        private readonly Lazy<IEnumerable<PokemonDTO>> _lazyPokemonDto;


        public PokemonProvider(IQueryRunner queryRunner) : base(queryRunner)
        {
            _lazyPokemonDto = new Lazy<IEnumerable<PokemonDTO>>(() => queryRunner.Query<PokemonDTO>("SELECT * FROM Pokemon"));
        }

        public override IEnumerable<PokemonDTO> GetAll()
        {
            return _lazyPokemonDto.Value;
        }

        public override PokemonDTO GetByRowId(int id)
        {
            return _lazyPokemonDto.Value.FirstOrDefault(c => id == c.PokemonId);
        }
    }

}