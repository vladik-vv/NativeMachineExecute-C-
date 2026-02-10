using System.Net.Http.Headers;
using System.Text;

static class CheckArguments{

    static readonly string[] addressForClear = {"registres"};
    
    static string instruction = "";
    static string? arg1;
    static string? arg2;
    static string line = "";

    static KeyValuePair<Types, KeyValuePair<string, int>> ArgumentOne;
    // Аргумент один - хранит в себе тип, имя и ячейку (если тип не массив то ячейка не првоеряется)

    static string ArgumentTwo = "";
    // Аргумент два - хранит в себе готовое значение

    public static void Run(string _instruction, string? _arg1, string? _arg2, string _line){

        instruction = _instruction;
        arg1 = _arg1;
        arg2 = _arg2;
        line = _line;

        if (arg1 != null)
            CheckArg1();

        if (arg2 != null)
            CheckArg2();

        CheckString();

        Instructions.Start(instruction, ArgumentOne, ArgumentTwo, line);

    }

    private static void CheckArg1(){ // проверить первый аргумент
        
        if (addressForClear.Contains(arg1)){
            ArgumentTwo = arg1;
            return;
        }

        if (Computer.registres.ContainsKey(arg1)){
            if (instruction == "out"){
                ArgumentTwo = Computer.registres[arg1].ToString();
                return;
            }
            ArgumentOne = new ( Types._registres, new (arg1, 0) );
            return;
        }
    }

    private static void CheckArg2(){ // проверить второй аргумент
        
        if (Computer.registres.ContainsKey(arg2)){
            ArgumentTwo = Computer.registres[arg2].ToString();
            return;
        } else {
            if (instruction != "out"){
                ArgumentTwo = arg2;
            }
            return;
        }

    }

    private static void CheckString(){
        bool isChar = false;
        foreach (char ch in line){
            if (ch == '\''){
                isChar = true;
                break;
            }
        }

        if (isChar){
            GetStringArg(); // распарсить строку и передать в аргумент 2
            return;
        }
    }

    private static void GetStringArg(){
        int numChar = 0;
        StringBuilder text = new StringBuilder();
        while (line[numChar] != '\''){
            numChar++;
        } 
        numChar++;
        while (line[numChar] != '\''){
            text.Append(line[numChar]);
            numChar++;
        }
        
        ArgumentTwo = text.ToString();
    }

    

}