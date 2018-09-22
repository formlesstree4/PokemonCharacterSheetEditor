using PokemonCharacterSheetEditor.Lib.Database;
using PokemonCharacterSheetEditor.Lib.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonCharacterSheetEditor.Lib.Providers
{
    public sealed class TypeEffectiveProvider : BaseProvider<TypeEffectiveDTO>
    {
        private Lazy<IEnumerable<TypeEffectiveDTO>> _typeEffectiveDTOs;


        public TypeEffectiveProvider(IQueryRunner queryRunner) : base(queryRunner)
        {
            _typeEffectiveDTOs = new Lazy<IEnumerable<TypeEffectiveDTO>>(() => queryRunner.Query<TypeEffectiveDTO>("SELECT * FROM TypeEffective"));
        }

        public override IEnumerable<TypeEffectiveDTO> GetAll()
        {
            return _typeEffectiveDTOs.Value;
        }

        public override TypeEffectiveDTO GetByRowId(int id)
        {
            return _typeEffectiveDTOs.Value.FirstOrDefault(c => c.TypeEffectiveId == id);
        }
    }
}
