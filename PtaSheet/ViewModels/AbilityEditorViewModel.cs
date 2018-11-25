using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using PtaSheet.Infrastructure.Events;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PtaSheet.ViewModels
{
    public class AbilityEditorViewModel : BindableBase
    {

        private ObservableCollection<Model.Ability> _abilities;
        private ReadOnlyObservableCollection<Model.Keyword> _keywords;
        private Model.Ability _selectedAbility;
        private Model.PtaConnection _connection;
        private readonly StatusEvent _statusEvent;
        private ICommand _addAbilityCommand;
        private ICommand _removeAbilityCommand;
        private InteractionRequest<IConfirmation> _confirmationRequest;


        public ObservableCollection<Model.Ability> Abilities
        {
            get => _abilities;
            private set => SetProperty(ref _abilities, value);
        }
        public ReadOnlyObservableCollection<Model.Keyword> Keywords
        {
            get => _keywords;
            private set => SetProperty(ref _keywords, value);
        }


        public Model.Ability SelectedAbility
        {
            get => _selectedAbility;
            set
            {
                //if ((!(_selectedAbility is null)) && _connection.ChangeTracker.HasChanges())
                //{
                //    SaveAllChanges();
                //}
                SetProperty(ref _selectedAbility, value);
                RaisePropertyChanged(nameof(Activation));
                RaisePropertyChanged(nameof(Effect));
                RaisePropertyChanged(nameof(Limit));
                RaisePropertyChanged(nameof(Name));
                RaisePropertyChanged(nameof(SelectedKeyword));
            }
        }
        public string Activation
        {
            get => SelectedAbility?.Activation ?? "";
            set
            {
                SelectedAbility.Activation = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedAbility));
            }
        }
        public string Effect
        {
            get => SelectedAbility?.Effect ?? "";
            set
            {
                SelectedAbility.Effect = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedAbility));
            }
        }
        public string Limit
        {
            get => SelectedAbility?.Limit ?? "";
            set
            {
                SelectedAbility.Limit = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedAbility));
            }
        }
        public string Name
        {
            get => SelectedAbility?.Name ?? "";
            set
            {
                SelectedAbility.Name = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedAbility));
            }
        }
        public Model.Keyword SelectedKeyword
        {
            get => SelectedAbility?.Keyword;
            set
            {
                SelectedAbility.Keyword = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedAbility));
            }
        }

        public ICommand AddAbilityCommand
        {
            get => _addAbilityCommand;
            private set => SetProperty(ref _addAbilityCommand, value);
        }
        public ICommand RemoveAbilityCommand
        {
            get => _removeAbilityCommand;
            private set => SetProperty(ref _removeAbilityCommand, value);
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

            Abilities = new ObservableCollection<Model.Ability>(connection.Ability);
            Keywords = new ReadOnlyObservableCollection<Model.Keyword>(new ObservableCollection<Model.Keyword>(connection.Keyword));

            AddAbilityCommand = new DelegateCommand(() =>
            {
                var newModel = _connection.Ability.Create();
                newModel.Name = "New Ability";
                newModel.Activation = "Instant";
                newModel.Effect = "None";
                newModel.Keyword = Keywords[0];
                newModel.Limit = "None";

                _connection.Ability.Add(newModel);
                Abilities.Add(newModel);
                SelectedAbility = newModel;
            });
            RemoveAbilityCommand = new DelegateCommand(() =>
            {
                ConfirmationRequest.Raise(new Confirmation
                {
                    Content = $"Are you sure you want to delete {SelectedAbility.Name}?",
                    Title = "Confirm"
                }, (confirmation) =>
                {
                    if (!confirmation.Confirmed)
                    {
                        return;
                    }
                    _connection.Ability.Remove(SelectedAbility);
                    Abilities.Remove(SelectedAbility);
                });
            });

        }

        private void SaveAllChanges()
        {
            _statusEvent.Publish($"Applying changes... please wait...");
            _connection.SaveChanges();
            _statusEvent.Publish($"The data source has been updated successfully!");
        }

    }
}
