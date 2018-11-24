using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using PtaSheet.Infrastructure.Events;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PtaSheet.ViewModels
{
    public sealed class CapabilityEditorViewModel : BindableBase
    {

        private ICommand _addCapabilityCommand;
        private InteractionRequest<IConfirmation> _confirmationRequest;
        private Model.PtaConnection _connection;
        private ObservableCollection<Model.Capability> _capabilities;
        private Model.Capability _selectedCapability;
        private readonly StatusEvent _statusEvent;
        private ICommand _removeCapabilityCommand;


        public Model.Capability SelectedCapability
        {
            get => _selectedCapability;
            set
            {
                if ((!(_selectedCapability is null)) && _connection.ChangeTracker.HasChanges())
                {
                    SaveAllChanges();
                }

                SetProperty(ref _selectedCapability, value);
                RaisePropertyChanged(nameof(Name));
                RaisePropertyChanged(nameof(Description));
            }
        }
        public ObservableCollection<Model.Capability> Capabilities
        {
            get => _capabilities;
            private set => SetProperty(ref _capabilities, value);
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

        public string Name
        {
            get => SelectedCapability?.Name ?? "";
            set
            {
                SelectedCapability.Name = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedCapability));
            }
        }
        public string Description
        {
            get => SelectedCapability?.Description ?? "";
            set
            {
                SelectedCapability.Description = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedCapability));
            }
        }
        public InteractionRequest<IConfirmation> ConfirmationRequest
        {
            get => _confirmationRequest;
            private set => SetProperty(ref _confirmationRequest, value);
        }



        public CapabilityEditorViewModel()
        {
            // Design time fun
            Capabilities = new ObservableCollection<Model.Capability>
            {
                new Model.Capability
                {
                    CapabilityId = 1,
                    Description = "Hello!",
                    Name = "Design Fun"
                }
            };
            SelectedCapability = Capabilities[0];
        }
        public CapabilityEditorViewModel(IEventAggregator eventAggregator, Model.PtaConnection connection)
        {
            _statusEvent = eventAggregator.GetEvent<StatusEvent>();
            _connection = connection;
            ConfirmationRequest = new InteractionRequest<IConfirmation>();
            Capabilities = new ObservableCollection<Model.Capability>(connection.Capability);
            if (Capabilities.Count > 0)
            {
                SelectedCapability = Capabilities[0];
            }
            AddCapabilityCommand = new DelegateCommand(() =>
            {
                var newModel = _connection.Capability.Create();
                newModel.Name = "New Capability";
                newModel.Description = "Description";
                _connection.Capability.Add(newModel);
                Capabilities.Add(newModel);
                SelectedCapability = newModel;
            });
            RemoveCapabilityCommand = new DelegateCommand(() =>
            {
                ConfirmationRequest.Raise(new Confirmation
                {
                    Content = $"Are you sure you want to delete {SelectedCapability.Name}?",
                    Title = "Confirm"
                }, (confirmation) =>
                {
                    if (!confirmation.Confirmed)
                    {
                        return;
                    }
                    _connection.Capability.Remove(SelectedCapability);
                    Capabilities.Remove(SelectedCapability);
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