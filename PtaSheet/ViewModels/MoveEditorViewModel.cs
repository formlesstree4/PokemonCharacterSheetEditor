﻿using Prism.Events;
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
        private readonly IEventAggregator _eventAggregator;
        private readonly PtaConnection _connection;
        private readonly StatusEvent _statusEvent;
        private ObservableCollection<Move> _moves;
        private Move _move;
        private ICommand _addMoveCommand;
        private ICommand _removeMoveCommand;

        public ObservableCollection<Move> Moves
        {
            get => _moves;
            private set => SetProperty(ref _moves, value);
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
        }
    }
}