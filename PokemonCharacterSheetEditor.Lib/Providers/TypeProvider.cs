using PokemonCharacterSheetEditor.Lib.Database;
using PokemonCharacterSheetEditor.Lib.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonCharacterSheetEditor.Lib.Providers
{
    public sealed class TypeProvider : BaseProvider<TypeDTO>
    {
        private readonly Lazy<IEnumerable<TypeDTO>> _typeDTOs;

        public TypeProvider(IQueryRunner queryRunner) : base(queryRunner)
        {
            _typeDTOs = new Lazy<IEnumerable<TypeDTO>>(() => queryRunner.Query<TypeDTO>("SELECT * FROM Type"));
        }

        public override IEnumerable<TypeDTO> GetAll()
        {
            return _typeDTOs.Value;
        }

        public override TypeDTO GetByRowId(int id)
        {
            return _typeDTOs.Value.FirstOrDefault(c => c.TypeId == id);
        }
    }
}
