using System.Runtime.InteropServices;


/// <summary>
/// Структура инициализации
/// </summary>
struct Init
{
    public static ConsoleKeyInfo keyInfo;
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

    public static Dictionary<string, double> stackRegistres = new Dictionary<string, double>{
        {"r1", 0}, {"r2", 0}, {"r3", 0}, {"r4", 0}, {"r5", 0}, {"rnd", 0}, {"rnr", 0}, {"rvc", 0},
    };

    public static async void StartInit(){
        RAM = 65536; // При запуске пк, ОЗУ забит 64 мегабайтами. ( Операционка + системы слежки )

        Task keyWatch = Task.Run(() => CheckKey());
    } 

    public static void SystemMonitor(){
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine($"| RAM : {RAM} / {maxRAM} | {Math.Round((double)RAM / maxRAM * 100)}%");
        Console.WriteLine($"| CPU (1) 0.01 / 0.20 GHz");
        Console.WriteLine($"|");
        Console.WriteLine($"| Usage Registres CPU");
        Console.WriteLine($"| r1: {registres["r1"]} / {long.MaxValue}");
        Console.WriteLine($"| r2: {registres["r2"]} / {long.MaxValue}");
        Console.WriteLine($"| r3: {registres["r3"]} / {long.MaxValue}");
        Console.WriteLine($"| r4: {registres["r4"]} / {long.MaxValue}");
        Console.WriteLine($"| r5: {registres["r5"]} / {long.MaxValue}");
        Console.WriteLine($"| rnd: {registres["rnd"]} / {long.MaxValue}");
        Console.WriteLine($"| rnr: {registres["rnr"]} / {long.MaxValue}");
        Console.WriteLine($"| rvc: {registres["rvc"]} / {long.MaxValue}");
        Console.WriteLine("------------------------------------------------------------");
    }

    // запускаем проверку нажатой клавиши в реальном времени в отдельном потоке
    // и записываем изменения в keyInfo
    private static async Task CheckKey(){ 
        while (true){
            if (Console.KeyAvailable){
                keyInfo = Console.ReadKey(true);
            }
        }
    }

    public static void ClearRegistres(){    // функция очищающая регистры
        foreach (string key in registres.Keys){
            registres[key] = 0;
        }
    }

    public static void ClearKey(){
        keyInfo = new ConsoleKeyInfo(); 
    }

}    