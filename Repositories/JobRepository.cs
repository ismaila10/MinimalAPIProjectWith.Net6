using MinimalAPIProjectWith.Net6.Models;

namespace MinimalAPIProjectWith.Net6.Repositories
{
    public class JobRepository
    {
        public static List<Job> Jobs = new()
        {
            new()
            {
                Id = 1,
                Title = "Développeur",
                Description = "Programming application with pc ",
                Salary = 3000,
            },
            new()
            {
                Id = 2,
                Title = "Designer",
                Description = "Design application interface with pc ",
                Salary = 2500,
            },
            new()
            {
                Id = 3,
                Title = "Product Owner",
                Description = "Responsable of product  ",
                Salary = 2300,
            },
            new()
            {
                Id = 4,
                Title = "Business Analyst",
                Description = " Analyse the product value ",
                Salary = 2800,
            },
            new()
            {
                Id = 5,
                Title = "Database Administrator",
                Description = " Modeling data conception",
                Salary = 3200,
            },
        };
    }
}
