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
	public class MoveEditorViewModel : BindableBase
	{


        public ObservableCollection<Model.Move> _moves;
        public ReadOnlyObservableCollection<Model.Type> _types;
        public ReadOnlyObservableCollection<Model.Frequency> _frequencies;
        public ReadOnlyObservableCollection<Model.MoveStat> _moveStats;
        public ReadOnlyObservableCollection<Model.ContestType> _contestTypes;

        private Model.PtaConnection _connection;
        private Model.Move _selectedMove;
        private readonly StatusEvent _statusEvent;

        private ICommand _addMoveCommand;
        private ICommand _removeMoveCommand;
        private InteractionRequest<IConfirmation> _confirmationRequest;


        public ObservableCollection<Model.Move> Moves
        {
            get => _moves;
            private set => SetProperty(ref _moves, value);
        }
        public ReadOnlyObservableCollection<Model.Type> Types
        {
            get => _types;
            private set => SetProperty(ref _types, value);
        }
        public ReadOnlyObservableCollection<Model.Frequency> Frequencies
        {
            get => _frequencies;
            private set => SetProperty(ref _frequencies, value);
        }
        public ReadOnlyObservableCollection<Model.MoveStat> MoveStats
        {
            get => _moveStats;
            private set => SetProperty(ref _moveStats, value);
        }
        public ReadOnlyObservableCollection<Model.ContestType> ContestTypes
        {
            get => _contestTypes;
            private set => SetProperty(ref _contestTypes, value);
        }



        public Model.Move SelectedMove
        {
            get => _selectedMove;
            set
            {
                SetProperty(ref _selectedMove, value);
                RaisePropertyChanged(nameof(Name));
                RaisePropertyChanged(nameof(Type));
                RaisePropertyChanged(nameof(Roll));
                RaisePropertyChanged(nameof(Frequency));
                RaisePropertyChanged(nameof(AccuracyCheck));
                RaisePropertyChanged(nameof(MoveStat));
                RaisePropertyChanged(nameof(MoveRange));
                RaisePropertyChanged(nameof(Target));
                RaisePropertyChanged(nameof(Effect));
                RaisePropertyChanged(nameof(EffectScript));
                RaisePropertyChanged(nameof(ContestType));
                RaisePropertyChanged(nameof(ContestRoll));
                RaisePropertyChanged(nameof(ContestKeyword));
            }
        }
        public string Name
        {
            get => SelectedMove?.Name;
            set
            {
                SelectedMove.Name = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedMove));
            }
        }
        public Model.Type Type
        {
            get => SelectedMove?.Type;
            set
            {
                SelectedMove.Type = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedMove));
            }
        }
        public string Roll
        {
            get => SelectedMove?.Roll;
            set
            {
                SelectedMove.Roll = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedMove));
            }
        }
        public Model.Frequency Frequency
        {
            get => SelectedMove?.Frequency;
            set
            {
                SelectedMove.Frequency = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedMove));
            }
        }
        public string AccuracyCheck
        {
            get => SelectedMove?.AccuracyCheck;
            set
            {
                SelectedMove.AccuracyCheck = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedMove));
            }
        }
        public Model.MoveStat MoveStat
        {
            get => SelectedMove?.MoveStat;
            set
            {
                SelectedMove.MoveStat = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedMove));
            }
        }
        public string MoveRange
        {
            get => SelectedMove?.MoveRange;
            set
            {
                SelectedMove.MoveRange = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedMove));
            }
        }
        public string Target
        {
            get => SelectedMove?.Target;
            set
            {
                SelectedMove.Target = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedMove));
            }
        }
        public string Effect
        {
            get => SelectedMove?.Effect;
            set
            {
                SelectedMove.Effect = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedMove));
            }
        }
        public string EffectScript
        {
            get => SelectedMove?.EffectScript;
            set
            {
                SelectedMove.EffectScript = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedMove));
            }
        }
        public Model.ContestType ContestType
        {
            get => SelectedMove?.ContestType;
            set
            {
                SelectedMove.ContestType = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedMove));
            }
        }
        public string ContestRoll
        {
            get => SelectedMove?.ContestRoll;
            set
            {
                SelectedMove.ContestRoll = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedMove));
            }
        }
        public string ContestKeyword
        {
            get => SelectedMove?.ContestKeyword;
            set
            {
                SelectedMove.ContestKeyword = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SelectedMove));
            }
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
        public InteractionRequest<IConfirmation> ConfirmationRequest
        {
            get => _confirmationRequest;
            private set => SetProperty(ref _confirmationRequest, value);
        }



        public MoveEditorViewModel()
        {

        }
        public MoveEditorViewModel(IEventAggregator eventAggregator, Model.PtaConnection connection)
        {
            _statusEvent = eventAggregator.GetEvent<StatusEvent>();
            _connection = connection;

            Moves = new ObservableCollection<Model.Move>(_connection.Move);
            Types = new ReadOnlyObservableCollection<Model.Type>(
                new ObservableCollection<Model.Type>(_connection.Type));
            Frequencies = new ReadOnlyObservableCollection<Model.Frequency>(
                new ObservableCollection<Model.Frequency>(_connection.Frequency));
            MoveStats = new ReadOnlyObservableCollection<Model.MoveStat>(
                new ObservableCollection<Model.MoveStat>(_connection.MoveStat));
            ContestTypes = new ReadOnlyObservableCollection<Model.ContestType>(
                new ObservableCollection<Model.ContestType>(_connection.ContestType));

        }

	}

}