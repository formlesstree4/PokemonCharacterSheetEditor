using PokemonCharacterSheetEditor.Lib.Database;
using PokemonCharacterSheetEditor.Lib.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonCharacterSheetEditor.Lib.Providers
{
    public sealed class PokemonMoveProvider : BaseProvider<PokemonMoveDTO>
    {
        private readonly Lazy<IEnumerable<PokemonMoveDTO>> _pokemonMoveDTOs;

        public PokemonMoveProvider(IQueryRunner queryRunner) : base(queryRunner)
        {
            _pokemonMoveDTOs = new Lazy<IEnumerable<PokemonMoveDTO>>(() => queryRunner.Query<PokemonMoveDTO>("SELECT * FROM PokemonMove"));
        }

        public override IEnumerable<PokemonMoveDTO> GetAll()
        {
            return _pokemonMoveDTOs.Value;
        }

        public override PokemonMoveDTO GetByRowId(int id)
        {
            return _pokemonMoveDTOs.Value.FirstOrDefault(c => c.MoveId == id);
        }
    }
}
