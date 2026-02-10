using System.Runtime.CompilerServices;
public static class Terminal
{   
    static string currentMode = "menu";
    public static string path = "";
    static bool isRun = true;
    static string[] input = new string[3];
    const string helloCode =
    "__start:\n    go main\n\n.p main:\n    out, \"welcome to hell\"\n\n__stop:\n    clear registres";

    const string calcCode = 
    "start:\n   ds operator, \"\"     ;   создаём строковую переменную \"operator\"\n   go calc             ;   переходим к блоку calc\n\n.block calc:\n    out, \"введите оператор (+, -, *, /, q - exit): \"\n    inp, operator\n\n    cmp operator, \"q\"   ;   сравниваем значение оператора с \"q\"\n    ife, go halt        ;   если они равны, переходим к блоку halt\n\n    out, \"введите первое число: \"\n    inp, r1\n\n    out, \"введите второе число: \"\n    inp, r2\n\n    cmp operator, \"+\"\n    ife, go plus\n\n    cmp operator, \"-\"\n    ife, go minus\n\n    cmp operator, \"*\"\n    ife, go multiply\n\n    cmp operator, \"/\"\n    ife, go divide\n\n    ifn, go calc\n\nend\n\n.block halt:\nend\n\n.block plus:\n    add r1, r2\n    go output\n\n.block minus:\n    sub r1, r2\n    go output\n\n.block multiply:\n    mul r1, r2\n    go output\n\n.block divide:\n    div r1, r2\n    go output\n\n.block output:\n    out, r1\n    next\n    go calc\n\nstop:\n    clear registres\n    clear operator      ;   убираем operator из памяти\nend";

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

    static void OutputMenu(){
        Console.WriteLine("\nSystem Control num: 130022\n");

        for (;;){
            Console.Write("user: ");
            string inp = Console.ReadLine() ?? "";

            switch (inp){
                case "help":
                case "?":
                case "commands":{
                    Console.WriteLine("\n Commands:\n     start nem\n     system monitor\n     shutdown\n     clear\n");
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

    static void OutputNEM(){
        Console.Write("\nNative Execute Machine\n\n");

        for (;;){
            Console.Write("nem: ");
            #pragma warning disable CS8602
            input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            try { input[0] = input[0]; } catch {continue;}

            switch (input[0]){ // input[0] - run | input[1] - file_name | input[2] - command
                case "?":
                case "commands":
                case "help":{
                    Console.WriteLine("\n Commands:\n     new filename.n\n     delete filename.n\n     list\n     analyze filename.n\n     run filename.n\n     clear\n     exit\n");
                    break;
                }
                case "exit":{
                    currentMode = "menu";
                    return;
                }
                case "new":{
                    if (!CheckInput("new"))
                        break;

                    if (input.Count() < 3){
                        File.WriteAllText(input[1], helloCode);
                        break;
                    }

                    switch (input[2]){
                        case "-e":{
                            File.WriteAllText(input[1], "");
                            break;
                        }
                        case "-c":{
                            File.WriteAllText(input[1], calcCode);
                            break;
                        }
                        default:{
                            File.WriteAllText(input[1], helloCode);
                            break;
                        }

                    }
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
                case "run":{
                    if (!CheckInput("run"))
                        break;

                    Interpreter.Run("run");
                    break;
                }
                case "dis":{
                    if (!CheckInput("dis"))
                        break;

                    Interpreter.Run("dis");
                    break;
                }
                case "clear":{
                    Console.Clear();
                    Console.WriteLine();    
                    break;
                }
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