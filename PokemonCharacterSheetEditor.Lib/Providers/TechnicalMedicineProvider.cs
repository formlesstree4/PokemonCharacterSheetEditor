using PokemonCharacterSheetEditor.Lib.Database;
using PokemonCharacterSheetEditor.Lib.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonCharacterSheetEditor.Lib.Providers
{
    public sealed class TechnicalMedicineProvider : BaseProvider<TechnicalMedicineDTO>
    {
        private readonly Lazy<IEnumerable<TechnicalMedicineDTO>> _technicalMedicineDTOs;

        public TechnicalMedicineProvider(IQueryRunner queryRunner) : base(queryRunner)
        {
            _technicalMedicineDTOs = new Lazy<IEnumerable<TechnicalMedicineDTO>>(() => queryRunner.Query<TechnicalMedicineDTO>("SELECT * FROM TechnicalMedicine"));
        }

        public override IEnumerable<TechnicalMedicineDTO> GetAll()
        {
            return _technicalMedicineDTOs.Value;
        }

        public override TechnicalMedicineDTO GetByRowId(int id)
        {
            return _technicalMedicineDTOs.Value.FirstOrDefault(c => c.TmRowId == id);
        }
    }
}
