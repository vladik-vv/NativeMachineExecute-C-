using static PC.Computer;
using static Interpreter;
#pragma warning disable CS8981
public class mov{
    public static bool temp = false;
    public static void run(){
        temp = false;
        if (registres.Keys.Contains(parts[1])){ // если первый аргумент регистр
            if (registres.Keys.Contains(parts[2])) { // если второй аргумент регистр
                registres[parts[1]] = registres[parts[2]];
                num++;
                return;
            } else if (CheckVarContain(parts[2])){ // если второй аргумент переменная
                switch (CheckVarName(parts[2])){
                    case "string":{
                        temp = true;
                        Console.Write($"\nLine {num + 1} Error - String and registres?");
                        return;   
                    }
                    case "byte":{
                        registres[parts[1]] = Convert.ToDouble(varsByte[parts[2]]);
                        num++;
                        return;
                    }
                    case "short":{
                        registres[parts[1]] = Convert.ToDouble(varsShort[parts[2]]);
                        num++;
                        return;
                    }
                    case "float":{
                        registres[parts[1]] = Convert.ToDouble(varsFloat[parts[2]]);
                        num++;
                        return;
                    }
                    case "double":{
                        registres[parts[1]] = Convert.ToDouble(varsDouble[parts[2]]);
                        num++;
                        return;
                    }
                }  
            } else {
                registres[parts[1]] = Convert.ToDouble(parts[2]);

                num++;
                return;
            }
        } else { // если первый аргумент переменная
            if (!CheckVarContain(parts[1])){
                temp = true;
                Console.Write($"\nLine {num + 1} Error - Address {parts[1]} is not exist!");
                return;
            }
            
            switch (CheckVarName(parts[1])){
                case "string":{
                    if (registres.Keys.Contains(parts[2])){ // если второй аргумент регистр
                        varsString[parts[1]] = registres[parts[2]].ToString();
                        num++;
                        return;
                    } else if (varsString.Keys.Contains(parts[2])){ // если второй аргумент переменная
                        varsString[parts[1]] = varsString[parts[2]];
                        num++;
                        return;
                    } else { // если второй аргумент это строка
                        txt.Clear();
                        int numtemp = 0; 
                        while (codeParts[num][numtemp] != '"'){
                            numtemp++;
                        }
                        numtemp++;
                        while (codeParts[num][numtemp] != '"'){
                            txt.Append(codeParts[num][numtemp]);
                            numtemp++;
                        }
                        RAM -= varsString[parts[1]].Length;
                        varsString[parts[1]] = txt.ToString();
                        RAM += txt.Length;
                        txt.Clear();

                        num++;
                        return;
                    }
                }
                case "byte":{
                    if (registres.Keys.Contains(parts[2])){ // если второй аргумент регистр
                        varsByte[parts[1]] = Convert.ToByte(registres[parts[2]]);
                        num++;
                        return;
                    } else if (varsByte.Keys.Contains(parts[2])){ // если второй аргумент переменная
                        varsByte[parts[1]] = varsByte[parts[2]];
                        num++;
                        return;
                    } else { // если второй аргумент это число
                        varsByte[parts[1]] = Convert.ToByte(parts[2]);
                        num++;
                        return;                       
                    }
                }
                case "short":{
                    if (registres.Keys.Contains(parts[2])){ // если второй аргумент регистр
                        varsShort[parts[1]] = Convert.ToInt16(registres[parts[2]]);
                        num++;
                        return;
                    } else if (varsShort.Keys.Contains(parts[2])){ // если второй аргумент переменная
                        varsShort[parts[1]] = varsShort[parts[2]];
                        num++;
                        return;
                    } else { // если второй аргумент это число
                        varsShort[parts[1]] = Convert.ToInt16(parts[2]);
                        num++;
                        return;                       
                    }
                }
                case "float":{
                    if (registres.Keys.Contains(parts[2])){ // если второй аргумент регистр
                        varsFloat[parts[1]] = Convert.ToSingle(registres[parts[2]]);
                        num++;
                        return;
                    } else if (varsFloat.Keys.Contains(parts[2])){ // если второй аргумент переменная
                        varsFloat[parts[1]] = varsFloat[parts[2]];
                        num++;
                        return;
                    } else { // если второй аргумент это число
                        varsFloat[parts[1]] = Convert.ToSingle(parts[2]);
                        num++;
                        return;                       
                    }
                }
                case "double":{
                    if (registres.Keys.Contains(parts[2])){ // если второй аргумент регистр
                        varsDouble[parts[1]] = Convert.ToDouble(registres[parts[2]]);
                        num++;
                        return;
                    } else if (varsDouble.Keys.Contains(parts[2])){ // если второй аргумент переменная
                        varsDouble[parts[1]] = varsDouble[parts[2]];
                        num++;
                        return;
                    } else { // если второй аргумент это число
                        varsDouble[parts[1]] = Convert.ToDouble(parts[2]);
                        num++;
                        return;                       
                    }
                }
            }
        }

        num++;
    }
}