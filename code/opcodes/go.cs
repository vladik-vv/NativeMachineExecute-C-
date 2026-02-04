using static PC.Computer;
using static Interpreter;
#pragma warning disable CS8981
public class go{
    public static bool temp = false;
    public static void run(){
        temp = false;
        try {
            num = blocks[parts[1] + ":"];
        } catch {
            temp = true;
            Console.Write($"\nLine {num + 1} Error: Incorrect block name");
            return;
        }
    }
}