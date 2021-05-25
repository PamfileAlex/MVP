using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3_School_Platform.Commands;
using Tema3_School_Platform.Exceptions;
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
                Reset();
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
                Reset();
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
                Reset();
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
                Reset();
            }
        }

        private bool thesis;
        public bool Thesis
        {
            get { return thesis; }
            set
            {
                thesis = value;
                NotifyPropertyChanged("Thesis");
                Reset();
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

        private String finalGrade;
        public String FinalGrade
        {
            get { return finalGrade; }
            set
            {
                finalGrade = value;
                NotifyPropertyChanged("FinalGrade");
            }
        }

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand FinalGradeCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand ClearCommand { get; }

        public GradePageVM()
        {
            Clear();
            this.AddCommand = new RelayCommand<Grade>(grade => ErrorWrapper(() => { GradeBLL.Instance.AddGrade(grade); Clear(); }));
            this.RemoveCommand = new RelayCommand<Grade>(grade => ErrorWrapper(() => { GradeBLL.Instance.RemoveGrade(grade); Clear(); }));
            this.FinalGradeCommand = new ActionCommand(() => ErrorWrapper(CalculateFinalGrade));
            this.SearchCommand = new ActionCommand(Search);
            this.ClearCommand = new ActionCommand(Clear);
        }

        private void CalculateFinalGrade()
        {
            List<Grade> finalGrades = Grades.Where(grade => grade.Semester == Semester && grade.StudentSubject.Student.ID == Student.ID && grade.StudentSubject.Subject.ID == Subject.ID).ToList();
            SubjectSpecialization subjectSpecialization;
            try
            {
                subjectSpecialization = SubjectSpecializationBLL.Instance.SubjectSpecializations.First(ss => ss.Subject.ID == Subject.ID && ss.Specialization.ID == Student.Class.Specialization.ID);
            }
            catch { throw new SchoolPlatformException("FinalGrade failed"); }
            bool hasThesis = subjectSpecialization.Thesis;
            Grade thesisGrade = null;
            if (hasThesis && finalGrades.Where(grade => grade.Thesis).Count() == 0)
            {
                try
                {
                    thesisGrade = finalGrades.First(grade => grade.Thesis);
                    finalGrades.Remove(thesisGrade);
                }
                catch { throw new SchoolPlatformException("There is no thesis"); }
            }
            if (finalGrades.Count() < (hasThesis ? 4 : 3))
            {
                throw new SchoolPlatformException("Not enought grades");
            }
            float result = finalGrades.Select(grade => grade.Value).Average();
            if (hasThesis && thesisGrade != null)
            {
                result = (result + thesisGrade.Value) / 2;
            }
            FinalGrade = Math.Round(result, 2).ToString();
            //StudentSubjectBLL.Instance.LockStudentSubject(StudentSubjectBLL.Instance.GetStudentSubject(Student.ID, Subject.ID), Semester);
        }

        private void Search()
        {
            //grades = GradeBLL.Instance.Grades.Where(grade => StudentSubjectBLL.Instance.StudentSubjectList.Where(ss
            //    => ss.Student.ID == grade.StudentSubject.Student.ID && ss.Subject.ID == grade.StudentSubject.Subject.ID).Count() != 0).ToObservableCollection();
            Grades = GradeBLL.Instance.Grades.Where(grade => grade.StudentSubject.Student.ID == Student.ID && grade.StudentSubject.Subject.ID == Subject.ID && grade.Semester == Semester).ToObservableCollection();
        }

        private void Clear()
        {
            Grades = GradeBLL.Instance.Grades.Where(grade => TeacherSubjectClassBLL.Instance.TeacherSubjectClassList.Where(tsc
                => tsc.Subject.ID == grade.StudentSubject.Subject.ID && tsc.Teacher.ID == UserBLL.Instance.CurrentUser.ID).Count() != 0).ToObservableCollection();
            GradeValue = String.Empty;
            Student = null;
            Subject = null;
            SelectedGrade = null;
            Semester = false;
            Thesis = false;
            ErrorMessage = String.Empty;
        }

        private void Reset()
        {
            SelectedGrade = null;
            FinalGrade = String.Empty;
            ErrorMessage = String.Empty;
        }
    }
}
