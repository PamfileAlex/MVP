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
    class StudentSubjectBLL
    {
        public static StudentSubjectBLL Instance { get; } = new StudentSubjectBLL();
        public ObservableCollection<StudentSubject> StudentSubjectList { get; set; }
        static StudentSubjectBLL() { }
        private StudentSubjectBLL()
        {
            UserBLL.Instance.Init();
            SubjectBLL.Instance.Init();
            StudentSubjectList = StudentSubjectDAL.GetStudentSubjectList();
        }

        public void UpdateStudentSubjectList()
        {
            StudentSubjectList = StudentSubjectDAL.GetStudentSubjectList();
        }

        public void AddStudentSubject(StudentSubject studentSubject)
        {
            CheckFields(studentSubject);
            CheckExistence(studentSubject);
            StudentSubjectDAL.AddStudentSubject(studentSubject);
            StudentSubject fromDB = StudentSubjectDAL.GetStudentSubject(studentSubject.Student.ID, studentSubject.Subject.ID);
            if (fromDB == null)
                throw new SchoolPlatformException("Add StudentSubject failed");
            StudentSubjectList.Add(fromDB);
        }

        public void RemoveStudentSubject(StudentSubject studentSubject)
        {
            if (!StudentSubjectList.Remove(studentSubject))
                throw new SchoolPlatformException("Remove TeacherSubjectClass failed");
            StudentSubjectDAL.RemoveStudentSubject(studentSubject);
        }

        private void CheckFields(StudentSubject studentSubject)
        {
            if (studentSubject.Student == null || studentSubject.Subject == null)
                throw new SchoolPlatformException("Please fill all fields");
        }

        private void CheckExistence(StudentSubject studentSubject)
        {
            if (StudentSubjectList.Where(ss => ss.Student.ID == studentSubject.Student.ID && ss.Subject.ID == studentSubject.Subject.ID).Count() != 0)
                throw new SchoolPlatformException("Relation already exists");
        }
    }
}
