using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public Student()
        {
        }

        public Student(string name, string surname, string familyname)
        {
            Name = name;
            Surname = surname;
            FamilyName = familyname;
        }

        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FamilyName { get; set; }
        public byte[] Photo { get; set; }
        public string FacultyNumber { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

    }
}
