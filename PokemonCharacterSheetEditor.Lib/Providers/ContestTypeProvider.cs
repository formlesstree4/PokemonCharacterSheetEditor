using PokemonCharacterSheetEditor.Lib.Database;
using PokemonCharacterSheetEditor.Lib.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonCharacterSheetEditor.Lib.Providers
{
    public sealed class ContestTypeProvider : BaseProvider<ContestTypeDTO>
    {
        private readonly Lazy<IEnumerable<ContestTypeDTO>> _contestTypeDTOs;

        public ContestTypeProvider(IQueryRunner queryRunner) : base(queryRunner)
        {
            _contestTypeDTOs = new Lazy<IEnumerable<ContestTypeDTO>>(() => queryRunner.Query<ContestTypeDTO>("SELECT * FROM ContestType"));
        }

        public override IEnumerable<ContestTypeDTO> GetAll()
        {
            return _contestTypeDTOs.Value;
        }

        public override ContestTypeDTO GetByRowId(int id)
        {
            return _contestTypeDTOs.Value.FirstOrDefault(c => c.ContestTypeId == id);
        }

    }

}