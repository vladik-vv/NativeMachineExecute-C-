using static PC.Computer;
using static Interpreter;
#pragma warning disable CS8981
public class dw{
    public static bool temp = false;
    public static void run(){
        temp = false;
        Thread.Sleep(10); // задержка из за долгой оперативной памяти
                    
        RAM += 2;
        if (RAM >= maxRAM)
            KillProcessRAM();

        if (varsNames.Contains(parts[1])){
            temp = true;
            Console.WriteLine($"\nLine {num + 1} Error: Redefinition of symbol");
            return;
        }

        try {
            varsShort.Add(parts[1], Convert.ToInt16(parts[2]));
        } catch {
            Console.WriteLine($"\nLine {num + 1} Error: Segmentation fault");
            temp = true;
            return;
        }

        varsNames.Add(parts[1]);
        num++;
    }
}