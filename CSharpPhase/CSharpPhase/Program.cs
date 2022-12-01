using System.Text.Json;

namespace CSharpPhase
{
    class Program
    {
        public static void Main(string[] args)
        {
            var studentInfo =
                File.ReadAllText(@"../../../../students.json");
            var students = JsonSerializer.Deserialize<List<Student>>(studentInfo);
            
            var scoresInfo =
                File.ReadAllText(@"../../../../scores.json");
            var scores = JsonSerializer.Deserialize<List<Course>>(scoresInfo);


            var info = students!.GroupJoin(scores!, student => student.StudentNumber, course => course.StudentNumber,
                        (student, courseCollection) => new
                        {
                            student.FirstName, student.LastName,
                            AverageScore = courseCollection.Average(course => course.Score)
                        })
                    .OrderByDescending(student => student.AverageScore)
                    .Take(3)
                ;

            foreach (var element in info)
            {
                Console.WriteLine(element.ToString());
            }
        }
    }

    class Student
    {
        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Course
    {
        public int StudentNumber { get; set; }
        public string Lesson { get; set; }
        public double Score { get; set; }
    }
}