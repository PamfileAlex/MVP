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
    class SpecializationSubjectPageVM : BaseVM
    {
        public ObservableCollection<Specialization> Specializations { get { return SpecializationBLL.Instance.Specializations; } }
        public ObservableCollection<Subject> Subjects { get { return SubjectBLL.Instance.Subjects; } }

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

        private Subject subject;
        public Subject Subject
        {
            get { return subject; }
            set
            {
                subject = value;
                NotifyPropertyChanged("Subject");
            }
        }

        private int specializationSelectedIndex;
        public int SpecializationSelectedIndex
        {
            get { return specializationSelectedIndex; }
            set
            {
                specializationSelectedIndex = value;
                NotifyPropertyChanged("SpecializationSelectedIndex");
                ErrorMessage = String.Empty;
                if (SpecializationSelectedIndex == -1) { Specialization = new Specialization(0); return; }
                Specialization = new Specialization(SpecializationBLL.Instance.Specializations[SpecializationSelectedIndex]);
            }
        }

        private int subjectSelectedIndex;
        public int SubjectSelectedIndex
        {
            get { return subjectSelectedIndex; }
            set
            {
                subjectSelectedIndex = value;
                NotifyPropertyChanged("SubjectSelectedIndex");
                ErrorMessage = String.Empty;
                if (SubjectSelectedIndex == -1) { Subject = new Subject(0); return; }
                Subject = new Subject(SubjectBLL.Instance.Subjects[SubjectSelectedIndex]);
            }
        }

        public ICommand SpecializationAddCommand { get; }
        public ICommand SpecializationModifyCommand { get; }
        public ICommand SpecializationRemoveCommand { get; }
        public ICommand SpecializationClearCommand { get; }
        public ICommand SubjectAddCommand { get; }
        public ICommand SubjectModifyCommand { get; }
        public ICommand SubjectRemoveCommand { get; }
        public ICommand SubjectClearCommand { get; }

        public SpecializationSubjectPageVM()
        {
            Specialization = new Specialization(0);
            Clear();
            this.SpecializationAddCommand = new RelayCommand<Specialization>(specialization => ErrorWrapper(() => { SpecializationBLL.Instance.AddSpecialization(specialization); Clear(); }));
            this.SpecializationModifyCommand = new RelayCommand<Specialization>(specialization => ErrorWrapper(() => { SpecializationBLL.Instance.ModifySpecialization(specialization, SpecializationSelectedIndex); Clear(); }));
            this.SpecializationRemoveCommand = new RelayCommand<Specialization>(specialization => ErrorWrapper(() => { SpecializationBLL.Instance.RemoveSpecialization(SpecializationBLL.Instance.Specializations[SpecializationSelectedIndex]); Clear(); }));
            this.SpecializationClearCommand = new ActionCommand(Clear);
            this.SubjectAddCommand = new RelayCommand<Subject>(subject => ErrorWrapper(() => { SubjectBLL.Instance.AddSubject(subject); Clear(); }));
            this.SubjectModifyCommand = new RelayCommand<Subject>(subject => ErrorWrapper(() => { SubjectBLL.Instance.ModifySubject(subject, SubjectSelectedIndex); Clear(); }));
            this.SubjectRemoveCommand = new RelayCommand<Subject>(subject => ErrorWrapper(() => { SubjectBLL.Instance.RemoveSubject(SubjectBLL.Instance.Subjects[SubjectSelectedIndex]); Clear(); }));
            this.SubjectClearCommand = new ActionCommand(Clear);
        }

        private void Clear()
        {
            SpecializationSelectedIndex = -1;
            SubjectSelectedIndex = -1;
        }
    }
}
