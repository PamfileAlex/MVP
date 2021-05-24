using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_School_Platform.Exceptions;
using Tema3_School_Platform.Models.DataAccessLayer;
using Tema3_School_Platform.Models.EntityLayer;

namespace Tema3_School_Platform.Models.BusinessLogicLayer
{
    class GradeBLL
    {
        public static GradeBLL Instance { get; } = new GradeBLL();
        public ObservableCollection<Grade> Grades { get; set; }
        static GradeBLL() { }
        private GradeBLL()
        {
            StudentSubjectBLL.Instance.Init();
            Grades = GradeDAL.GetGrades();
        }

        public void UpdateGrades()
        {
            Grades = GradeDAL.GetGrades();
        }

        public void AddGrade(Grade grade)
        {
            CheckFields(grade);
            GradeDAL.AddGrade(grade);
            Grade fromDB = GradeDAL.GetGrade(grade.StudentSubject, grade.Semester, grade.Value);
            if (fromDB == null)
                throw new SchoolPlatformException("Add Grade failed");
            Grades.Add(fromDB);
        }

        public void RemoveGrade(Grade grade)
        {
            if (!Grades.Remove(grade))
                throw new SchoolPlatformException("Remove Grade failed");
            GradeDAL.RemoveGrade(grade);
        }

        private void CheckFields(Grade grade)
        {
            if (grade == null || grade.StudentSubject == null || grade.Value == default)
                throw new SchoolPlatformException("Please fill all fields");
        }
    }
}
