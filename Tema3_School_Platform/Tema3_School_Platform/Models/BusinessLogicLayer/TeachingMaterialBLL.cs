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
    class TeachingMaterialBLL
    {
        public static TeachingMaterialBLL Instance { get; } = new TeachingMaterialBLL();
        public ObservableCollection<TeachingMaterial> TeachingMaterials { get; private set; }
        static TeachingMaterialBLL() { }
        private TeachingMaterialBLL()
        {
            StudentSubjectBLL.Instance.Init();
            TeachingMaterials = TeachingMaterialDAL.GetTeachingMaterials();
        }

        public void UpdateTeachingMaterials()
        {
            TeachingMaterials = TeachingMaterialDAL.GetTeachingMaterials();
        }

        public void AddTeachingMaterial(TeachingMaterial teachingMaterial)
        {
            CheckFields(teachingMaterial);
            TeachingMaterialDAL.AddTeachingMaterial(teachingMaterial);
            TeachingMaterial fromDB = TeachingMaterialDAL.GetTeachingMaterial(teachingMaterial.TeacherSubjectClass.ID, teachingMaterial.Name);
            if (fromDB == null)
                throw new SchoolPlatformException("Add TeachingMaterial failed");
            TeachingMaterials.Add(fromDB);
        }

        public void RemoveTeachingMaterial(TeachingMaterial teacherSubjectClass)
        {
            if (!TeachingMaterials.Remove(teacherSubjectClass))
                throw new SchoolPlatformException("Remove TeachingMaterial failed");
            TeachingMaterialDAL.RemoveTeachingMaterial(teacherSubjectClass);
        }
        private void CheckFields(TeachingMaterial teachingMaterial)
        {
            if (teachingMaterial.TeacherSubjectClass == null || String.IsNullOrEmpty(teachingMaterial.Name))
                throw new SchoolPlatformException("Please fill all fields");
            if (TeachingMaterials.Where(tm => tm.Name.Equals(teachingMaterial.Name)).Count() != 0)
                throw new SchoolPlatformException("Name is taken");
        }

    }
}
