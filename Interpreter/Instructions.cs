using System.Net;

static class Instructions{

    static KeyValuePair<Types, KeyValuePair<string, int>>? arg1;
    static string instruction;
    static string arg2;
    static string line;

    static Dictionary<string, Action> opcodes = new Dictionary<string, Action>{
        {"out", () => ExecuteOut()},
        {"hlt", () => ExecuteHlt()},
        {"clear", () => ExecuteClear()},
        {"mov", () => ExecuteMath("mov")},
        {"add", () => ExecuteMath("add")},
        {"sub", () => ExecuteMath("sub")},
        {"div", () => ExecuteMath("div")},
        {"mul", () => ExecuteMath("mul")},
    };
    
    public static void Start(string _instruction, KeyValuePair<Types, KeyValuePair<string, int>>? _arg1, string _arg2, string _line){

        instruction = _instruction;
        arg1 = _arg1;
        arg2 = _arg2;
        line = _line;

         opcodes[instruction]();
    }


    static void ExecuteOut(){ // вывести
        Console.Write(arg2);
        try{
            string[] temp_parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int num = 0;
            while (num < Convert.ToInt32(temp_parts[temp_parts.Count() - 1])){
                Console.WriteLine();
                num++;
            }
        } catch {}
    }


    static void ExecuteHlt(){
        Interpreter.numberLine = Interpreter.blocks["__stop:"];
    }


    static void ExecuteClear(){
        switch (arg2){
            case "registres":{
                Computer.ClearRegistres(); 
                break;
            }
        }
    }

    static void ExecuteMath(string mode){

        string type = arg1.Value.Key.ToString();
        string name = arg1.Value.Value.Key;
        
        switch (type){
            case "_registres":{
                switch (mode){
                    case "mov":{
                        Computer.registres[name] = Convert.ToDouble(arg2);
                        break;
                    }
                    case "add":{
                        Computer.registres[name] += Convert.ToDouble(arg2);
                        break;
                    }
                    case "sub":{
                        Computer.registres[name] -= Convert.ToDouble(arg2);
                        break;
                    }
                    case "div":{
                        Computer.registres[name] /= Convert.ToDouble(arg2);
                        break;
                    }
                    case "mul":{
                        Computer.registres[name] *= Convert.ToDouble(arg2);
                        break;
                    }
                }
                break;
            }
        }
    }
}