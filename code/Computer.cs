namespace PC
{
    public class Computer
    {
        public const int maxRAM = 262144; // Максимальное количество ОЗУ в пк
        public static int RAM = 0; // Состояние оперативки
        public static Dictionary<string, double> registres = new Dictionary<string, double>{
            {"r1", 0}, {"r2", 0}, 
            {"r3", 0}, {"r4", 0},
            {"r5", 0}, {"r6", 0}, 
            {"r7", 0}, {"r8", 0}
        };

        public static void Start(){
            RAM = 65536; // При запуске пк, ОЗУ забит 64 мегабайтами. ( Операционка + системы слежки )
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
            Console.WriteLine($"| r6: {registres["r6"]} / {double.MaxValue}");
            Console.WriteLine($"| r7: {registres["r7"]} / {double.MaxValue}");
            Console.WriteLine($"| r8: {registres["r8"]} / {double.MaxValue}");
            Console.WriteLine("------------------------------------------------------------");
        }

        public static void KillProcessRAM(){
            Console.WriteLine("\nError: RAM IS FULL\n");
            Environment.Exit(0);
        }
    }    
}
