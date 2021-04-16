using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVP_Tema2_Checkers.Commands
{
    class ButtonCommand : ICommand
    {
        private Action commandTask;
        private Func<bool> canExecuteTask;

        public ButtonCommand(Action workToDo, Func<bool> canExecute)
        {
            commandTask = workToDo;
            canExecuteTask = canExecute;
        }

        public ButtonCommand(Action workToDo)
            : this(workToDo, DefaultCanExecute)
        {
            commandTask = workToDo;
        }

        private static bool DefaultCanExecute()
        {
            return true;
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteTask != null && canExecuteTask();
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            commandTask();
        }
    }
}
