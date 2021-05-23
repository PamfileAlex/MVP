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
    class SubjectSpecializationBLL
    {
        public static SubjectSpecializationBLL Instance { get; } = new SubjectSpecializationBLL();
        public ObservableCollection<SubjectSpecialization> SubjectSpecializations { get; set; }
        static SubjectSpecializationBLL() { }
        private SubjectSpecializationBLL()
        {
            SubjectBLL.Instance.Init();
            SpecializationBLL.Instance.Init();
            SubjectSpecializations = SubjectSpecializationDAL.GetSubjectSpecializations();
        }

        public void UpdateSubjectSpecializations()
        {
            SubjectSpecializations = SubjectSpecializationDAL.GetSubjectSpecializations();
        }

        public void AddSubjectSpecialization(SubjectSpecialization subjectSpecialization)
        {
            SubjectSpecializationDAL.AddSubjectSpecialization(subjectSpecialization);
            SubjectSpecialization fromDB = SubjectSpecializationDAL.GetSubjectSpecialization(subjectSpecialization.Subject.ID, subjectSpecialization.Specialization.ID);
            if (fromDB == null)
                throw new SchoolPlatformException("Add SubjectSpecialization failed");
            SubjectSpecializations.Add(fromDB);
        }

        public void RemoveSubjectSpecialization(SubjectSpecialization subjectSpecialization)
        {
            if (!SubjectSpecializations.Remove(subjectSpecialization))
                throw new SchoolPlatformException("Remove SubjectSpecialization failed");
            SubjectSpecializationDAL.RemoveSubjectSpecialization(subjectSpecialization);
        }

        public void ModifySubjectSpecialization(SubjectSpecialization subjectSpecialization)
        {
            SubjectSpecializationDAL.ModifySubjectSpecialization(subjectSpecialization);
        }

        public int IndexOfSubjectSpecialization(int subjectID, int specializationID)
        {
            try
            {
                SubjectSpecialization subjectSpecializationItem = SubjectSpecializations.First(subjectSpecialization => subjectSpecialization.Subject.ID == subjectID && subjectSpecialization.Specialization.ID == specializationID);
                return SubjectSpecializations.IndexOf(subjectSpecializationItem);
            }
            catch
            {
                return -1;
            }
        }
    }
}
