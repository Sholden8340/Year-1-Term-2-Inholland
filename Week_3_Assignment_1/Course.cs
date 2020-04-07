using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Course
    {
        public enum PracticalGrade
        { 
            None, 
            Absent, 
            Insufficient, 
            Sufficient,
            Good
        };

        public string Name { get; set; }
        public int Grade { get; set; }
        public PracticalGrade Practical { get; set; }
        public bool Passed { get; set; }
        public bool CumLaude { get; set; }


        PracticalGrade ReadPracticalGrade(string question)
        {
            GetInput scan = new GetInput();
            int input;
            
            do
            {
                input = scan.ReadInt(question, 0 , 4);

            } while (!Enum.IsDefined(typeof(PracticalGrade), input));

            //PracticalGrade output;
            return (PracticalGrade)Enum.Parse(typeof(PracticalGrade), input.ToString(), true); //whyyyyy
        }
        public void DisplayPracticalGrade(PracticalGrade practical)
        {
            Console.Write("Practical grade for {0}: {1}", Name, Practical);
        }
        public void ReadCourse(string question)
        {
            GetInput scan = new GetInput();

            Name = scan.ReadString(question);
            Grade = scan.ReadInt(String.Format("Enter grade for {0} ", Name), 0, 101);
            Console.WriteLine("0. None 1. Absent 2. Insufficient 3. Sufficient 4. Good");
            Practical = ReadPracticalGrade("Enter the practical grade ");
            
            IsPassed();
        }


        public void DisplayCourse(Course course)
        {
            Console.WriteLine("{0} : {1} {2}", course.Name, course.Grade, course.Practical); //name, grade, practical
        }


        private void IsPassed()
        {
            //A course is passed if the grade is 55 or higher and the practical grade is Sufficient or Good.
            if( (Practical.Equals(PracticalGrade.Good) || Practical.Equals(PracticalGrade.Sufficient) )&& Grade >= 55)
            {
                Passed = true;
                IsCumLaude();
            }
        }
        private void IsCumLaude()
        {
            //A course is passed Cum Laude if the grade is 80 or higher and the practical grade is Good.
            if (Practical.Equals(PracticalGrade.Good) && Grade >= 80)
            {
                CumLaude = true;
            }
        }


    }
}
