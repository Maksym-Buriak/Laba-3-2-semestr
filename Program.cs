using System;
using System.IO;
using Newtonsoft.Json;

class MyClass
{
    public string Thing;
    public int Quantity;

    public MyClass(string thing, int quantity) // Конструктор з вхідними параметрами
    {
        Thing = thing;
        Quantity = quantity;
    }

    public MyClass() // Конструктор, який ініціалізує члени класу за замовчуванням
    {
        Thing = "No";
        Quantity = 0;
    }

    ~MyClass() // Деструктор
    {
        Console.WriteLine("Об'єкт видалено");
    }

    public void Print()
    {
        Console.WriteLine($"Продукція: {Thing}, Кількість: {Quantity}");
    }

    public void SaveToJson(string filePath) // збереження в JSON
    {
        string json = JsonConvert.SerializeObject(this);
        File.WriteAllText(filePath, json);
    }

    public static MyClass LoadFromJson(string filePath) // зчитування з JSON
    {
        string json = File.ReadAllText(filePath);
        MyClass obj = JsonConvert.DeserializeObject<MyClass>(json);
        return obj;
    }
}

class Program
{
    static void Main(string[] args)
    {

        MyClass factory1 = new MyClass("Phone", 16);
        factory1.Print();
        string savePath = @"E:\programming\project\Лабораторна робота 3 (2 семестр)\json files\factory1.json";
        factory1.SaveToJson(savePath);

        MyClass factory2 = new MyClass("Headphone", 22);
        factory2.Print();
        string savePath2 = @"E:\programming\project\Лабораторна робота 3 (2 семестр)\json files\factory2.json";
        factory2.SaveToJson(savePath2);

        MyClass factory3 = new MyClass("Phone cover", 40);
        factory3.Print();
        string savePath3 = @"E:\programming\project\Лабораторна робота 3 (2 семестр)\json files\factory3.json";
        factory3.SaveToJson(savePath3);

        //MyClass factory4 = new MyClass("Phone", 16);
        //factory4.Print();
        //string savePath4 = @"E:\programming\project\Лабораторна робота 3 (2 семестр)\json files\factory4.json";
        //factory4.SaveToJson(savePath4);

        Console.WriteLine("--------------------------------------------------------------------------------------------------");

        string loadPath = @"E:\programming\project\Лабораторна робота 3 (2 семестр)\json files\factory1.json";
        MyClass factory11 = MyClass.LoadFromJson(loadPath);
        factory11.Print();

        string loadPath2 = @"E:\programming\project\Лабораторна робота 3 (2 семестр)\json files\factory2.json";
        MyClass factory22 = MyClass.LoadFromJson(loadPath2);
        factory22.Print();

        string loadPath3 = @"E:\programming\project\Лабораторна робота 3 (2 семестр)\json files\factory3.json";
        MyClass factory33 = MyClass.LoadFromJson(loadPath3);
        factory33.Print();

        //string loadPath4 = @"E:\programming\project\Лабораторна робота 3 (2 семестр)\json files\factory4.json";
        //MyClass factory44 = MyClass.LoadFromJson(loadPath3);
        //factory44.Print();


        factory1 = null;
        GC.Collect();

        Console.ReadKey();
    }
}