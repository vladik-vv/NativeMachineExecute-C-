using static PC.Computer;
using static Interpreter;
#pragma warning disable CS8981
public class dd{
    public static bool temp = false;
    public static void run(){
        temp = false;
        Thread.Sleep(20); // задержка из за долгой оперативной памяти
                    
        RAM += 4;
        if (RAM >= maxRAM)
            KillProcessRAM();

        if (varsNames.Contains(parts[1])){
            temp = true;
            Console.WriteLine($"\nLine {num + 1} Error: Redefinition of symbol");
            return;
        }

        try {
            varsFloat.Add(parts[1], float.Parse(parts[2]));
        } catch {
            Console.WriteLine($"\nLine {num + 1} Error: Segmentation fault");
            temp = true;
            return;
        }

        varsNames.Add(parts[1]);
        num++;
    }
}