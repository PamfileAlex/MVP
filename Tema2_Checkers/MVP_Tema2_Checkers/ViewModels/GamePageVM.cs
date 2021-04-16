using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using MVP_Tema2_Checkers.Commands;
using MVP_Tema2_Checkers.Utils;

namespace MVP_Tema2_Checkers.ViewModels
{
    class GamePageVM
    {
        public GameVM GameVM { get; }
        public ICommand AboutPageCommand { get; }
        public ICommand CloseWindowCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }
        public ICommand MultipleJumpCommand { get; }

        public GamePageVM()
        {
            GameVM = new GameVM();
            AboutPageCommand = new ButtonCommand(ViewNavigator.ChangeToAboutPage);
            CloseWindowCommand = new ButtonCommand(ViewNavigator.CloseWindow);
            MultipleJumpCommand = new ButtonCommand(MultipleJumpAction, CanExecuteMJ);
        }

        private void MultipleJumpAction()
        {
            GameVM.MultipleJump = !GameVM.MultipleJump;
        }

        private bool CanExecuteMJ()
        {
            return !GameVM.IsRunning;
        }
    }
}
