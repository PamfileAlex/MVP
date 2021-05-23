using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_School_Platform.Models.EntityLayer
{
    class Grade
    {
        public int ID { get; set; }
        public StudentSubject StudentSubject { get; set; }
        public bool Semester { get; set; }
        public float Value { get; set; }

        public Grade() { }
        public Grade(Grade other)
        {
            this.ID = other.ID;
            this.StudentSubject = other.StudentSubject;
            this.Semester = other.Semester;
            this.Value = other.Value;
        }
    }
}
