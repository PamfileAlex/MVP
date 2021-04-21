using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using MVP_Tema2_Checkers.Commands;
using MVP_Tema2_Checkers.Models;
using MVP_Tema2_Checkers.Utils;

namespace MVP_Tema2_Checkers.ViewModels
{
    class GamePageVM
    {
        public GameVM GameVM { get; }
        public ICommand AboutPageCommand { get; }
        public ICommand CloseWindowCommand { get; }
        public ICommand NewGameCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }
        public ICommand MultipleJumpCommand { get; }

        public GamePageVM()
        {
            GameVM = new GameVM();
            AboutPageCommand = new ActionCommand(ViewNavigator.ChangeToAboutPage);
            CloseWindowCommand = new ActionCommand(ViewNavigator.CloseWindow);
            MultipleJumpCommand = new ActionCommand(MultipleJumpAction, CanExecuteMJ);
            NewGameCommand = new ActionCommand(GameVM.ResetGame);
            SaveCommand = new RelayCommand<Game>(Serializer.Serialize);
            LoadCommand = new ActionCommand(LoadAction);
        }

        private void MultipleJumpAction()
        {
            //GameVM.GameInfo.MultipleJump = !GameVM.GameInfo.MultipleJump;
        }

        private bool CanExecuteMJ()
        {
            return !GameVM.Game.IsRunning;
        }

        private void LoadAction()
        {
            GameVM.Init(Serializer.Desirialize());
        }
    }
}
