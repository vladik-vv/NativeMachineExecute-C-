using static PC.Computer;
using static Interpreter;
#pragma warning disable CS8981
public class call{
    public static bool temp = false;
    public static void run(){
        temp = false;
        try {
            stackAddress = num + 1;
            num = blocks[parts[1] + ":"];
        } catch {
            Console.Write($"\nLine {num + 1} Error - Incorrect address");
            temp = true;
            return;
        }
    }
}