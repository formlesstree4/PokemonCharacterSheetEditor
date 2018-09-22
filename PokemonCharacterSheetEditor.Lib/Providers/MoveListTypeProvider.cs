using PokemonCharacterSheetEditor.Lib.Database;
using PokemonCharacterSheetEditor.Lib.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonCharacterSheetEditor.Lib.Providers
{
    public sealed class MoveListTypeProvider : BaseProvider<MoveListTypeDTO>
    {
        private readonly Lazy<IEnumerable<MoveListTypeDTO>> _moveListTypeDTOs;


        public MoveListTypeProvider(IQueryRunner queryRunner) : base(queryRunner)
        {
            _moveListTypeDTOs = new Lazy<IEnumerable<MoveListTypeDTO>>(() => queryRunner.Query<MoveListTypeDTO>("SELECT * FROM MoveListType"));
        }

        public override IEnumerable<MoveListTypeDTO> GetAll()
        {
            return _moveListTypeDTOs.Value;
        }

        public override MoveListTypeDTO GetByRowId(int id)
        {
            return _moveListTypeDTOs.Value.FirstOrDefault(c => c.MoveListTypeId == id);
        }
    }
}
