/// <summary>
/// Класс терминал - отвечает за доступ к консоли, вводу, выводу.
/// </summary>
struct Terminal
{   
    public static string Path = ""; // Создаём патч, в котором будем хранить путь к файлу, который запускаем
    private static TerminalMods _currentMode = TerminalMods.menu; // Режим, в котором находится терминал
    private static bool _isRun = true; // Компьютер все ещё в режиме включен?
    const string HELLO_CODE = "__start:\n    go main\n\n.p main:\n    out, \"welcome to hell\"\n\n__stop:\n    clear registres";
    const string CALC_CODE  = "__start:\n   ds operator, \"\"     ;   создаём строковую переменную \"operator\"\n   go calc             ;   переходим к блоку calc\n\n.p calc:\n    out, \"введите оператор (+, -, *, /, q - exit): \"\n    inp, operator\n\n    cmp operator, \"q\"   ;   сравниваем значение оператора с \"q\"\n    ife, go halt        ;   если они равны, переходим к блоку halt\n\n    out, \"введите первое число: \"\n    inp, r1\n\n    out, \"введите второе число: \"\n    inp, r2\n\n    cmp operator, \"+\"\n    ife, go plus\n\n    cmp operator, \"-\"\n    ife, go minus\n\n    cmp operator, \"*\"\n    ife, go multiply\n\n    cmp operator, \"/\"\n    ife, go divide\n\n    ifn, go calc\n\nhlt\n\n.p halt:\n    hlt\n\n.p plus:\n    add r1, r2\n    go output\n\n.p minus:\n    sub r1, r2\n    go output\n\n.p multiply:\n    mul r1, r2\n    go output\n\n.p divide:\n    div r1, r2\n    go output\n\n.p output:\n    out, r1\n    next\n    go calc\n\n__stop:\n    clear registres\n    clear operator      ;   убираем operator из памяти\n    hlt";

    public static void StartTerminal(){
        while (_isRun){
            Console.Clear();
            switch (_currentMode)
            {
                case TerminalMods.menu:{ // Если сейчас режим "меню"
                    OutputMenu(); 
                    break;
                }

                case TerminalMods.nem:{ // Если сейчас режим "NEM"
                    OutputNEM(); 
                    break;
                }
            }
        }
    }

    private static void OutputMenu(){ // Функция, отвечающая за главное управление всем компьютером
        Console.Write("\nSystem Control num: 130022\n\n");

        for (;;){
            Console.Write("user: ");
            string inp = Console.ReadLine() ?? "";

            switch (inp){   // Проверяем, что ввёл пользователь
                case "help":
                case "?":
                case "commands":{
                    Console.Write("\n Commands:\n     start nem\n     system monitor\n     shutdown\n     clear\n\n");
                    break;
                }
                case "start nem":{
                    _currentMode = TerminalMods.nem;
                    return;
                }
                case "system monitor":{
                    Init.SystemMonitor();
                    break;
                }
                case "shutdown":{
                    _isRun = false;
                    return;
                }
                case "clear":{
                    Console.Clear();
                    Console.Write("\nSystem Control num: 130022\n\n");
                    break;
                }
            }
        }
    }


    private static void OutputNEM(){
        Console.Write("\nNative Execute Machine\n\n");

        for (;;){
            Console.Write("nem: ");
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries) ?? ["", "", ""];

            if (input.Count() < 1) continue; // Если на ввод пустота, пропускаем

            switch (input[0]){ // input[0] - run | input[1] - file_name | input[2] - command
                case "?":
                case "commands":
                case "help":{
                    Console.WriteLine("\n Commands:\n     new filename.n\n     delete filename.n\n     list\n     analyze filename.n\n     run filename.n\n     clear\n     exit\n");
                    break;
                }

                case "exit":{
                    _currentMode = TerminalMods.menu;
                    return;
                }

                case "new":{
                    if (!CheckPC.CheckInput("new", input))
                        break;

                    if (input.Count() < 3){
                        File.WriteAllText(input[1], HELLO_CODE);
                        break;
                    }

                    switch (input[2]){
                        case "-e":{
                            File.WriteAllText(input[1], "");
                            break;
                        }
                        case "-c":{
                            File.WriteAllText(input[1], CALC_CODE);
                            break;
                        }
                        default:{
                            File.WriteAllText(input[1], HELLO_CODE);
                            break;
                        }

                    }
                    break;
                }

                case "delete":{
                    if (CheckPC.CheckInput("delete", input)){
                        File.Delete(input[1]);
                    } break;
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
                    if (!CheckPC.CheckInput("run", input))
                        break;

                    Parser.Run("run");
                    break;
                }

                case "dis":{
                    if (!CheckPC.CheckInput("dis", input))
                        break;

                    Parser.Run("dis");
                    break;
                }

                case "clear":{
                    Console.Clear();
                    Console.Write("\nNative Execute Machine\n\n");
                    break;
                }
            }    
        }
    }
}