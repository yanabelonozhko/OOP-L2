using System;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace lab2
{
    public class Program
    {
        static void Main()
        {
            int MyTemp2;
            int MyTemp;
            List<Person> people = new List<Person>();
            BinaryFormatter formatter = new BinaryFormatter();

            int GetComand()
            {
                Console.WriteLine("");
                Console.WriteLine("-----HELP--------");
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1. Загрузить список из файла");
                Console.WriteLine("2. Сохранить текущий список в файл");
                Console.WriteLine("3. Вывести список на экран");
                Console.WriteLine("4. Добавить новый объект");
                Console.WriteLine("5. Удалить существующий объект");
                Console.WriteLine("6. Выход");
                Console.Write("Операция: ");
                return (Convert.ToInt32(Console.ReadLine()));

            }
            void LoadFromFileB()
            {

                Console.WriteLine("");
                Console.WriteLine("-----load From File--------");
                using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
                {
                    people = (List<Person>)formatter.Deserialize(fs);
                }
                Console.WriteLine("Объекты десериализованы успешно");
            }
            void LoadFromFileJ()
            {
                Console.WriteLine("");
                Console.WriteLine("-----load From File--------");

                using (StreamReader sr = new StreamReader("people2.json"))
                {
                    while (!sr.EndOfStream)
                    {
                        people = (JsonConvert.DeserializeObject<List<Person>>(sr.ReadLine()));
                    }
                }

                Console.WriteLine("Объекты десериализованы успешно");
            }

            void SavetoFileJ()
            {
                Console.WriteLine("");
                Console.WriteLine("-----Save To File--------");
                using (StreamWriter sw = new StreamWriter("people2.json", true))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(people));
                }
                Console.WriteLine("Объект сериализованы");
            }

            void SaveToFileB()
            {
                Console.WriteLine("");
                Console.WriteLine("-----Save To File--------");
                // получаем поток, куда будем записывать сериализованный объект
                using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, people);
                }
                Console.WriteLine("Объект сериализованы");
            }

            void PrintList()
            {
                int temp = 1;
                Console.WriteLine("");
                Console.WriteLine("-----Print List--------");
                foreach (var e in people)
                {
                    Console.Write(temp + ". ");
                    e.PrintInfo();
                    temp++;
                }
            }

            void InputInAdd()
            {
                Console.Write("Введите имя: ");
                string name = Console.ReadLine();
                Console.Write("Введите возраст: ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите пол: ");
                string gender = Console.ReadLine();
                people.Add(new Person(name, age, gender));
            }

            void AddNewObject()
            {
                Console.WriteLine("");
                Console.WriteLine("-----Add new object--------");
                Console.WriteLine("Выберите класс, объект которого хотите создать");
                Console.WriteLine("1.Person");
                Console.WriteLine("2.Student");
                Console.WriteLine("3.UniStudent");
                Console.WriteLine("4.ScStudent");
                Console.WriteLine("5.Employee");
                int temp = Convert.ToInt32(Console.ReadLine());

                switch (temp)
                {
                    case 1:
                        {
                            Console.Write("Введите имя: ");
                            string name = Console.ReadLine();
                            Console.Write("Введите возраст: ");
                            int age = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите пол: ");
                            string gender = Console.ReadLine();
                            people.Add(new Person(name, age, gender));
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Введите имя: ");
                            string name = Console.ReadLine();
                            Console.Write("Введите возраст: ");
                            int age = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите пол: ");
                            string gender = Console.ReadLine();
                            Console.Write("Введите учебное заведение: ");
                            string playce = Console.ReadLine();
                            people.Add(new Student(name, age, gender, playce));
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Введите имя: ");
                            string name = Console.ReadLine();
                            Console.Write("Введите возраст: ");
                            int age = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите пол: ");
                            string gender = Console.ReadLine();
                            Console.Write("Введите учебное заведение: ");
                            string playce = Console.ReadLine();
                            Console.Write("Введите название учебного заведения: ");
                            string UniName = Console.ReadLine();
                            people.Add(new UniStudent(name, age, gender, playce, UniName));
                            break;
                        }
                    case 4:
                        {
                            Console.Write("Введите имя: ");
                            string name = Console.ReadLine();
                            Console.Write("Введите возраст: ");
                            int age = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите пол: ");
                            string gender = Console.ReadLine();
                            Console.Write("Введите учебное заведение: ");
                            string playce = Console.ReadLine();
                            Console.Write("Введите название учебного заведения: ");
                            string SchoolName = Console.ReadLine();
                            people.Add(new ScStudent(name, age, gender, playce, SchoolName));
                            break;
                        }
                    case 5:
                        {
                            Console.Write("Введите имя: ");
                            string name = Console.ReadLine();
                            Console.Write("Введите возраст: ");
                            int age = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите пол: ");
                            string gender = Console.ReadLine();
                            Console.Write("Введите стаж работы: ");
                            int WorkExperience = Convert.ToInt32(Console.ReadLine());
                            people.Add(new Employee(name, age, gender, WorkExperience));
                            break;
                        }
                }
            }

            void DeleteObject()
            {
                int temp = 1;
                Console.WriteLine("");
                Console.WriteLine("-----Deleting object--------");
                foreach (var e in people)
                {
                    Console.Write(temp + ". ");
                    e.PrintInfo();
                    temp++;
                }

                Console.WriteLine("Выберите объект, который хотите удалить: ");
                temp = Convert.ToInt32(Console.ReadLine());
                people.RemoveAt(temp - 1);
            }

            MyTemp = 7;
            while (MyTemp != 6)
            {
                MyTemp = GetComand();
                switch (MyTemp)
                {
                    case 1:
                        {
                            Console.WriteLine("Выберите сериализацию:");
                            Console.WriteLine("1. Binary");
                            Console.WriteLine("2. Json");
                            MyTemp2 = Convert.ToInt32(Console.ReadLine());

                            if (MyTemp2 == 1)
                            {
                                LoadFromFileB();
                            }

                            if (MyTemp2 == 2)
                            {
                                LoadFromFileJ();
                            }
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("Выберите десериализацию:");
                            Console.WriteLine("1. Binary");
                            Console.WriteLine("2. Json");
                            MyTemp2 = Convert.ToInt32(Console.ReadLine());

                            if (MyTemp2 == 1)
                            {
                                SaveToFileB();
                            }

                            if (MyTemp2 == 2)
                            {
                                SavetoFileJ();
                            }
                            break;
                        }

                    case 3:
                        PrintList();
                        break;

                    case 4:
                        AddNewObject();
                        break;

                    case 5:
                        DeleteObject();
                        break;

                }
            }
        }
    }
}


