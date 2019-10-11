using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using PtaSheet.Infrastructure.Events;
using PtaSheet.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PtaSheet.ViewModels
{
    public sealed class MoveEditorViewModel : BindableBase
    {
        private InteractionRequest<IConfirmation> _confirmationRequest;
        private ObservableCollection<Move> _moves;
        private Move _move;
        private ICommand _addMoveCommand;
        private ICommand _removeMoveCommand;
        private ObservableCollection<Type> _types;
        private ObservableCollection<Frequency> _frequencies;
        private ObservableCollection<MoveStat> _moveStats;
        private ObservableCollection<ContestType> _contestTypes;

        public ObservableCollection<Move> Moves
        {
            get => _moves;
            private set => SetProperty(ref _moves, value);
        }
        public ObservableCollection<Type> Types
        {
            get => _types;
            private set => SetProperty(ref _types, value);
        }
        public ObservableCollection<Frequency> Frequencies
        {
            get => _frequencies;
            private set => SetProperty(ref _frequencies, value);
        }
        public ObservableCollection<MoveStat> MoveStats
        {
            get => _moveStats;
            private set => SetProperty(ref _moveStats, value);
        }
        public ObservableCollection<ContestType> ContestTypes
        {
            get => _contestTypes;
            private set => SetProperty(ref _contestTypes, value);
        }
 


        public ICommand AddMoveCommand
        {
            get => _addMoveCommand;
            private set => SetProperty(ref _addMoveCommand, value);
        }
        public ICommand RemoveMoveCommand
        {
            get => _removeMoveCommand;
            private set => SetProperty(ref _removeMoveCommand, value);
        }
        public Move SelectedMove
        {
            get => _move;
            set => SetProperty(ref _move, value);
        }
        public InteractionRequest<IConfirmation> ConfirmationRequest
        {
            get => _confirmationRequest;
            private set => SetProperty(ref _confirmationRequest, value);
        }


        public MoveEditorViewModel()
        {
            Moves = new ObservableCollection<Move>
            {
                new Move
                {
                    Name = "Designer Move"
                }
            };
        }
        public MoveEditorViewModel(IEventAggregator eventAggregator, PtaConnection connection)
        {
            _eventAggregator = eventAggregator;
            _connection = connection;
            _statusEvent = eventAggregator.GetEvent<StatusEvent>();
            Moves = new ObservableCollection<Move>(connection.Move);
            if (Moves.Count > 0)
            {
                SelectedMove = Moves[0];
            }
            Types = new ObservableCollection<Type>(connection.Type);
            Frequencies = new ObservableCollection<Frequency>(connection.Frequency);
            MoveStats = new ObservableCollection<MoveStat>(connection.MoveStat);
            ContestTypes = new ObservableCollection<ContestType>(connection.ContestType);
        }
    }
}
