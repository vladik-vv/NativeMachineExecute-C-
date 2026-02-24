using static Parser;
struct Errors{
    static readonly Dictionary<byte, string> err = new Dictionary<byte, string>{
        {0x00, $"\nLine <{Executer.line}> Error 0x00: Instruction not found"},
        {0x01, $"\nLine <{Executer.line}> Error 0x01: Address is not exist"},
        {0x02, $"\nLine <{Executer.line}> Error 0x02: Incorrect number of arguments"},
        {0x03, $"\nLine <{Executer.line}> Error 0x03: Incorrect block name"},
        {0x04, $"\nLine <{Executer.line}> Error 0x04: Incorrect arguments"},
        {0x05, $"\nLine <{Executer.line}> Error 0x05: Redefinition of symbol"},
        {0x06, $"\nLine <{Executer.line}> Errors 0x06 Segmentation fault"},
        {0x07, $"\nLine <{Executer.line}> Error 0x07: Typing error"},
        {0x08, $"\nLine <{Executer.line}> Error 0x08: Incorrect name address!"}
    };

    public static void Print(byte code){
        Console.Write($"{err[code]}\n");
        isWarn = true;
    }
}