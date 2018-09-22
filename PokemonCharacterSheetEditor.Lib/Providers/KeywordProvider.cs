using PokemonCharacterSheetEditor.Lib.Database;
using PokemonCharacterSheetEditor.Lib.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCharacterSheetEditor.Lib.Providers
{
    public sealed class KeywordProvider : BaseProvider<KeywordDTO>
    {
        private readonly Lazy<IEnumerable<KeywordDTO>> _keywordDTOs;

        public KeywordProvider(IQueryRunner queryRunner) : base(queryRunner)
        {
            _keywordDTOs = new Lazy<IEnumerable<KeywordDTO>>(() => queryRunner.Query<KeywordDTO>("SELECT * FROM Keyword"));
        }

        public override IEnumerable<KeywordDTO> GetAll()
        {
            return _keywordDTOs.Value;
        }

        public override KeywordDTO GetByRowId(int id)
        {
            return _keywordDTOs.Value.FirstOrDefault(c => c.KeywordId == id);
        }
    }
}
