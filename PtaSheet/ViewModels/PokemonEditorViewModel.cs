using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using PtaSheet.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PtaSheet.ViewModels
{
    public class PokemonEditorViewModel : BindableBase
    {

        private ICommand _addPokemonCommand;
        private InteractionRequest<IConfirmation> _confirmationRequest;
        private PtaConnection _connection;
        private ObservableCollection<Pokemon> _pokemon;
        private Pokemon _selectedPokemon;
        private ICommand _removePokemonCommand;
        private ObservableCollection<Type> _types;

        public Pokemon SelectedPokemon
        {
            get => _selectedPokemon;
            set => SetProperty(ref _selectedPokemon, value);
        }

        public ObservableCollection<Pokemon> Pokemon
        {
            get => _pokemon;
            private set => SetProperty(ref _pokemon, value);
        }

        public ObservableCollection<Type> Types
        {
            get => _types;
            private set => SetProperty(ref _types, value);
        }



        public ICommand AddPokemonCommand
        {
            get => _addPokemonCommand;
            private set => SetProperty(ref _addPokemonCommand, value);
        }

        public ICommand RemovePokemonCommand
        {
            get => _removePokemonCommand;
            private set => SetProperty(ref _removePokemonCommand, value);
        }

        public InteractionRequest<IConfirmation> ConfirmationRequest
        {
            get => _confirmationRequest;
            private set => SetProperty(ref _confirmationRequest, value);
        }



        public PokemonEditorViewModel()
        {
            Pokemon = new ObservableCollection<Pokemon>
            {
                new Pokemon
                {
                    Name = "Designer View",
                    PokemonId = 1,
                    EntryId = 1
                }
            };
            SelectedPokemon = Pokemon[0];
        }

        public PokemonEditorViewModel(PtaConnection connection)
        {
            _connection = connection;
            ConfirmationRequest = new InteractionRequest<IConfirmation>();
            Pokemon = new ObservableCollection<Pokemon>(_connection.Pokemon);
            AddPokemonCommand = new DelegateCommand(() =>
            {
                var newModel = _connection.Pokemon.Create();
                newModel.Name = $"Pokemon {Pokemon.Count + 1}";
                _connection.Pokemon.Add(newModel);
                Pokemon.Add(newModel);
            });
            RemovePokemonCommand = new DelegateCommand(() =>
            {
                ConfirmationRequest.Raise(new Confirmation
                {
                    Content = $"Are you sure you want to delete {SelectedPokemon.Name}?",
                    Title = "Confirm"
                }, (confirmation) =>
                {
                    if (!confirmation.Confirmed)
                    {
                        return;
                    }
                    _connection.Pokemon.Remove(SelectedPokemon);
                    Pokemon.Remove(SelectedPokemon);
                });
                if (Pokemon.Any())
                {
                    SelectedPokemon = Pokemon[0];
                }
            });

        }

    }
}
