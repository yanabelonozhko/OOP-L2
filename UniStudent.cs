class UniStudent : Student
{
    public string UniName;
    public UniStudent(string name, int age, string gender, string playce, string UniName)
        : base(name, age, gender, playce)
    {
        this.UniName = UniName;
    }   
}
