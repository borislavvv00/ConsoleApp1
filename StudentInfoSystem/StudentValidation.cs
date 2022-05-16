using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    class StudentValidation
    {
        Student GetStudentDataByUser(User user)
        {

            if (user.FacultyNumber == null)
                return null;
            else
            {
                //Student st = new Student();
                //st.faculty_num = user.fac_num;
                //return st;
                return new Student();
            }
        }

    }
}
