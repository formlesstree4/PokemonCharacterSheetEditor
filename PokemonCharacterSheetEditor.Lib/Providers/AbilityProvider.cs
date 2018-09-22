using PokemonCharacterSheetEditor.Lib.Database;
using PokemonCharacterSheetEditor.Lib.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonCharacterSheetEditor.Lib.Providers
{

    /// <summary>
    ///     Implements the ability provider.
    /// </summary>
    public sealed class AbilityProvider : BaseProvider<AbilityDTO>
    {
        private readonly Lazy<IEnumerable<AbilityDTO>> _lazyAbilityDto;



        /// <summary>
        ///     Creates a new ability provider.
        /// </summary>
        /// <param name="queryRunner"></param>
        public AbilityProvider(IQueryRunner queryRunner) : base(queryRunner)
        {
            _lazyAbilityDto = new Lazy<IEnumerable<AbilityDTO>>(() => QueryRunner.Query<AbilityDTO>("SELECT * FROM Ability"));
        }


        public override IEnumerable<AbilityDTO> GetAll() => _lazyAbilityDto.Value;
        public override AbilityDTO GetByRowId(int id) => _lazyAbilityDto.Value.FirstOrDefault(c => c.AbilityId == id);

    }

}