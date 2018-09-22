using PokemonCharacterSheetEditor.Lib.Database;
using PokemonCharacterSheetEditor.Lib.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonCharacterSheetEditor.Lib.Providers
{
    public sealed class CapabilityProvider : BaseProvider<CapabilityDTO>
    {
        private readonly Lazy<IEnumerable<CapabilityDTO>> _capabilityDTOs;

        public CapabilityProvider(IQueryRunner queryRunner) : base(queryRunner)
        {
            _capabilityDTOs = new Lazy<IEnumerable<CapabilityDTO>>(() => queryRunner.Query<CapabilityDTO>("SELECT * FROM Capability"));
        }

        public override IEnumerable<CapabilityDTO> GetAll()
        {
            return _capabilityDTOs.Value;
        }

        public override CapabilityDTO GetByRowId(int id)
        {
            return _capabilityDTOs.Value.FirstOrDefault(c => c.CapabilityId == id);
        }

    }

}
