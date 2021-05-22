using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tema3_School_Platform.Models.EntityLayer;

namespace Tema3_School_Platform.ViewModels
{
    class ClassPageVM
    {
        public ObservableCollection<Class> Classes { get; }
    }
}
