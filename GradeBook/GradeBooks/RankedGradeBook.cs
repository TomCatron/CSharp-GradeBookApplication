using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {

        int numOfStudents;

        public int NumOfStudents { get => numOfStudents; set => numOfStudents = value; }

        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (numOfStudents < 5)
                throw new InvalidOperationException();
            var classAverage = (int)Math.Ceiling(Students.Count * .2);
            var grade = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grade[classAverage - 1] <= averageGrade)
                return 'A';
            else if (grade[(classAverage * 2) - 1] <= averageGrade)
                return 'B';
            else if (grade[(classAverage * 3) - 1] <= averageGrade)
                return 'C';
            else if (grade[(classAverage * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if(numOfStudents < 5)
                Console.Write("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade");
            else
                base.CalculateStatistics();
        }
    }
}
