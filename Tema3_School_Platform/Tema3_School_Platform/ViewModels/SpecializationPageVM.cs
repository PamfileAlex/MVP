using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3_School_Platform.Commands;
using Tema3_School_Platform.Models.BusinessLogicLayer;
using Tema3_School_Platform.Models.EntityLayer;

namespace Tema3_School_Platform.ViewModels
{
    class SpecializationPageVM : BaseVM
    {
        public ObservableCollection<Specialization> Specializations { get { return SpecializationBLL.Instance.Specializations; } }

        private Specialization specialization;
        public Specialization Specialization
        {
            get { return specialization; }
            set
            {
                specialization = value;
                NotifyPropertyChanged("Specialization");
            }
        }

        private int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                NotifyPropertyChanged("SelectedIndex");
                ErrorMessage = String.Empty;
                if (SelectedIndex == -1) { Specialization = new Specialization(0); return; }
                Specialization = new Specialization(SpecializationBLL.Instance.Specializations[SelectedIndex]);
            }
        }

        public ICommand AddCommand { get; }
        public ICommand ModifyCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand ClearCommand { get; }

        public SpecializationPageVM()
        {
            Specialization = new Specialization(0);
            Clear();
            this.AddCommand = new RelayCommand<Specialization>(specialization => ErrorWrapper(() => { SpecializationBLL.Instance.AddSpecialization(specialization); Clear(); }));
            this.ModifyCommand = new RelayCommand<Specialization>(specialization => ErrorWrapper(() => { SpecializationBLL.Instance.ModifySpecialization(specialization, SelectedIndex); Clear(); }));
            this.RemoveCommand = new RelayCommand<Specialization>(specialization => ErrorWrapper(() => { SpecializationBLL.Instance.RemoveSpecialization(SpecializationBLL.Instance.Specializations[SelectedIndex]); Clear(); }));
            this.ClearCommand = new ActionCommand(Clear);
        }

        private void Clear()
        {
            SelectedIndex = -1;
        }
    }
}
