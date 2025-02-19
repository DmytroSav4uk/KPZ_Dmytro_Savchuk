
using System.Text;

namespace Zoo
{
    
class Animal
{
    public string Name { get; set; }
    public string Species { get; set; }
    public string Diet { get; set; }

    public Animal(string name, string species, string diet)
    {
        Name = name;
        Species = species;
        Diet = diet;
    }

    public override string ToString()
    {
        return $"Animal: {Name}, Species: {Species}, Feeding: {Diet}";
    }
}

class Enclosure
{
    public string Type { get; set; }
    public int Capacity { get; set; }
    private List<Animal> Animals { get; set; } = new List<Animal>();

    public Enclosure(string type, int capacity)
    {
        Type = type;
        Capacity = capacity;
    }

    public void AddAnimal(Animal animal)
    {
        if (Animals.Count >= Capacity)
            throw new InvalidOperationException("Enclosure is full!");
        
        Animals.Add(animal);
        Console.WriteLine($"{animal.Name} was added to enclosure {Type}.");
    }

    public override string ToString()
    {
        return $"Enclosure: {Type}, Capacity: {Capacity}, Animal count: {Animals.Count}";
    }
}

class Employee
{
    public string Name { get; set; }
    public string Role { get; set; }

    public Employee(string name, string role)
    {
        Name = name;
        Role = role;
    }

    public override string ToString()
    {
        return $"Employee: {Name}, Role: {Role}";
    }
}

class Zoo
{
    private List<object> _entities = new List<object>();

    public void AddEntity(object entity)
    {
        _entities.Add(entity);
    }

    public void InventoryReport()
    {
        Console.WriteLine("Inventory Report:");
        foreach (var entity in _entities)
        {
            Console.WriteLine(entity.ToString());
        }
    }
}

class Program
{
    static void Main()
    {
        Zoo zoo = new Zoo();

        var lion = new Animal("Lion", "Panthera leo", "carnivore");
        var giraffe = new Animal("Giraff", "Giraffa camelopardalis", "herbivore");

        var savanna = new Enclosure("Savannah", 5);
        savanna.AddAnimal(lion);
        savanna.AddAnimal(giraffe);

        var keeper = new Employee("Alex", "Animal Watcher");
        var vet = new Employee("Bobie Bob Mr. Bob", "Vet");

        zoo.AddEntity(lion);
        zoo.AddEntity(giraffe);
        zoo.AddEntity(savanna);
        zoo.AddEntity(keeper);
        zoo.AddEntity(vet);

        Console.OutputEncoding = Encoding.UTF8;
       
        
        zoo.InventoryReport();
    }
}


}

