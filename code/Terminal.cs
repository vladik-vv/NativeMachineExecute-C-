using System.Runtime.CompilerServices;
using PC;
public class Terminal
{   
    static string currentMode = "menu";
    public static string path = "";
    static bool isRun = true;
    static string[] input = new string[3];
    static string defaultCode =
    "start:\n    go main\nend\n\n.block main:\n    out \"welcome to hell\"\nend\n\nstop:\n    clear registres\nend";

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void Start(){
        Console.Clear();

        while (isRun){
            switch (currentMode){
                case "menu":{
                    Console.Clear();
                    OutputMenu();
                    break;
                }
                case "nem":{
                    Console.Clear();
                    OutputNEM();
                    break;
                }
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    static void OutputMenu(){
        Console.WriteLine("System Control num: 130022\n");

        for (;;){
            Console.Write("user: ");
            string inp = Console.ReadLine() ?? "";

            switch (inp){
                case "help":
                case "?":
                case "commands":{
                    Console.WriteLine("\nCommands:\n    start nem\n    system monitor\n    shutdown\n    clear\n");
                    break;
                }
                case "start nem":{
                    currentMode = "nem";
                    return;
                }
                case "system monitor":{
                    Computer.SystemMonitor();
                    break;
                }
                case "shutdown":{
                    isRun = false;
                    return;
                }
                case "clear":{
                    Console.Clear();
                    break;
                }
            }
        }
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    static void OutputNEM(){
        Console.Write("Native Execute Machine\n\n");

        for (;;){
            Console.Write("nem: ");
            #pragma warning disable CS8602
            input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            try {
                switch (input[0]){ // input[0] - run | input[1] - file_name | input[2] - command
                    case "?":
                    case "commands":
                    case "help":{
                        Console.WriteLine("\nCommands:\n    new filename.n\n    delete filename.n\n    list\n    analyze filename.n\n    run filename.n\n    clear\n    exit\n");
                        break;
                    }
                    case "exit":{
                        currentMode = "menu";
                        return;
                    }
                    case "new":{
                        if (!CheckInput("new"))
                            break;

                        File.WriteAllText(input[1], defaultCode);
                        break;
                    }
                    case "delete":{
                        if (!CheckInput("delete"))
                            break;

                        File.Delete(input[1]);
                        break;
                    }
                    case "list":{
                        Console.WriteLine("----------------------");
                        foreach(string file in Directory.GetFiles(".")){
                            Console.WriteLine(file);
                        }
                        Console.WriteLine("----------------------");
                        break;
                    }
                    case "analyze":{
                        if (!CheckInput("analyze"))
                            break;

                        Analyze.Run();
                        break;
                    }
                    case "run":{
                        if (!CheckInput("run"))
                            break;

                        Interpreter.Run();
                        break;
                    }
                    case "clear":{
                        Console.Clear();
                        break;
                    }
                }    
            } catch {
                Console.WriteLine();
                Console.WriteLine("Error: Not valid input");
            }
        }
        
    }

    static bool CheckInput(string code){
        try{
            path = input[1];
        } catch{
            Console.WriteLine($"Error: Where a name file? Example - {code} file.nem");
            return false;
        }

        
        if (code != "new"){
            try {
                string temp = File.ReadAllText(path);
                temp = "";
            } catch{
                Console.WriteLine($"Error: File {path} is not exist!");
                return false;
            }
        }

        return true;
    }
}