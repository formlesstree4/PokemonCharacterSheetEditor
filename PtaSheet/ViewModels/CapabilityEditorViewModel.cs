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
    public sealed class CapabilityEditorViewModel : BindableBase
    {

        private ICommand _addCapabilityCommand;
        private InteractionRequest<IConfirmation> _confirmationRequest;
        private Model.PtaConnection _connection;
        private ObservableCollection<Model.Capability> _capabilities;
        private Model.Capability _selectedCapability;
        private ICommand _removeCapabilityCommand;


        public Model.Capability SelectedCapability
        {
            get => _selectedCapability;
            set
            {
                SetProperty(ref _selectedCapability, value);
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
            _connection = connection;
            ConfirmationRequest = new InteractionRequest<IConfirmation>();
            Capabilities = new ObservableCollection<Model.Capability>(connection.Capability);
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
            if (Capabilities.Any())
            {
                SelectedCapability = Capabilities[0];
            }
        }

    }

}