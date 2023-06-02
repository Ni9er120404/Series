namespace MoviesAndSeries.Server.Models.DataBaseModels
{
    public class Person
    {
        public Person()
        {
        }

        public Person(string lastName, string firstName, int age)
        {
            LastName = lastName;
            FirstName = firstName;
            Age = age;
        }

        public int? Id { get; set; }

        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public int Age { get; set; }
    }
}
