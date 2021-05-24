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
    class AbsenceBLL
    {
        public static AbsenceBLL Instance { get; } = new AbsenceBLL();
        public ObservableCollection<Absence> Absences { get; set; }
        static AbsenceBLL() { }
        private AbsenceBLL()
        {
            StudentSubjectBLL.Instance.Init();
            Absences = AbsenceDAL.GetAbsences();
        }

        public void UpdateAbsences()
        {
            Absences = AbsenceDAL.GetAbsences();
        }

        public void AddAbsence(Absence absence)
        {
            CheckFields(absence);
            AbsenceDAL.AddAbsence(absence);
            Absence fromDB = AbsenceDAL.GetAbsence(absence.StudentSubject, absence.Semester, absence.Type);
            if (fromDB == null)
                throw new SchoolPlatformException("Add Absence failed");
            Absences.Add(fromDB);
        }

        public void RemoveAbsence(Absence absence)
        {
            if (!Absences.Remove(absence))
                throw new SchoolPlatformException("Remove Absence failed");
            AbsenceDAL.RemoveAbsence(absence);
        }

        public void ModifyAbsence(Absence absence)
        {
            if (absence.Type == Absence.AbsenceType.Unmotivated)
                absence.Type = Absence.AbsenceType.Motivated;
            else if (absence.Type == Absence.AbsenceType.Motivated)
                absence.Type = Absence.AbsenceType.Motivated;
            AbsenceDAL.ModifyAbsence(absence);
        }

        private void CheckFields(Absence absence)
        {
            if (absence == null || absence.StudentSubject == null || absence.Type == Absence.AbsenceType.None)
                throw new SchoolPlatformException("Please fill all fields");
        }
    }
}
