using System;
using System.Windows.Input;

namespace EladoKliens.Model
{
    class RelayCommand : ICommand
    {
        private Action toExecute;
        private Action<object> toExecuteWithParameter;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action toExecute)
        {
            this.toExecute = toExecute;
        }

        public RelayCommand(Action<object> toExecute)
        {
            this.toExecuteWithParameter = toExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                toExecuteWithParameter?.Invoke(parameter);
            }
            else
            {
                toExecute?.Invoke();
            }
            
        }
    }
}