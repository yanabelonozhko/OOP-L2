using Newtonsoft.Json;

namespace MyLibrary;

public class JsonFileStorage<T> : FileStorage<T>
{
    public override List<T> LoadFromFile()
    {
        List<T> data = new List<T>();
        using (StreamReader sr = new StreamReader("people2.json"))
        {
            while (!sr.EndOfStream)
            {
                data = (JsonConvert.DeserializeObject<List<T>>(sr.ReadLine()));
            }
        }

        return data;
    }

    public override void SaveToFile(List<T> data)
    {
        using (StreamWriter sw = new StreamWriter("people2.json", true))
        {
            sw.WriteLine(JsonConvert.SerializeObject(data));
        }
    }
}