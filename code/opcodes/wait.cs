using static PC.Computer;
using static Interpreter;
#pragma warning disable CS8981
public class wait{
    public static bool temp = false;
    public static void run(){
        temp = false;
        try{
            Thread.Sleep(int.Parse(parts[1]));
        } catch{
            temp = true;
            Console.Write($"\nLine {num + 1} Error: Example - wait 100");
            return;
        }
        num++;
    }
}