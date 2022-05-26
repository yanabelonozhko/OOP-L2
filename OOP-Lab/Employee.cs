class Employee : Person
{
    public int WorkExperience;
    public Employee(string name, int age, string gender, int WorkExperience) 
        : base(name, age, gender)
    {
        this.WorkExperience = WorkExperience;
    }
}

