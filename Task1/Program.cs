// 1. Напишіть систему класів для реалізації функціоналу
//     створення різних типів підписок для відео провайдера.
// 2. Кожна з підписок повинна мати щомісячну плату, мінімальний
// період підписки та список каналів й інших можливостей.
// 3. Види підписок: DomesticSubscription,
// EducationalSubscription, PremiumSubscription.
// 4. Придбати (тобто створити) підписку можна за допомогою
// трьох різних класів: WebSite, MobileApp, ManagerCall, кожен з них
//     має реалізувати свою логіку створення підписок.

using System.Text;

abstract class Subscription
{
    public string Name { get; protected set; }
    public double MonthlyFee { get; protected set; }
    public int MinPeriod { get; protected set; } 
    public List<string> Channels { get; protected set; }
    public List<string> Features { get; protected set; }

    protected Subscription(string name, double monthlyFee, int minPeriod)
    {
        Name = name;
        MonthlyFee = monthlyFee;
        MinPeriod = minPeriod;
        Channels = new List<string>();
        Features = new List<string>();
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Subscription: {Name}\nMonthly payment: {MonthlyFee}$\nMin Period: {MinPeriod} months.");
        Console.WriteLine("Channels: " + string.Join(", ", Channels));
        Console.WriteLine("Functions: " + string.Join(", ", Features));
        Console.WriteLine();
    }
}

class DomesticSubscription : Subscription
{
    public DomesticSubscription() : base("Domestic Subscription", 10.99, 6)
    {
        Channels.AddRange(new[] { "News", "Movies", "Entertainment" });
        Features.Add("HD quality of videos");
    }
}

class EducationalSubscription : Subscription
{
    public EducationalSubscription() : base("Educational Subscription", 7.99, 3)
    {
        Channels.AddRange(new[] { "Documental", "Science", "History" });
        Features.Add("You've get an access to scientific educational resources");
    }
}

class PremiumSubscription : Subscription
{
    public PremiumSubscription() : base("Premium", 19.99, 12)
    {
        Channels.AddRange(new[] { "Sport", "Movies", "Series", "News" });
        Features.AddRange(new[] { "4K quality", "No ads." });
    }
}

interface ISubscriptionFactory
{
    Subscription CreateSubscription();
}

class WebSite : ISubscriptionFactory
{
    public Subscription CreateSubscription()
    {
        Console.WriteLine("Creating subscription through web site...");
        return new DomesticSubscription();
    }
}

class MobileApp : ISubscriptionFactory
{
    public Subscription CreateSubscription()
    {
        Console.WriteLine("Creating subscription through mobile app...");
        return new EducationalSubscription();
    }
}

class ManagerCall : ISubscriptionFactory
{
    public Subscription CreateSubscription()
    {
        Console.WriteLine("Creating subscription through manager call...");
        return new PremiumSubscription();
    }
}

class Program
{
    static void Main()
    {
        
        Console.OutputEncoding = Encoding.UTF8;
        
        ISubscriptionFactory websiteFactory = new WebSite();
        Subscription websiteSubscription = websiteFactory.CreateSubscription();
        websiteSubscription.ShowDetails();

        ISubscriptionFactory mobileAppFactory = new MobileApp();
        Subscription mobileSubscription = mobileAppFactory.CreateSubscription();
        mobileSubscription.ShowDetails();

        ISubscriptionFactory managerCallFactory = new ManagerCall();
        Subscription managerSubscription = managerCallFactory.CreateSubscription();
        managerSubscription.ShowDetails();
    }
}
