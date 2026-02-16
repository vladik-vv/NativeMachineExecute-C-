using System.Text;
using static Parser;
using static Init;
using static Types;

struct CheckArguments{
    
    private static string instruction; // инструкция
    private static string? arg1; // самый первый аргумент, после инструкции
    private static string? arg2; // второй аргумент, после инструкции
    private static string line = ""; // линия инструкций

    private static Types? currentType;
    private static string? nameArg1; // имя аргумента 1
    private static Types? typeArg1; // тип аргумента 1
    private static int elementNumberArg1; // номер элемента массива 
    private static string Argument2 = ""; // Аргумент два - хранит в себе готовое значение

    public static void Run(string _instruction, string? _arg1, string? _arg2, string _line){

        instruction = _instruction;
        arg1 = _arg1;
        arg2 = _arg2;
        line = _line;

        nameArg1 = null;
        typeArg1 = null;
        Argument2 = ""; // Аргумент 2 - всегда готовое значение

        CheckArgs();

        Executer.Start(instruction, currentType, typeArg1, elementNumberArg1, nameArg1, Argument2, line);
    }
   
    private static void CheckArgs(){
        switch (instruction){
            case "vec2":
            case "vec3":
            case "vec4":
            case "go":
            case "call":
            case "wait":
            case "out":{
                arg2 = arg1;
                GetValueToArg2();
                return;
            }
            case "inp":
            case "srt":
            case "pop": 
            case "push":
            case "clear":{ 
                GetValueToArg1();
                break;
            }
            case "ife":
            case "ifn":
            case "ifh":
            case "ifl":
            case "cmp":
            case "db":
            case "dw":
            case "dd":
            case "dq":
            case "ds":
            case "arrb":
            case "arrw":
            case "arrd":
            case "arrq":
            case "arrs":
            case "rand":
            case "dst":
            case "lng":
            case "lngsq":
            case "cos":
            case "sin":
            case "tan":
            case "max":
            case "min":
            case "len":
            case "mov":
            case "add":
            case "sub":
            case "div":
            case "mul":
            {
                GetValueToArg1();
                GetValueToArg2();
                break;
            }
            case "popa":
            case "pusha":{
                break;
            }
        }
    }

    private static void GetValueToArg1(){

        if (arg1 == "keyboard.key"){
            nameArg1 = keyInfo.Key.ToString();
            return;
        }

        else if (registres.ContainsKey(arg1)){ // проверяем является ли аргумент регистром
            typeArg1 = _registres;
            nameArg1 = arg1;
            return;
        }

        else if (instruction == "db" || instruction == "dw" || instruction == "dd" || instruction == "dq" || instruction == "ds" || instruction == "ife" || instruction == "ifn" || instruction == "ifh" || instruction == "ifl" || instruction == "arrb" || instruction == "arrw" || instruction == "arrd" || instruction == "arrq" || instruction == "arrs" || instruction == "pop" || instruction == "push"){
            nameArg1 = arg1;    // так как, arg1 является именем / инструкцией
            return;
        }

        else if (CheckArgToVector("arg1")) // ПРОВЕРЯЕМ АРГУМЕНТ НА КООРДИНАТУ ВЕКТОРА
            return;
        

        else if (arg1.Contains('[') && arg1.Contains(']')){ // если первый аргумент это элемент массива
            nameArg1 = arg1.Replace('[', ' ').Replace(']', ' ').Split()[0];
            elementNumberArg1 = NumberElementArr(arg1.Replace('[', ' ').Replace(']', ' ').Split()[1]);

            if (byteArrs.ContainsKey(nameArg1)) {typeArg1 = Types._byteARR; return;}
            if (shortArrs.ContainsKey(nameArg1)) {typeArg1 = Types._shortARR; return;}
            if (floatArrs.ContainsKey(nameArg1)) {typeArg1 = Types._floatARR; return;}
            if (doubleArrs.ContainsKey(nameArg1)) {typeArg1 = Types._doubleARR; return;}
            if (stringArrs.ContainsKey(nameArg1)) {typeArg1 = Types._stringARR; return;}
            return; 
        }

        else if (nameVars.Contains(arg1)){ // проверяем является ли аргумент переменной
            if (byteVars.ContainsKey(arg1)){ typeArg1 = Types._byte; nameArg1 = arg1; return; }
            if (shortVars.ContainsKey(arg1)){ typeArg1 = Types._short; nameArg1 = arg1; return; }
            if (floatVars.ContainsKey(arg1)){ typeArg1 = Types._float; nameArg1 = arg1; return; }
            if (doubleVars.ContainsKey(arg1)){ typeArg1 = Types._double; nameArg1 = arg1; return; }
            if (stringVars.ContainsKey(arg1)){ typeArg1 = Types._string; nameArg1 = arg1; return; }
            if (byteArrs.ContainsKey(arg1)){ typeArg1 = Types._byteARR; nameArg1 = arg1; return; }
            if (shortArrs.ContainsKey(arg1)){ typeArg1 = Types._shortARR; nameArg1 = arg1; return; }
            if (floatArrs.ContainsKey(arg1)){ typeArg1 = Types._floatARR; nameArg1 = arg1; return; }
            if (doubleArrs.ContainsKey(arg1)){ typeArg1 = Types._doubleARR; nameArg1 = arg1; return; }
            if (stringArrs.ContainsKey(arg1)){ typeArg1 = Types._stringARR; nameArg1 = arg1; return; }
            if (vec2s.ContainsKey(arg1)){ typeArg1 = Types._vector2; nameArg1 = arg1; return; }
            if (vec3s.ContainsKey(arg1)){ typeArg1 = Types._vector3; nameArg1 = arg1; return; }
            if (vec4s.ContainsKey(arg1)){ typeArg1 = Types._vector4; nameArg1 = arg1; return; }
        } else {
            nameArg1 = arg1;
            return;
        }
    }

