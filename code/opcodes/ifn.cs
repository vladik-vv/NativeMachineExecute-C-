using static PC.Computer;
using static Interpreter;
#pragma warning disable CS8981
public class ifn{
    public static bool temp = false;
    public static void run(){
        temp = false;
        try {
            if (registres.Keys.Contains(systemArguments[0])){ // если первый аргумент регистр
                if (registres.Keys.Contains(systemArguments[1])){ // если второй аргумент тоже регистр
                    if (registres[systemArguments[0]] != registres[systemArguments[1]]){ // если они равны
                        goo();
                        return;
                    } else {
                        num++;
                        return;
                    }
                } else if (CheckVarContain(systemArguments[1])) { // если второй аргумент это переменная
                    switch (CheckVarName(systemArguments[1])){
                        case "string":{
                            Console.WriteLine($"\nLine {num + 1} Error: string && register?");
                            temp = true;
                            return;
                        }
                        case "byte":{
                            if (registres[systemArguments[0]] != Convert.ToDouble(varsByte[systemArguments[1]])){
                                goo();
                                return;
                            } else {
                                num++;
                                return;
                            }
                        }
                        case "short":{
                            if (registres[systemArguments[0]] != Convert.ToDouble(varsShort[systemArguments[1]])){
                                goo();
                                return;
                            } else {
                                num++;
                                return;
                            }
                        }
                        case "float":{
                            if (registres[systemArguments[0]] != Convert.ToDouble(varsFloat[systemArguments[1]])){
                                goo();
                                return;
                            } else {
                                num++;
                                return;
                            }
                        }
                        case "double":{
                            if (registres[systemArguments[0]] != Convert.ToDouble(varsDouble[systemArguments[1]])){
                                goo();
                                return;
                            } else {
                                num++;
                                return;
                            }
                        }
                    }
                } else { // если второй аргумент готовое число
                    if (registres[systemArguments[0]] == Convert.ToDouble(systemArguments[1])){
                        goo();
                        return;
                    } else {
                        num++;
                        return;
                    }
                }
            } else if (CheckVarContain(systemArguments[0])){ // если первый аргумент переменная
                if (registres.Keys.Contains(systemArguments[1])){ // если второй аргумент регистр
                    switch (CheckVarName(systemArguments[0])){
                        case "string":{
                            Console.WriteLine($"\nLine {num + 1} Error: string && register?");
                            temp = true;
                            return;
                        }
                        case "byte":{
                            if (varsByte[systemArguments[0]] != registres[systemArguments[1]]){
                                goo();
                                return;
                            } else {
                                num++;
                                return;
                            }
                        }
                        case "short":{
                            if (varsShort[systemArguments[0]] != registres[systemArguments[1]]){
                                goo();
                                return;
                            } else {
                                num++;
                                return;
                            }
                        }
                        case "float":{
                            if (varsFloat[systemArguments[0]] != registres[systemArguments[1]]){
                                goo();
                                return;
                            } else {
                                num++;
                                return;
                            }
                        }
                        case "double":{
                            if (varsDouble[systemArguments[0]] != registres[systemArguments[1]]){
                                goo();
                                return;
                            } else {
                                num++;
                                return;
                            }
                        }
                    }
                } else if (CheckVarContain(systemArguments[1])){ // если второй аргумент тоже переменная
                    switch (CheckVarName(systemArguments[0])){
                        case "string":{
                            if (varsString[systemArguments[0]] != varsString[systemArguments[1]]){
                                goo();
                                return;
                            } else {
                                num++;
                                return;
                            }
                        }
                        case "byte":{
                            if (varsByte[systemArguments[0]] != varsByte[systemArguments[1]]){
                                goo();
                                return;
                            } else {
                                num++;
                                return;
                            }
                        }
                        case "short":{
                            if (varsShort[systemArguments[0]] != varsShort[systemArguments[1]]){
                                goo();
                                return;
                            } else {
                                num++;
                                return;
                            }
                        }
                        case "float":{
                            if (varsFloat[systemArguments[0]] != varsFloat[systemArguments[1]]){
                                goo();
                                return;
                            } else {
                                num++;
                                return;
                            }
                        }
                        case "double":{
                            if (varsDouble[systemArguments[0]] != varsDouble[systemArguments[1]]){
                                goo();
                                return;
                            } else {
                                num++;
                                return;
                            }
                        }
                    }
                } else { // если второй аргумент готовое число или текст
                    switch (CheckVarName(systemArguments[0])){
                        case "string":{
                            if (varsString[systemArguments[0]] != systemArguments[1]){
                                goo();
                                return;
                            } else {
                                num++;
                                return;
                            }
                        }
                        case "byte":{
                            if (varsByte[systemArguments[0]] != Convert.ToByte(systemArguments[1])){
                                goo();
                                return;
                            } else {
                                num++;
                                return;
                            }
                        }
                        case "short":{
                            if (varsShort[systemArguments[0]] != Convert.ToInt16(systemArguments[1])){
                                goo();
                                return;
                            } else {
                                num++;
                                return;
                            }
                        }
                        case "float":{
                            if (varsFloat[systemArguments[0]] != Convert.ToSingle(systemArguments[1])){
                                goo();
                                return;
                            } else {
                                num++;
                                return;
                            }
                        }
                        case "double":{
                            if (varsDouble[systemArguments[0]] != Convert.ToDouble(systemArguments[1])){
                                goo();
                                return;
                            } else {
                                num++;
                                return;
                            }
                        }
                    }
                }
            }
        } catch {
            Console.WriteLine($"\nLine {num + 1} Error: Icorrect argument");
            temp = true;
            return;
        }

        
    }

    static void goo(){
        if (parts[1] == "go"){
            num = blocks[parts[2] + ":"];
            return;
        } else if (parts[1] == "call"){
            stackAddress = num + 1;
            num = blocks[parts[2] + ":"];
            return;
        }

        num++;
        return;
    }
}