[Serializable]

class ScStudent : Student
{
    public string SchoolName;
    public ScStudent(string name, int age, string gender, string playce,string SchoolName)
        : base(name, age, gender, playce)

    {
        this.SchoolName = SchoolName;

    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Name: {name}  Age: {age} Gender: {gender} StPlace: {playce} {SchoolName}");
    }
}