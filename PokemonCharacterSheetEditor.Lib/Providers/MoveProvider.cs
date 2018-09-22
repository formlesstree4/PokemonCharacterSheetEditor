using PokemonCharacterSheetEditor.Lib.Database;
using PokemonCharacterSheetEditor.Lib.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonCharacterSheetEditor.Lib.Providers
{
    public sealed class MoveProvider : BaseProvider<MoveDTO>
    {
        private readonly Lazy<IEnumerable<MoveDTO>> _moveDTOs;


        public MoveProvider(IQueryRunner queryRunner) : base(queryRunner)
        {
            _moveDTOs = new Lazy<IEnumerable<MoveDTO>>(() => queryRunner.Query<MoveDTO>("SELECT * From Move"));
        }

        public override IEnumerable<MoveDTO> GetAll()
        {
            return _moveDTOs.Value;
        }

        public override MoveDTO GetByRowId(int id)
        {
            return _moveDTOs.Value.FirstOrDefault(f => f.MoveId == id);
        }
    }
}
