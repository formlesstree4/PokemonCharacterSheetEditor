using PokemonCharacterSheetEditor.Lib.Database;
using PokemonCharacterSheetEditor.Lib.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonCharacterSheetEditor.Lib.Providers
{
    public sealed class FrequencyProvider : BaseProvider<FrequencyDTO>
    {
        private readonly Lazy<IEnumerable<FrequencyDTO>> _frequencyDTOs;


        public FrequencyProvider(IQueryRunner queryRunner) : base(queryRunner)
        {
            _frequencyDTOs = new Lazy<IEnumerable<FrequencyDTO>>(() => queryRunner.Query<FrequencyDTO>("SELECT * FROM Frequency"));
        }

        public override IEnumerable<FrequencyDTO> GetAll()
        {
            return _frequencyDTOs.Value;
        }

        public override FrequencyDTO GetByRowId(int id)
        {
            return _frequencyDTOs.Value.FirstOrDefault(c => c.FrequencyId == id);
        }
    }
}
