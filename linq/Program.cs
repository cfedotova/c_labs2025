using linq;

class Program
{
    static void Main()
    {
        var students = new List<Student>
        {
            new Student { Name = "Tom", Group = "A", Grades = new List<int> { 90, 85, 92 } },
            new Student { Name = "Eve", Group = "A", Grades = new List<int> { 70, 75, 80 } },
            new Student { Name = "Bob", Group = "B", Grades = new List<int> { 88, 90, 91 } },
            new Student { Name = "John", Group = "B", Grades = new List<int> { 40, 50, 60 } },
            new Student { Name = "Steav", Group = "C", Grades = new List<int> { 95, 97, 99 } }
        };

        var allAbove80 = students.Where(s => s.Grades.All(g => g > 80));
        Console.WriteLine("a. Students with all grades > 80:");
        foreach (var s in allAbove80)
            Console.WriteLine(s.Name);

        var avg85 = students.Where(s => s.Grades.Average() >= 85);
        Console.WriteLine("\nb. Average >= 85:");
        foreach (var s in avg85)
            Console.WriteLine($"{s.Name} ({s.Grades.Average():F2})");

        var topGroup = students
            .GroupBy(s => s.Group)
            .OrderByDescending(g => g.Average(s => s.Grades.Average()))
            .First().Key;
        Console.WriteLine($"\nc. Group with highest average: {topGroup}");

        Console.WriteLine("\nd. Number of students in each group:");
        var groupCounts = students.GroupBy(s => s.Group);
        foreach (var group in groupCounts)
            Console.WriteLine($"{group.Key}: {group.Count()} students");

        var topStudent = students.OrderByDescending(s => s.Grades.Average()).First();
        Console.WriteLine($"\ne. Top student: {topStudent.Name}");

        bool hasLow = students.Any(s => s.Grades.Any(g => g < 50));
        Console.WriteLine($"\nf. Any grade < 50: {hasLow}");

        Console.WriteLine("\ng. Average grade per group:");
        foreach (var group in groupCounts)
        {
            var avg = group.Average(s => s.Grades.Average());
            Console.WriteLine($"{group.Key}: {avg:F2}");
        }

        Console.WriteLine("\nh. Top 3 students (StudentReport):");
        var top3 = students
            .Select(s => new StudentReport
            {
                Name = s.Name,
                AverageGrade = s.Grades.Average(),
                Status = s.Grades.Average() >= 90 ? "Excellent" :
                    s.Grades.Average() >= 75 ? "Good" : "Needs improvement"
            })
            .OrderByDescending(r => r.AverageGrade)
            .Take(3);

        foreach (var report in top3)
            Console.WriteLine($"{report.Name}: {report.AverageGrade:F2} - {report.Status}");
    }
}