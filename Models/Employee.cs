namespace WebApp.Models
{
    public class Employee
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double Salary { get; set; }

        public Employee(string firstName, string lastName, string email, string password, double salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Salary = salary;
        }


     

        public override string? ToString()
        {
            return $"FirstName : {FirstName}, LastName: {LastName}, Email: {Email}, Salary: {Salary}";
        }
    }
}
