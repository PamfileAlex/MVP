using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using MVP_Tema2_Checkers.Commands;
using MVP_Tema2_Checkers.Models;
using MVP_Tema2_Checkers.Utils;

namespace MVP_Tema2_Checkers.ViewModels
{
    class AboutPageVM
    {
        public ICommand GamePageCommand { get; }
        public ICommand CloseWindowCommand { get; }
        public GameInfo GameWins => GameInfo.Instance;

        public AboutPageVM()
        {
            GamePageCommand = new ActionCommand(ViewNavigator.ChangeToGamePage);
            CloseWindowCommand = new ActionCommand(ViewNavigator.CloseWindow);
        }

        public String Foreground => "LightGray";
        public int FontSize => 40;
        public String Programmer => "Pamfile Alex";
        public String Group => "393";
        public String Email => "alex.pamfile@student.unitbv.ro";
        public String Description => "Dame este un joc pentru două persoane bazat pe strategia jucătorilor. "
                    + "Jocul este mai puțin răspândit în Germania, fiind foarte popular în schimb "
                    + "în Rusia și Olanda unde se organizează adevărate campionate.";
    }
}
