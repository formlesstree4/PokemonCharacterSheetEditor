using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using PtaSheet.Infrastructure.Events;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PtaSheet.ViewModels
{
    public class AbilityEditorViewModel : BindableBase
    {

        private ObservableCollection<Model.Ability> _abilities;
        private Model.Ability _selectedAbility;
        private Model.PtaConnection _connection;
        private readonly StatusEvent _statusEvent;
        private ICommand _addCapabilityCommand;
        private ICommand _removeCapabilityCommand;
        private InteractionRequest<IConfirmation> _confirmationRequest;


        public ObservableCollection<Model.Ability> Abilities
        {
            get => _abilities;
            private set => SetProperty(ref _abilities, value);
        }
        public Model.Ability SelectedAbility
        {
            get => _selectedAbility;
            set
            {
                if ((!(_selectedAbility is null)) && _connection.ChangeTracker.HasChanges())
                {
                    SaveAllChanges();
                }
                SetProperty(ref _selectedAbility, value);
                RaisePropertyChanged(nameof(Activation));
                RaisePropertyChanged(nameof(Effect));
                RaisePropertyChanged(nameof(Limit));
                RaisePropertyChanged(nameof(Name));
            }
        }
        public string Activation
        {
            get => SelectedAbility.Activation;
            set
            {
                SelectedAbility.Activation = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedAbility));
            }
        }
        public string Effect
        {
            get => SelectedAbility.Effect;
            set
            {
                SelectedAbility.Effect = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedAbility));
            }
        }
        public string Limit
        {
            get => SelectedAbility.Limit;
            set
            {
                SelectedAbility.Limit = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedAbility));
            }
        }
        public string Name
        {
            get => SelectedAbility.Name;
            set
            {
                SelectedAbility.Name = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedAbility));
            }
        }
        public Model.Keyword Keyword
        {
            get => SelectedAbility.Keyword;
            set
            {
                SelectedAbility.Keyword = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedAbility));
            }
        }

        public ICommand AddCapabilityCommand
        {
            get => _addCapabilityCommand;
            private set => SetProperty(ref _addCapabilityCommand, value);
        }
        public ICommand RemoveCapabilityCommand
        {
            get => _removeCapabilityCommand;
            private set => SetProperty(ref _removeCapabilityCommand, value);
        }
        public InteractionRequest<IConfirmation> ConfirmationRequest
        {
            get => _confirmationRequest;
            private set => SetProperty(ref _confirmationRequest, value);
        }


        public AbilityEditorViewModel()
        {
            _abilities = new ObservableCollection<Model.Ability>
            {
                new Model.Ability
                {
                    Activation = "Instant",
                    Effect = "None",
                    Keyword = new Model.Keyword
                    {
                        Description = "Haha~",
                        KeywordId = 0,
                        Name = "Design Keyword"
                    },
                    Limit = "None",
                    Name = "Designer Ability"
                }
            };
            SelectedAbility = Abilities[0];
        }
        public AbilityEditorViewModel(IEventAggregator eventAggregator, Model.PtaConnection connection)
        {
            _statusEvent = eventAggregator.GetEvent<StatusEvent>();
            _connection = connection;
        }

        private void SaveAllChanges()
        {
            _statusEvent.Publish($"Applying changes... please wait...");
            _connection.SaveChanges();
            _statusEvent.Publish($"The data source has been updated successfully!");
        }

    }
}
