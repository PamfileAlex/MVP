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
    class TeacherSubjectClassVM : BaseVM
    {
        public ObservableCollection<TeacherSubjectClass> TeacherSubjectClassList { get { return TeacherSubjectClassBLL.Instance.TeacherSubjectClassList; } }
        public ObservableCollection<User> Teachers { get { return UserBLL.Instance.Users.Where(user => user.Role == User.UserRole.Professor).ToObservableCollection(); } }
        public ObservableCollection<Subject> Subjects { get { return SubjectBLL.Instance.Subjects; } }
        public ObservableCollection<Class> Classes { get { return ClassBLL.Instance.Classes; } }

        private int dataGridIndex;
        public int DataGridIndex
        {
            get { return dataGridIndex; }
            set
            {
                dataGridIndex = value;
                NotifyPropertyChanged("DataGridIndex");
                if (DataGridIndex == -1) { return; }
                TeacherIndex = -1;
                SubjectIndex = -1;
                ClassIndex = -1;
            }
        }

        private int teacherIndex;
        public int TeacherIndex
        {
            get { return teacherIndex; }
            set
            {
                teacherIndex = value;
                NotifyPropertyChanged("TeacherIndex");
                if (TeacherIndex != -1)
                    DataGridIndex = -1;
            }
        }

        private int subjectIndex;
        public int SubjectIndex
        {
            get { return subjectIndex; }
            set
            {
                subjectIndex = value;
                NotifyPropertyChanged("SubjectIndex");
                if (SubjectIndex != -1)
                    DataGridIndex = -1;
            }
        }

        private int classIndex;
        public int ClassIndex
        {
            get { return classIndex; }
            set
            {
                classIndex = value;
                NotifyPropertyChanged("ClassIndex");
                if (ClassIndex != -1)
                    DataGridIndex = -1;
            }
        }

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand ClearCommand { get; }

        public TeacherSubjectClassVM()
        {
            Clear();
            this.AddCommand = new RelayCommand<TeacherSubjectClass>(tsc => ErrorWrapper(() => { TeacherSubjectClassBLL.Instance.AddTeacherSubjectClass(tsc); Clear(); }));
            this.RemoveCommand = new RelayCommand<TeacherSubjectClass>(tsc => ErrorWrapper(() => { TeacherSubjectClassBLL.Instance.RemoveTeacherSubjectClass(tsc); Clear(); }));
            this.ClearCommand = new ActionCommand(Clear);
        }

        private void Clear()
        {
            DataGridIndex = -1;
            TeacherIndex = -1;
            SubjectIndex = -1;
            ClassIndex = -1;
        }
    }
}
