using static PC.Computer;
using static Interpreter;
#pragma warning disable CS8981
public class sub{
    public static bool temp = true;
    
    public static void run(){
        temp = false;

        try {
            parts[1] = parts[1];
            parts[2] = parts[2];
        } catch {
            Console.Write($"\nLine {num + 1} Error - Incorrect address!"); 
            temp = true;
            return;
        }

        try {
        if (registres.Keys.Contains(parts[1])){ // если первый аргумент это регистр
            if (registres.Keys.Contains(parts[2])){ // если второй аргумент регистр
                registres[parts[1]] -= registres[parts[2]];
                temp = false;
                num++;
                return;
            } else { // если второй аргумент это переменнная
                switch (CheckVarName(parts[2])){
                    case "string":{
                        temp = true;
                        Console.Write($"\nLine {num + 1} Error - String and registres?");
                        return;   
                    }
                    case "byte":{
                        temp = false;
                        registres[parts[1]] -= Convert.ToDouble(varsByte[parts[2]]);
                        num++;
                        return;
                    }
                    case "short":{
                        temp = false;
                        registres[parts[1]] -= Convert.ToDouble(varsShort[parts[2]]);
                        num++;
                        return;
                    }
                    case "float":{
                        temp = false;
                        registres[parts[1]] -= Convert.ToDouble(varsFloat[parts[2]]);
                        num++;
                        return;
                    }
                    case "double":{
                        temp = false;
                        registres[parts[1]] -= varsDouble[parts[2]];
                        num++;
                        return;
                    }
                    case "none":{
                        temp = false;
                        break;
                    }
                }
            }
        } else if (CheckVarContain(parts[1])){ // если первый аргумент это переменная
            switch (CheckVarName(parts[1])){
                case "string":{ // если первая переменная стринг
                    Console.Write($"\nLine {num + 1} Error - String and registres?");
                    temp = true;
                    return;
                }
                case "byte":{
                    if (registres.Keys.Contains(parts[2])){ // если второй аргумент регистр  
                        varsByte[parts[1]] -= Convert.ToByte(registres[parts[2]]);
                        num++;
                        return;
                    } else if (CheckVarContain(parts[2])){ // если второй аргумент переменная
                        varsByte[parts[1]] -= varsByte[parts[2]];
                        num++;
                        return;
                    } else { // если второй аргумент это готовое значение
                        varsByte[parts[1]] -= Convert.ToByte(parts[2]);
                        num++;
                        return;
                    }
                }
                case "short":{
                    if (registres.Keys.Contains(parts[2])){ // если второй аргумент регистр  
                        varsShort[parts[1]] -= Convert.ToInt16(registres[parts[2]]);
                        num++;
                        return;
                    } else if (CheckVarContain(parts[2])){ // если второй аргумент переменная
                        varsShort[parts[1]] -= varsShort[parts[2]];
                        num++;
                        return;
                    } else { // если второй аргумент это готовое значение
                        varsShort[parts[1]] -= Convert.ToInt16(parts[2]);
                        num++;
                        return;
                    }
                }
                case "float":{
                    if (registres.Keys.Contains(parts[2])){ // если второй аргумент регистр  
                        varsFloat[parts[1]] -= Convert.ToSingle(registres[parts[2]]);
                        num++;
                        return;
                    } else if (CheckVarContain(parts[2])){ // если второй аргумент переменная
                        varsFloat[parts[1]] -= varsFloat[parts[2]];
                        num++;
                        return;
                    } else { // если второй аргумент это готовое значение
                        varsFloat[parts[1]] -= Convert.ToSingle(parts[2]);
                        num++;
                        return;
                    }
                }
                case "double":{
                    if (registres.Keys.Contains(parts[2])){ // если второй аргумент регистр  
                        varsDouble[parts[1]] -= Convert.ToDouble(registres[parts[2]]);
                        num++;
                        return;
                    } else if (CheckVarContain(parts[2])){ // если второй аргумент переменная
                        varsDouble[parts[1]] -= varsDouble[parts[2]];
                        num++;
                        return;
                    } else { // если второй аргумент это готовое значение
                        varsDouble[parts[1]] -= Convert.ToDouble(parts[2]);
                        num++;
                        return;
                    }
                }
            }
        }
        
        registres[parts[1]] -= double.Parse(parts[2]);
        num++;
        return;

        } catch {
            temp = true;
            Console.Write($"\nLine {num + 1} Error - Incorrect address!"); 
            return;  
        }
    }
}