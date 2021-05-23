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
    class SubjectSpecializationPageVM : BaseVM
    {
        public ObservableCollection<Specialization> Specializations { get { return SpecializationBLL.Instance.Specializations; } }
        public ObservableCollection<Subject> Subjects { get { return SubjectBLL.Instance.Subjects; } }
        public ObservableCollection<SubjectSpecialization> SubjectSpecializations { get { return SubjectSpecializationBLL.Instance.SubjectSpecializations; } }

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

        public bool Thesis
        {
            get
            {
                if (SubjectSpecializationSelectedIndex == -1)
                    return false;
                return SubjectSpecializationBLL.Instance.SubjectSpecializations[SubjectSpecializationSelectedIndex].Thesis;
            }
            set
            {
                SubjectSpecialization subjectSpecialization = SubjectSpecializationBLL.Instance.SubjectSpecializations[SubjectSpecializationSelectedIndex];
                subjectSpecialization.Thesis = !Thesis;
                NotifyPropertyChanged("Thesis");
                SubjectSpecializationBLL.Instance.ModifySubjectSpecialization(subjectSpecialization);
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
                NotifyPropertyChanged("CanAddSubjectSpecialization");
                ErrorMessage = String.Empty;
                if (SpecializationSelectedIndex != -1)
                    SubjectSpecializationSelectedIndex = -1;
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
                NotifyPropertyChanged("CanAddSubjectSpecialization");
                ErrorMessage = String.Empty;
                if (SubjectSelectedIndex != -1)
                    SubjectSpecializationSelectedIndex = -1;
                if (SubjectSelectedIndex == -1) { Subject = new Subject(0); return; }
                Subject = new Subject(SubjectBLL.Instance.Subjects[SubjectSelectedIndex]);
            }
        }

        private int subjectSpecializationSelectedIndex;
        public int SubjectSpecializationSelectedIndex
        {
            get { return subjectSpecializationSelectedIndex; }
            set
            {
                subjectSpecializationSelectedIndex = value;
                NotifyPropertyChanged("SubjectSpecializationSelectedIndex");
                if (SubjectSpecializationSelectedIndex != -1)
                {
                    SubjectSelectedIndex = -1;
                    SpecializationSelectedIndex = -1;
                }
            }
        }

        public bool CanAddSubjectSpecialization
        {
            get
            {
                if (SubjectSelectedIndex == -1 || SpecializationSelectedIndex == -1) { return false; }
                int index = SubjectSpecializationBLL.Instance.IndexOfSubjectSpecialization(Subjects[SubjectSelectedIndex].ID, Specializations[SpecializationSelectedIndex].ID);
                if (index == -1) { return true; }
                SubjectSpecializationSelectedIndex = index;
                return false;
            }
        }

        public ICommand SpecializationAddCommand { get; }
        public ICommand SpecializationModifyCommand { get; }
        public ICommand SpecializationRemoveCommand { get; }

        public ICommand SubjectAddCommand { get; }
        public ICommand SubjectModifyCommand { get; }
        public ICommand SubjectRemoveCommand { get; }

        public ICommand SubjectSpecializationAddCommand { get; }
        public ICommand SubjectSpecializationRemoveCommand { get; }

        public ICommand ClearCommand { get; }

        public SubjectSpecializationPageVM()
        {
            Specialization = new Specialization(0);
            Clear();
            this.SpecializationAddCommand = new RelayCommand<Specialization>(specialization => ErrorWrapper(() => { SpecializationBLL.Instance.AddSpecialization(specialization); Clear(); }));
            this.SpecializationModifyCommand = new RelayCommand<Specialization>(specialization => ErrorWrapper(() => { SpecializationBLL.Instance.ModifySpecialization(specialization, SpecializationSelectedIndex); Clear(); }));
            this.SpecializationRemoveCommand = new RelayCommand<Specialization>(specialization => ErrorWrapper(() => { SpecializationBLL.Instance.RemoveSpecialization(SpecializationBLL.Instance.Specializations[SpecializationSelectedIndex]); Clear(); }));
            this.SubjectAddCommand = new RelayCommand<Subject>(subject => ErrorWrapper(() => { SubjectBLL.Instance.AddSubject(subject); Clear(); }));
            this.SubjectModifyCommand = new RelayCommand<Subject>(subject => ErrorWrapper(() => { SubjectBLL.Instance.ModifySubject(subject, SubjectSelectedIndex); Clear(); }));
            this.SubjectRemoveCommand = new RelayCommand<Subject>(subject => ErrorWrapper(() => { SubjectBLL.Instance.RemoveSubject(SubjectBLL.Instance.Subjects[SubjectSelectedIndex]); Clear(); }));
            this.SubjectSpecializationAddCommand = new RelayCommand<SubjectSpecialization>(SubjectSpecializationBLL.Instance.AddSubjectSpecialization);
            this.SubjectSpecializationRemoveCommand = new RelayCommand<SubjectSpecialization>(SubjectSpecializationBLL.Instance.RemoveSubjectSpecialization);
            this.ClearCommand = new ActionCommand(Clear);
        }

        private void Clear()
        {
            SpecializationSelectedIndex = -1;
            SubjectSelectedIndex = -1;
            SubjectSpecializationSelectedIndex = -1;
        }
    }
}
