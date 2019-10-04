using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using PtaSheet.Infrastructure.Events;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PtaSheet.ViewModels
{
    public class PokemonEditorViewModel : BindableBase
    {

        private ICommand _addPokemonCommand;
        private InteractionRequest<IConfirmation> _confirmationRequest;
        private Model.PtaConnection _connection;
        private ObservableCollection<Model.Pokemon> _pokemon;
        private Model.Pokemon _selectedPokemon;
        private ICommand _removePokemonCommand;



        public Model.Pokemon SelectedPokemon
        {
            get => _selectedPokemon;
            set => SetProperty(ref _selectedPokemon, value);
        }

        public ObservableCollection<Model.Pokemon> Pokemon
        {
            get => _pokemon;
            private set => SetProperty(ref _pokemon, value);
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
            Pokemon = new ObservableCollection<Model.Pokemon>
            {
                new Model.Pokemon
                {
                    Name = "Designer View",
                    PokemonId = 1,
                    EntryId = 1
                }
            };
            SelectedPokemon = Pokemon[0];
        }

        public PokemonEditorViewModel(Model.PtaConnection connection)
        {
            _connection = connection;
            ConfirmationRequest = new InteractionRequest<IConfirmation>();
            Pokemon = new ObservableCollection<Model.Pokemon>(_connection.Pokemon);
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
