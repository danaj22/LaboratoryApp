using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class RelayCommand : ICommand
    {
        private readonly Func<Boolean> _canExecute;
        private readonly Action _execute;

        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action execute, Func<Boolean> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public Boolean CanExecute(Object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        public void Execute(Object parameter)
        {
            _execute();
        }
    }
    public class SimpleRelayCommandv2 : ObservableObject, ICommand
    {
        private Func<string, int> action;
        public Func<string, int> Action
        {
            get
            {
                return action;
            }

            set
            {
                action = value;
                OnPropertyChanged("Action");
            }
        }



        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                string str = parameter as string;
                Action(str);
            }
            //else
            //{
                
                //_action();
                
           // }
        }

        #endregion
    }

        public class SimpleRelayCommand : ICommand
    {
        private Action _action;

        public SimpleRelayCommand(Action action)
        {
            _action = action;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                _action();
            }
            else
            {
                _action();
            }
        }

        #endregion
    }
}
