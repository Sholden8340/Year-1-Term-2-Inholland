using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program Course = new Program();
            Course.Start();
        }
        void Start()
        {
            List<Course> report = ReadReport(3);

/*            Course test = new Course();
            test.Name = "Arr";
            test.Grade = 90;
            test.Practical = Course.PracticalGrade.Good;

            Course test2 = new Course();
            test2.Name = "Arr333";
            test2.Grade = 55;
            test2.Practical = Course.PracticalGrade.Sufficient;

            Course test3 = new Course();
            test3.Name = "Arr1241241";
            test3.Grade = 55;
            test3.Practical = Course.PracticalGrade.Absent;

            report.Add(test);
            report.Add(test2);
            report.Add(test3);*/

            DisplayReport(report);

            Console.ReadKey();

        }

        List<Course> ReadReport(int nrOfCourses)
        {
            List<Course> output = new List<Course>();

            for (int i = 0; i < nrOfCourses; i++)
            {
                output.Add(new Course());
                output[i].ReadCourse("Enter a course: ");

                Console.WriteLine();
            }

            return output;
        }

        void DisplayReport(List<Course> report)
        {
            bool cumLaude = true, pass = true;
            int failed = 0;

            foreach(Course course in report)
            {
                Console.WriteLine("{0} : {1} {2}", course.Name, course.Grade, course.Practical);

                if (!course.Passed)
                {
                    //Console.WriteLine(course.Passed);
                    pass = false;
                    failed++;
                }

                if (!course.CumLaude)
                    cumLaude = false;
            }
            if (cumLaude)
            {
                Console.WriteLine("Congratulations you passed Cum Laude");
            }            
            else if (pass)
            {
                Console.WriteLine("Congratulations you passed");
            }
            else
            {
                Console.WriteLine("Unfortunately you did not pass. You have {0} retakes", failed);
            }
        }
    }
}
