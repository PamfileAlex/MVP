using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_School_Platform.Models.EntityLayer;

namespace Tema3_School_Platform.Models.DataAccessLayer
{
    static class TeachingMaterialDAL
    {
        public static ObservableCollection<TeachingMaterial> GetTeachingMaterials()
        {
            return new ObservableCollection<TeachingMaterial>();
        }

        public static void RemoveTeachingMaterial(TeachingMaterial teacherSubjectClass)
        {
            throw new NotImplementedException();
        }

        public static void AddTeachingMaterial(TeachingMaterial teacherSubjectClass)
        {
            throw new NotImplementedException();
        }

        public static TeachingMaterial GetTeachingMaterial(int iD, string name)
        {
            throw new NotImplementedException();
        }
    }
}
