using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserLogin;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User User { get; set; }
        public List<string> StudStatusChoices { get; set; }
        public MainWindow()
        {
            this.DataContext = this;

            if(TestStudentsIfEmpty())
                CopyTestStudents();

            FillStudStatusChoices();
            InitializeComponent();
        }

        public MainWindow(User user) : base()
        {
            User = user;
        }

        int index = 0;

        private List<Student> testStudents;
        public List<Student> TestStudents
        {
            get
            {
                if (testStudents == null)
                {
                    testStudents = new List<Student>()
                    {
                        new Student()
                        {
                            Name = "Petar",
                            Surname = "Petrov",
                            FamilyName = "Petrvo",
                            //faculty = "FKST",
                            //speciality = "KSI",
                            //degree = "bachelor",
                            //status = (int)Student_status.GRADUATED,
                            FacultyNumber = "111111111",
                            //course = 5,
                            //flow = 1,
                            //group = 30,
                        },
                        new Student()
                        {
                            Name = "Georgi",
                            Surname = "Gerogiev",
                            FamilyName = "Georgiev",
                            //faculty = "FKST",
                            //speciality = "KSI",
                            //degree = "bachelor",
                            //status = (int)Student_status.GRADUATED,
                            FacultyNumber = "111111113",
                            //course = 5,
                            //flow = 1,
                            //group = 30,
                        },
                        new Student()
                        {
                            Name = "Alexander",
                            Surname = "Alexandrov",
                            FamilyName = "Alexandrov",
                            //faculty = "FKST",
                            //speciality = "KSI",
                            //degree = "bachelor",
                            //status = (int)Student_status.GRADUATED,
                            FacultyNumber = "111111114",
                            //course = 5,
                            //flow = 1,
                            //group = 30,
                        },
                        new Student()
                        {
                            Name = "Ivan",
                            Surname = "Ivanov",
                            FamilyName = "Ivanov",
                            //faculty = "FKST",
                            //speciality = "KSI",
                            //degree = "bachelor",
                            //status = (int)Student_status.GRADUATED,
                            FacultyNumber = "111111115",
                            //course = 5,
                            //flow = 1,
                            //group = 30,
                        }
                    };
                }
                return testStudents;
            }
        }

        private Student teststud;
        public Student Teststud
        {
            get
            {
                return teststud;
            }
            set
            {
                Student_Validity_Check(value);
            }
        }
        private void Student_Validity_Check(Student st)
        {
            if (st == null)
            {
                Clear_Controls();
                DeactivateAllControl();
            }
            else
            {
                ActivateAllControl();
                Fill_With_Student(st);
                teststud = st;
            }
        }
        public void Clear_Controls()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
        }
        public void Fill_With_Student(Student st)
        {
            name_txtbox.Text = st.Name;
            //sec_name_txtbox.Text = st.secondName;
            last_name_txtbox.Text = st.Surname;
            //faculty_txtbox.Text = st.faculty;
            //spec_txtbox.Text = st.speciality;
            //degree_txtbox.Text = st.degree;
            //status_txtbox.Text = ((Student_status)st.status).ToString();
            fac_num_txtbox.Text = st.FacultyNumber;
            //course_txtbox.Text = st.course.ToString();
            //flow_txtbox.Text = st.flow.ToString();
            //group_txtbox.Text = st.group.ToString();
        }
        public void DeactivateAllControl()
        {
            //MainGrid.IsEnabled = false;
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;
                }
            }
        }
        public void ActivateAllControl()
        {
            //MainGrid.IsEnabled = true;
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;
                }
            }
        }

        private void ClearAllButt_Click(object sender, RoutedEventArgs e)
        {
            Clear_Controls();
        }

        private void SendStudentButt_Click(object sender, RoutedEventArgs e)
        {
            /*Student st = new Student();
            st.firstName = "asdf";
            st.secondName = "qwer";
            st.lastName = "zxcv";
            st.faculty = "FKST";
            st.speciality = "KSI";
            st.degree = "bachelor";
            st.status = (int)Student_status.GRADUATED;
            st.facultyNum = "111111111";
            st.course = 5;
            st.flow = 1;
            st.group = 30;
            //fill_with_student(st);
            Teststud = st;*/
        }

        private void DeactivateButt_Click(object sender, RoutedEventArgs e)
        {
            DeactivateAllControl();
        }

        private void ActivateButt_Click(object sender, RoutedEventArgs e)
        {
            ActivateAllControl();
        }

        private void TestStudButt_Click(object sender, RoutedEventArgs e)
        {
            Student st = null;
            Teststud = st;
        }

        private void ShowTestUser_Click(object sender, RoutedEventArgs e)
        {
            MessageLbl.Content = "Program is in test mode";

            if (index > TestStudents.Count - 1)
            {
                index = 0;
            }
            Fill_With_Student(TestStudents[index]);
            index++;
        }

        public void OnLogin(User user)
        {
            var stud = TestStudents.Where(t => t.FacultyNumber == user.FacultyNumber).FirstOrDefault();
            if (stud != null)
            {
                Fill_With_Student(stud);
            }
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            clear_all_butt.Visibility = Visibility.Hidden;
            deactivate_butt.Visibility = Visibility.Hidden;
            activate_butt.Visibility = Visibility.Hidden;
            showTestUser.Visibility = Visibility.Hidden;

            LoginWindow loginWindow = new LoginWindow(OnLogin);
            loginWindow.Show();
        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();

            using(IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery = @"SELECT StatusDescr
                                    FROM StudStatus";

                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();

                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();

                bool notEndOfResult;

                notEndOfResult = reader.Read();

                while(notEndOfResult)
                {
                    string s = reader.GetString(0);

                    StudStatusChoices.Add(s);

                    notEndOfResult = reader.Read();
                }
            }
        }

        private bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();

            IEnumerable<Student> queryStudents = context.Students;

            int countStudents = queryStudents.Count();

            if (countStudents == 0)
                return true;

            return false;
        }

        private void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();

            foreach(var st in context.Students)
            {
                context.Students.Add(st);
            }
            context.SaveChanges();
        }
    }
}
