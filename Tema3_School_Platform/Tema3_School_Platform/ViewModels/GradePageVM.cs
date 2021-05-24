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
using Tema3_School_Platform.Utils;

namespace Tema3_School_Platform.ViewModels
{
    class GradePageVM : BaseVM
    {
        private ObservableCollection<Grade> grades;
        public ObservableCollection<Grade> Grades
        {
            get { return grades; }
            set
            {
                grades = value;
                NotifyPropertyChanged("Grades");
            }
        }
        public ObservableCollection<Subject> Subjects
        {
            get
            {
                return SubjectBLL.Instance.Subjects.Where(subject => TeacherSubjectClassBLL.Instance.TeacherSubjectClassList.Where(tsc
                    => tsc.Subject.ID == subject.ID && tsc.Teacher.ID == UserBLL.Instance.CurrentUser.ID).Count() != 0).ToObservableCollection();
            }
        }
        public ObservableCollection<User> Students
        {
            get
            {
                if (Subject == null)
                    return null;
                return UserBLL.Instance.Users.Where(user => StudentSubjectBLL.Instance.StudentSubjectList.Where(ss
                    => ss.Subject.ID == Subject.ID && ss.Student.ID == user.ID).Count() != 0).ToObservableCollection();
            }
        }

        private User student;
        public User Student
        {
            get { return student; }
            set
            {
                student = value;
                NotifyPropertyChanged("Student");
                SelectedGrade = null;
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
                NotifyPropertyChanged("Students");
                SelectedGrade = null;
            }
        }

        private string gradeValue;
        public string GradeValue
        {
            get { return gradeValue; }
            set
            {
                gradeValue = value;
                NotifyPropertyChanged("GradeValue");
                SelectedGrade = null;
            }
        }

        private bool semester;
        public bool Semester
        {
            get { return semester; }
            set
            {
                semester = value;
                NotifyPropertyChanged("Semester");
                SelectedGrade = null;
            }
        }

        private Grade selectedGrade;
        public Grade SelectedGrade
        {
            get { return selectedGrade; }
            set
            {
                selectedGrade = value;
                NotifyPropertyChanged("SelectedGrade");
            }
        }

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand ClearCommand { get; }

        public GradePageVM()
        {
            Clear();
            this.AddCommand = new RelayCommand<Grade>(grade => ErrorWrapper(() => { GradeBLL.Instance.AddGrade(grade); Clear(); }));
            this.RemoveCommand = new RelayCommand<Grade>(grade => ErrorWrapper(() => { GradeBLL.Instance.RemoveGrade(grade); Clear(); }));
            this.SearchCommand = new ActionCommand(Search);
            this.ClearCommand = new ActionCommand(Clear);
        }

        private void Search()
        {
            //grades = GradeBLL.Instance.Grades.Where(grade => StudentSubjectBLL.Instance.StudentSubjectList.Where(ss
            //    => ss.Student.ID == grade.StudentSubject.Student.ID && ss.Subject.ID == grade.StudentSubject.Subject.ID).Count() != 0).ToObservableCollection();
            Grades = GradeBLL.Instance.Grades.Where(grade => grade.StudentSubject.Student.ID == Student.ID && grade.StudentSubject.Subject.ID == Subject.ID).ToObservableCollection();
        }

        private void Clear()
        {
            Grades = GradeBLL.Instance.Grades.Where(grade => TeacherSubjectClassBLL.Instance.TeacherSubjectClassList.Where(tsc
                => tsc.Subject.ID == grade.StudentSubject.Subject.ID && tsc.Teacher.ID == UserBLL.Instance.CurrentUser.ID &&
                grade.Semester == Semester).Count() != 0).ToObservableCollection();
            GradeValue = String.Empty;
            Student = null;
            Subject = null;
            SelectedGrade = null;
        }
    }
}
