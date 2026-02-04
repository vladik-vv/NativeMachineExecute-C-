using static PC.Computer;
using static Interpreter;
public class _out{
    public static bool temp = true;
    public static void run(){
        temp = false;

        try {
            parts[1] = parts[1];
        } catch {
            Console.Write($"\nLine {num + 1} Error - Incorrect output!"); 
            return;  
        }

        if (registres.Keys.Contains(parts[1])){ // если на вывод дается регистр
            Console.Write(registres[parts[1]]);
            num++;
            return;
        } 

        switch (CheckVarName(parts[1])){
            case "string":{
                Console.Write(varsString[parts[1]]);
                num++;
                return;
            }
            case "byte":{
                Console.Write(varsByte[parts[1]]);
                num++;
                return;
            }
            case "short":{
                Console.Write(varsShort[parts[1]]);
                num++;
                return;
            }
            case "float":{
                Console.Write(varsFloat[parts[1]]);
                num++;
                return;
            }
            case "double":{
                Console.Write(varsDouble[parts[1]]);
                num++;
                return;    
            }
            case "none":{
                temp = false;
                break;
            }
        }
        if (temp) return;

        if (parts[1][0] == '"'){ // если на вывод дается готовый текст
            int num2 = 5;
            try {
                while (codeParts[num][num2] != '"'){
                    txt.Append(codeParts[num][num2]);
                    num2++;
                }
            } catch {
                temp = true;
                Console.Write($"\nLine {num + 1} Error - Incorrect output!");
                return;  
            }

            Console.Write(txt);
            txt.Clear();
            num++;
            return;    
        } else {
            temp = true;
            Console.Write($"\nLine {num + 1} Error - Address {parts[1]} is not exist!");
            return;    
        }        
    }
}