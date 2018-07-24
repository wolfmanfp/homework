using System;
using System.Windows.Input;

namespace numgame
{
    class CommandBase : ICommand
    {
        private Action toExecute;
        public event EventHandler CanExecuteChanged;

        public CommandBase(Action toExecute)
        {
            this.toExecute = toExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (toExecute != null)
            {
                toExecute();
            }
        }
    }
}
