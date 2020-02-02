using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDay2
{
    class Program
    {
        public void OutputInformation(object person)
        {
            if (person is null) {
                Console.WriteLine($"IF : Object {nameof(person)} is null");
            }
            else
            {
                if (person is Student student)
                {
                    Console.WriteLine($"IF : Student {student.Name} {student.LastName} " +
                        $"is enrolled for courses {String.Join<int>(", ", student.CourseCodes)}");
                }
                if (person is Professor prof)
                {
                    Console.WriteLine($"IF : Professor {prof.Name} {prof.LastName} " +
                        $"teaches {  String.Join<string>(",", prof.TeachesSubjects)}");
                }
            }

            switch (person)
            {
                case Professor prof:
                    Console.WriteLine($"SWITCH : Professor {prof.Name} {prof.LastName} " +
                        $"teaches {  String.Join<string>(",", prof.TeachesSubjects)}");
                    break;

                case Student student when (student.CourseCodes.Contains(500)):
                    Console.WriteLine($"SWITCH : Student {student.Name} {student.LastName} is enrolled for course 500.");
                    break;

                case Student student:
                    Console.WriteLine($"SWITCH : Student {student.Name} {student.LastName} " +
                        $"is enrolled for courses {String.Join<int>(", ", student.CourseCodes)}");
                    break;

                case null:
                    Console.WriteLine($"SWITCH : Object {nameof(person)} is null");
                    break;

                default:
                    Console.WriteLine("SWITCH : Unknown object detected");
                    break;
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Student student = new Student();
            student.Name = "Dirk";
            student.LastName = "Strauss";
            student.CourseCodes = new List<int> { 203, 202, 101 };
            program.OutputInformation(student);
            Student studentOne = null;
            program.OutputInformation(studentOne);
            Student studentTwo = new Student();
            studentTwo.Name = "Dirk";
            studentTwo.LastName = "Strauss";
            studentTwo.CourseCodes = new List<int> { 500 };
            program.OutputInformation(studentTwo);
            Professor prof = new Professor();
            prof.Name = "Reinhardt";
            prof.LastName = "Botha";
            prof.TeachesSubjects = new List<string> { "Mobile Development", "Cryptography" };
            program.OutputInformation(prof);
            Console.ReadLine();
        }

    }
}
