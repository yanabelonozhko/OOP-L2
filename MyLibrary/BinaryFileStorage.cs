using System.Runtime.Serialization.Formatters.Binary;

namespace MyLibrary;

public class BinaryFileStorage<T> : FileStorage<T>
{
    private BinaryFormatter formatter = new BinaryFormatter();

    public override List<T> LoadFromFile()
    {
        List<T> data = new List<T>();
        using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
        {
            data = (List<T>)formatter.Deserialize(fs);
        }

        return data;
    }

    public override void SaveToFile(List<T> data)
    {
        // получаем поток, куда будем записывать сериализованный объект
        using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
        {
            formatter.Serialize(fs, data);
        }
    }
}