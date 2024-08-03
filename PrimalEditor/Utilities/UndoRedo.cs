using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PrimalEditor.Utilities
{
    public interface IUndoRedo
    {
        string Name { get; }

        void Undo();
        void Redo();
    }

    public class UndoRedoAction : IUndoRedo
    {
        private Action _undoAction;
        private Action _redoAction;

        public string Name { get; }

        public void Redo() => _redoAction();

        public void Undo() => _undoAction();

        public UndoRedoAction(string name)
        {
            Name = name;
        }

        public UndoRedoAction(Action undoAction, Action redoAction, string name) :this(name)
        {
            Debug.Assert(undoAction != null && redoAction != null);
            _undoAction = undoAction;
            _redoAction = redoAction;
        }
    }

    public class UndoRedo
    {
        private  readonly ObservableCollection<IUndoRedo> _redoList = new ObservableCollection<IUndoRedo>();
        private  readonly ObservableCollection<IUndoRedo> _undoList = new ObservableCollection<IUndoRedo>();

        public ReadOnlyObservableCollection<IUndoRedo> RedoList { get; }
        public ReadOnlyObservableCollection<IUndoRedo> UndoList { get; }

        public void Reset()
        {
            _redoList.Clear();
            _undoList.Clear();
        }

        public void Add(IUndoRedo command)
        {
            _undoList.Add(command);
            _redoList.Clear();
        }

        public void Undo()
        {
            if (_undoList.Any())
            {
                var command = _undoList.Last();
                _undoList.RemoveAt(_undoList.Count - 1);
                command.Undo();
                _redoList.Insert(0, command);
            }
        }

        public void Redo()
        {
            if (_redoList.Any())
            {
                var command = _redoList.First();
                _redoList.RemoveAt(0);
                command.Redo();
                _undoList.Add(command);
            }
        }

        public UndoRedo()
        {
            RedoList = new ReadOnlyObservableCollection<IUndoRedo>(_redoList);
            UndoList = new ReadOnlyObservableCollection<IUndoRedo>(_undoList);
        }
    }
}