    private static void GetValueToArg2(){ // Получаем значение и передаем в 2 аргумент

        if (arg2 == "keyboard.key"){
            Argument2 = keyInfo.Key.ToString();
            return;
        }

        else if (instruction == "go" || instruction == "call" || instruction == "ife" || instruction == "ifn" || instruction == "ifl" || instruction == "ifh" || instruction == "vec2" || instruction == "vec3" || instruction == "vec4" || instruction == "dst" || instruction == "lng" || instruction == "lngsq" || instruction == "clear" || instruction == "max" || instruction == "min"){
            Argument2 = arg2;
            return;
        }

        else if (registres.ContainsKey(arg2))
        { // проверяем является ли аргумент регистром
            Argument2 = registres[arg2].ToString();
            currentType = Types._double;
            return;
        }

        else if (CheckArgToVector("arg2")) // ПРОВЕРЯЕМ АРГУМЕНТ НА КООРДИНАТУ ВЕКТОРА
            return;


        else if (nameVars.Contains(arg2)){ // проверяем является ли аргумент переменной
            if (byteVars.ContainsKey(arg2)){ Argument2 = byteVars[arg2].ToString(); currentType = Types._byte; return; }
            if (shortVars.ContainsKey(arg2)){ Argument2 = shortVars[arg2].ToString(); currentType = Types._short; return; }
            if (floatVars.ContainsKey(arg2)){ Argument2 = floatVars[arg2].ToString(); currentType = Types._float; return; }
            if (doubleVars.ContainsKey(arg2)){ Argument2 = doubleVars[arg2].ToString(); currentType = Types._double; return; }
            if (stringVars.ContainsKey(arg2)){ Argument2 = stringVars[arg2].ToString(); currentType = Types._string; return; }
            if (vec2s.ContainsKey(arg2)){ Argument2 = vec2s[arg2].Print(); return; }
            if (vec3s.ContainsKey(arg2)){ Argument2 = vec3s[arg2].Print(); return; }
            if (vec4s.ContainsKey(arg2)){ Argument2 = vec4s[arg2].Print(); return; }
        }

        else if (arg2.Contains('[') && arg2.Contains(']')){ // если второй аргумент это элемент массива
            string nameA = arg2.Replace('[', ' ').Replace(']', ' ').Split()[0];
            int numberA = NumberElementArr(arg2.Replace('[', ' ').Replace(']', ' ').Split()[1]);

            if (byteArrs.ContainsKey(nameA)) {Argument2 = byteArrs[nameA][numberA].ToString(); return;}
            if (shortArrs.ContainsKey(nameA)) {Argument2 = shortArrs[nameA][numberA].ToString(); return;}
            if (floatArrs.ContainsKey(nameA)) {Argument2 = floatArrs[nameA][numberA].ToString(); return;}
            if (doubleArrs.ContainsKey(nameA)) {Argument2 = doubleArrs[nameA][numberA].ToString(); return;}
            if (stringArrs.ContainsKey(nameA)) {Argument2 = stringArrs[nameA][numberA]; return;}
            if (stringVars.ContainsKey(nameA)) {Argument2 = stringVars[nameA][numberA].ToString(); return;}
            return; 
        }

        bool isAquotes = false; 
        bool isAstring = false;
        StringBuilder? tempText = new StringBuilder();
        foreach (char ch in line){
            if (ch == '"'){
                isAquotes = !isAquotes;
                isAstring = true;
                continue;
            } 
            if (isAquotes){
                tempText.Append(ch);
            }
        }
        if (isAstring == true){ // если переменная является строкой
            Argument2 = tempText.ToString();
            currentType = Types._string;
            return;
        } else {
            Argument2 = arg2; 
            currentType = Types._number;
            return;
        }
    }

