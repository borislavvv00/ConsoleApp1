using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class StudentData
    {
        private static List<Student> testStudents;
        public static List<Student> TestStudents
        {
            get
            {
                Reset_test_student_data();
                return testStudents;
            }
            set { }
        }

        public static Student IsThereStudent(string facNumber)
        {
            StudentInfoContext context = new StudentInfoContext();

            Student result = (from st in context.Students
                              where st.FacultyNumber == facNumber
                              select st).First();
            return result;
        }

        private static void Reset_test_student_data()
        {
            if (testStudents == null)
            {
                testStudents = new List<Student>();
                testStudents.Add(new Student());
                /*testStudents[0].firstName = "asdf";
                testStudents[0].secondName = "qwer";
                testStudents[0].lastName = "zxcv";
                testStudents[0].faculty = "FKST";
                testStudents[0].speciality = "KSI";
                testStudents[0].degree = "bachelor";
                testStudents[0].status = (int)Student_status.GRADUATED;
                testStudents[0].facultyNum = "1111111111";
                testStudents[0].course = 5;
                testStudents[0].flow = 1;
                testStudents[0].group = 30;*/

            }
        }
    }
}
