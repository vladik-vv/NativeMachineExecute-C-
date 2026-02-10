static class Computer
{
    private static ConsoleKeyInfo? keyInfo = null;
    private static CancellationTokenSource cts = new ();
    public const int maxRAM = 262144; // Максимальное количество ОЗУ в пк
    public static int RAM = 0; // Состояние оперативки
    public static Dictionary<string, double> registres = new Dictionary<string, double>{
        {"r1", 0},    
        {"r2", 0},  
        {"r3", 0},  
        {"r4", 0},  
        {"r5", 0},  
        {"rnd", 0}, // регистр rnd - первичная задача, хранить в себе число заданное рандомом 
        {"rnr", 0}, // регистр rnr - первичная задача, сохранять остаток после деления.
        {"rvc", 0}  // регистр rvc - первичная задача, сохранять дистанцию, высчитанную в программе между двумя векторами.
    };

    public static async void Start(){
        RAM = 65536; // При запуске пк, ОЗУ забит 64 мегабайтами. ( Операционка + системы слежки )

        cts = new CancellationTokenSource();
        Task keyWatch = Task.Run(() => CheckKey(cts.Token));

    } 

    public static void SystemMonitor(){
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine($"| RAM : {RAM} / {maxRAM} | {Math.Round((double)RAM / maxRAM * 100)}%");
        Console.WriteLine($"| CPU (1) 0.01 / 0.20 GHz");
        Console.WriteLine($"|");
        Console.WriteLine($"| Usage Registres CPU");
        Console.WriteLine($"| r1: {registres["r1"]} / {double.MaxValue}");
        Console.WriteLine($"| r2: {registres["r2"]} / {double.MaxValue}");
        Console.WriteLine($"| r3: {registres["r3"]} / {double.MaxValue}");
        Console.WriteLine($"| r4: {registres["r4"]} / {double.MaxValue}");
        Console.WriteLine($"| r5: {registres["r5"]} / {double.MaxValue}");
        Console.WriteLine($"| rnd: {registres["rnd"]} / {double.MaxValue}");
        Console.WriteLine($"| rnr: {registres["rnr"]} / {double.MaxValue}");
        Console.WriteLine($"| rvc: {registres["rvc"]} / {double.MaxValue}");
        Console.WriteLine("------------------------------------------------------------");
    }

    public static void KillProcessRAM(){
        Console.WriteLine("\nError: RAM IS FULL\n");
        Environment.Exit(0);
    }

    private static async Task CheckKey(CancellationToken cancellationToken){
        while (!cancellationToken.IsCancellationRequested){
            if (Console.KeyAvailable){
                keyInfo = Console.ReadKey(true);
            }
            await Task.Delay(10, cancellationToken);
        }
    }

    public static void ClearRegistres(){
        foreach (string key in registres.Keys){
            registres[key] = 0;
        }
    }

}    