// 1. Створіть фабрику виробництва техніки.
// 2. На фабриці мають створюватися різні девайси (наприклад,
//     Laptop, Netbook, EBook, Smartphone) для різних брендів (IProne,
//     Kiaomi, Balaxy).





interface IDevice
{
    void GetInfo();
}


class Laptop : IDevice
{
    private string brand;
    public Laptop(string brand) => this.brand = brand;
    public void GetInfo() => Console.WriteLine($"Laptop of brand {brand}");
}

class Netbook : IDevice
{
    private string brand;
    public Netbook(string brand) => this.brand = brand;
    public void GetInfo() => Console.WriteLine($"Netbook of brand {brand}");
}

class EBook : IDevice
{
    private string brand;
    public EBook(string brand) => this.brand = brand;
    public void GetInfo() => Console.WriteLine($"EBook of brand {brand}");
}

class Smartphone : IDevice
{
    private string brand;
    public Smartphone(string brand) => this.brand = brand;
    public void GetInfo() => Console.WriteLine($"Smartphone of brand {brand}");
}


interface ITechFactory
{
    IDevice CreateLaptop();
    IDevice CreateNetbook();
    IDevice CreateEBook();
    IDevice CreateSmartphone();
}


class IProneFactory : ITechFactory
{
    public IDevice CreateLaptop() => new Laptop("IProne");
    public IDevice CreateNetbook() => new Netbook("IProne");
    public IDevice CreateEBook() => new EBook("IProne");
    public IDevice CreateSmartphone() => new Smartphone("IProne");
}

class KiaomiFactory : ITechFactory
{
    public IDevice CreateLaptop() => new Laptop("Kiaomi");
    public IDevice CreateNetbook() => new Netbook("Kiaomi");
    public IDevice CreateEBook() => new EBook("Kiaomi");
    public IDevice CreateSmartphone() => new Smartphone("Kiaomi");
}

class BalaxyFactory : ITechFactory
{
    public IDevice CreateLaptop() => new Laptop("Balaxy");
    public IDevice CreateNetbook() => new Netbook("Balaxy");
    public IDevice CreateEBook() => new EBook("Balaxy");
    public IDevice CreateSmartphone() => new Smartphone("Balaxy");
}


class Program
{
    static void Main()
    {
        ITechFactory iproneFactory = new IProneFactory();
        ITechFactory kiaomiFactory = new KiaomiFactory();
        ITechFactory balaxyFactory = new BalaxyFactory();

        Console.WriteLine("IProne Products:");
        iproneFactory.CreateLaptop().GetInfo();
        iproneFactory.CreateSmartphone().GetInfo();
        iproneFactory.CreateEBook().GetInfo();

        Console.WriteLine("\nKiaomi Products:");
        kiaomiFactory.CreateNetbook().GetInfo();
        kiaomiFactory.CreateEBook().GetInfo();

        Console.WriteLine("\nBalaxy Products:");
        balaxyFactory.CreateLaptop().GetInfo();
        balaxyFactory.CreateSmartphone().GetInfo();
    }
}