    private static bool CheckArgToVector(string argS){ // проверяем является ли аргумент вектором
        StringBuilder tempArg = new StringBuilder(); 
        int numChar = 0; 
        if (argS == "arg1"){
            foreach (char ch in arg1){
                if (ch != '.'){
                    tempArg.Append(ch);
                    numChar++;
                } else {
                    if (vec2s.ContainsKey(tempArg.ToString())){
                        currentType = Types._double;
                        switch (arg1[numChar + 1]){
                            case 'x': typeArg1 = Types._vector2x; nameArg1 = tempArg.ToString(); return true;
                            case 'y': typeArg1 = Types._vector2y; nameArg1 = tempArg.ToString(); return true;
                        }
                    } else if (vec3s.ContainsKey(tempArg.ToString())){
                        currentType = Types._double;
                        switch (arg1[numChar + 1]){
                            case 'x': typeArg1 = Types._vector3x; nameArg1 = tempArg.ToString(); return true;
                            case 'y': typeArg1 = Types._vector3y; nameArg1 = tempArg.ToString(); return true;
                            case 'z': typeArg1 = Types._vector3z; nameArg1 = tempArg.ToString(); return true;
                        }
                    } else if (vec4s.ContainsKey(tempArg.ToString())){
                        currentType = Types._double;
                        switch (arg1[numChar + 1]){
                            case 'x': typeArg1 = Types._vector4x; nameArg1 = tempArg.ToString(); return true;
                            case 'y': typeArg1 = Types._vector4y; nameArg1 = tempArg.ToString(); return true;
                            case 'z': typeArg1 = Types._vector4z; nameArg1 = tempArg.ToString(); return true;
                            case 'w': typeArg1 = Types._vector4w; nameArg1 = tempArg.ToString(); return true;
                        }
                    }
                }
            }
        } else {
            foreach (char ch in arg2){
                if (ch != '.'){
                    tempArg.Append(ch);
                    numChar++;
                } else {
                    string name = tempArg.ToString();
                    if (vec2s.ContainsKey(name)){ // если вектор2
                        currentType = Types._double;
                        switch (arg2[numChar + 1]){
                            case 'x': Argument2 = vec2s[name].X.ToString(); return true;
                            case 'y': Argument2 = vec2s[name].Y.ToString(); return true;
                        }
                    } else if (vec3s.ContainsKey(name)){ // если вектор3
                        currentType = Types._double;
                        switch (arg2[numChar + 1]){
                            case 'x': Argument2 = vec3s[name].X.ToString(); return true;
                            case 'y': Argument2 = vec3s[name].Y.ToString(); return true;
                            case 'z': Argument2 = vec3s[name].Z.ToString(); return true;
                        }
                    } else if (vec4s.ContainsKey(name)){ // если вектор4
                        currentType = Types._double;
                        switch (arg2[numChar + 1]){
                            case 'x': Argument2 = vec4s[name].X.ToString(); return true;
                            case 'y': Argument2 = vec4s[name].Y.ToString(); return true;
                            case 'z': Argument2 = vec4s[name].Z.ToString(); return true;
                            case 'w': Argument2 = vec4s[name].W.ToString(); return true;
                        }
                    }
                }
            }
        } 
        return false;
    }

    private static int NumberElementArr(string element){
        
        if (registres.ContainsKey(element)){
            return (int)registres[element];
        } else if (nameVars.Contains(element)){
            if (byteVars.ContainsKey(element)) return byteVars[element];
            if (shortVars.ContainsKey(element)) return byteVars[element];
            if (floatVars.ContainsKey(element)) return byteVars[element];
            if (doubleVars.ContainsKey(element)) return byteVars[element];
            return Convert.ToInt32(element);
        } else if (element.Contains('.')){
            string name = element.Substring(0, element.IndexOf('.'));
            if (vec2s.ContainsKey(name)){ // если вектор2
                currentType = Types._double;
                switch (element[^1]){
                    case 'x': return (int)vec2s[name].X;
                    case 'y': return (int)vec2s[name].Y;
                }
            } else if (vec3s.ContainsKey(name)){ // если вектор3
                currentType = Types._double;
                switch (element[^1]){
                    case 'x': return (int)vec3s[name].X;
                    case 'y': return (int)vec3s[name].Y;
                    case 'z': return (int)vec3s[name].Z;
                }
            } else if (vec4s.ContainsKey(name)){ // если вектор4
                currentType = Types._double;
                switch (element[^1]){
                    case 'x': return (int)vec4s[name].X;
                    case 'y': return (int)vec4s[name].Y;
                    case 'z': return (int)vec4s[name].Z;
                    case 'w': return (int)vec4s[name].W;
                }
            } else {
                Errors.Print(0x08);
                return 0;
            }
            Errors.Print(0x08);
            return 0;
        } else {
            return Convert.ToInt32(element);
        }
    }

}