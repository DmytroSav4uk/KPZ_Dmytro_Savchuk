
// 1. Створіть клас Authenticator таким чином, щоб бути
//     впевненим, що цей клас може створити лише один екземпляр,
//     незалежно від кількості потоків і класів, що його наслідують.



class Authenticator
{
    private static volatile Authenticator? _instance;
    private static readonly object _lock = new object();

    private Authenticator()
    {
        Console.WriteLine("Authenticator instance created.");
    }

    public static Authenticator Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Authenticator();
                    }
                }
            }

            return _instance;
        }
    }

    public void Authenticate(string username, string password)
    {
        Console.WriteLine($"Authenticating user: {username}");
    }
}


class Program
{
    static void Main()
    {
        Console.WriteLine("Starting authentication tests...\n");

        Thread thread1 = new Thread(() =>
        {
            var auth1 = Authenticator.Instance;
            auth1.Authenticate("user1", "password123");
        });

        Thread thread2 = new Thread(() =>
        {
            var auth2 = Authenticator.Instance;
            auth2.Authenticate("user2", "password456");
        });

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine("\nVerifying singleton behavior...");
        var auth3 = Authenticator.Instance;
        var auth4 = Authenticator.Instance;

        Console.WriteLine($"auth3 == auth4: {auth3 == auth4}");
    }
}