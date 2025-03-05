// 1. Створіть клас Virus. Він повинен містити вагу, вік, ім’я, вид і
// масив дітей, екземплярів Virus.
// 2. Створіть екземпляри для цілого “сімейства” вірусів (мінімум
// три покоління).
// 3. За допомогою шаблону Прототип реалізуйте можливість
//     клонування наявних вірусів.
// 4. При клонуванні віруса-батька повинні клонуватися всі його
// діти.

class Virus : ICloneable
{
    public string Name { get; set; }
    public string Species { get; set; }
    public double Weight { get; set; }
    public int Age { get; set; }
    public List<Virus> Children { get; set; }

    public Virus(string name, string species, double weight, int age)
    {
        Name = name;
        Species = species;
        Weight = weight;
        Age = age;
        Children = new List<Virus>();
    }

    public void AddChild(Virus child)
    {
        Children.Add(child);
    }

  
    public object Clone()
    {
        Virus clone = new Virus(this.Name, this.Species, this.Weight, this.Age);
        foreach (var child in this.Children)
        {
            clone.AddChild((Virus)child.Clone()); 
        }
        return clone;
    }

    public void PrintFamily(int level = 0)
    {
        Console.WriteLine($"{new string('-', level * 2)}> {Name} ({Species}), Age: {Age}, Weight: {Weight}g");
        foreach (var child in Children)
        {
            child.PrintFamily(level + 1);
        }
    }
}


class Program
{
    static void Main()
    {
       
        Virus ancestor = new Virus("Robert Bob Mister Bob", "Flu", 2.5, 10);
        Virus child1 = new Virus("Robert Bob", "Flu", 1.8, 5);
        Virus child2 = new Virus("Bobbie Bob", "Flu", 1.6, 4);
        Virus grandchild1 = new Virus("Bob", "Flu", 1.2, 2);
        Virus grandchild2 = new Virus("BJ", "Flu", 1.1, 1);

        
        child1.AddChild(grandchild1);
        child2.AddChild(grandchild2);
        ancestor.AddChild(child1);
        ancestor.AddChild(child2);

        Console.WriteLine("Original Virus Family:");
        ancestor.PrintFamily();

       
        Virus clonedAncestor = (Virus)ancestor.Clone();

        Console.WriteLine("\nCloned Virus Family:");
        clonedAncestor.PrintFamily();

      
        Console.WriteLine($"\nancestor and clone different objects: {ancestor != clonedAncestor}");
        Console.WriteLine($"first children different objects: {ancestor.Children[0] != clonedAncestor.Children[0]}");
    }
}
