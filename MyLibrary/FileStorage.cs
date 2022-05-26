namespace MyLibrary;

public abstract class FileStorage<T>
{
    public abstract List<T> LoadFromFile();
    
    public abstract void SaveToFile(List<T> data);
}
