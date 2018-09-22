using PokemonCharacterSheetEditor.Lib.Database;
using PokemonCharacterSheetEditor.Lib.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonCharacterSheetEditor.Lib.Providers
{
    public sealed class MoveStatProvider : BaseProvider<MoveStatDTO>
    {
        private readonly Lazy<IEnumerable<MoveStatDTO>> _moveStatDTOs;

        public MoveStatProvider(IQueryRunner queryRunner) : base(queryRunner)
        {
            _moveStatDTOs = new Lazy<IEnumerable<MoveStatDTO>>(() => queryRunner.Query<MoveStatDTO>("SELECT * FROM MoveStat"));
        }

        public override IEnumerable<MoveStatDTO> GetAll()
        {
            return _moveStatDTOs.Value;
        }

        public override MoveStatDTO GetByRowId(int id)
        {
            return _moveStatDTOs.Value.FirstOrDefault(c => c.MoveStatId == id);
        }
    }
}
