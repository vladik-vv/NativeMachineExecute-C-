using static PC.Computer;
using static Interpreter;
#pragma warning disable CS8981
public class ret{
    public static bool temp = false; // инструкция обозначающая, если true то инструкция завершилась с ошибкой.
    public static void run(){
        if (stackAddress == -1){
            num++;
            return;
        }
        num = stackAddress;
        stackAddress = -1;
    }
}