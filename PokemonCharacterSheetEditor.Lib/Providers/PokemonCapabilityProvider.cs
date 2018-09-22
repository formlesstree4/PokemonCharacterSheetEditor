using PokemonCharacterSheetEditor.Lib.Database;
using PokemonCharacterSheetEditor.Lib.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCharacterSheetEditor.Lib.Providers
{
    public sealed class PokemonCapabilityProvider : BaseProvider<PokemonCapabilityDTO>
    {
        private readonly Lazy<IEnumerable<PokemonCapabilityDTO>> _pokemonCapabilityDTOs;

        public PokemonCapabilityProvider(IQueryRunner queryRunner) : base(queryRunner)
        {
            _pokemonCapabilityDTOs = new Lazy<IEnumerable<PokemonCapabilityDTO>>(() => queryRunner.Query<PokemonCapabilityDTO>("SELECT * FROM PokemonCapability"));
        }

        public override IEnumerable<PokemonCapabilityDTO> GetAll()
        {
            return _pokemonCapabilityDTOs.Value;
        }

        public override PokemonCapabilityDTO GetByRowId(int id)
        {
            return _pokemonCapabilityDTOs.Value.FirstOrDefault(c => c.CapabilityId == id);
        }
    }
}
