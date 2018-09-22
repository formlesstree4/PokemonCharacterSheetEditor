using PokemonCharacterSheetEditor.Lib.Database;
using PokemonCharacterSheetEditor.Lib.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonCharacterSheetEditor.Lib.Providers
{
    public sealed class PokemonAbilityProvider : BaseProvider<PokemonAbilityDTO>
    {
        private readonly Lazy<IEnumerable<PokemonAbilityDTO>> _pokemonAbilityDTOs;

        public PokemonAbilityProvider(IQueryRunner queryRunner) : base(queryRunner)
        {
            _pokemonAbilityDTOs = new Lazy<IEnumerable<PokemonAbilityDTO>>(() => queryRunner.Query<PokemonAbilityDTO>("SELECT * FROM PokemonAbility"));
        }

        public override IEnumerable<PokemonAbilityDTO> GetAll()
        {
            return _pokemonAbilityDTOs.Value;
        }

        public override PokemonAbilityDTO GetByRowId(int id)
        {
            return _pokemonAbilityDTOs.Value.FirstOrDefault(c => c.AbilityId == id);
        }
    }
}
