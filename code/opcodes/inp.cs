using static PC.Computer;
using static Interpreter;
#pragma warning disable CS8981
public class inp{
    public static bool temp = false;
    public static void run(){
        temp = false;
        if (parts.Count() > 1){
            if (registres.Keys.Contains(parts[1])){ // если входные данные идут в регистр
                registres[parts[1]] = Convert.ToDouble(Console.ReadLine());
                num++;
                return;
            } else {
                if (CheckVarContain(parts[1])){
                    try {
                        switch (CheckVarName(parts[1])){
                            case "string":{
                                varsString[parts[1]] = Console.ReadLine() ?? "";
                                num++;
                                return;
                            }
                            case "byte":{
                                varsByte[parts[1]] = Convert.ToByte(Console.ReadLine());
                                num++;
                                return;
                            }
                            case "short":{
                                varsShort[parts[1]] = Convert.ToInt16(Console.ReadLine());
                                num++;
                                return;
                            }
                            case "float":{
                                varsFloat[parts[1]] = Convert.ToSingle(Console.ReadLine());
                                num++;
                                return;
                            }
                            case "double":{
                                varsDouble[parts[1]] = Convert.ToDouble(Console.ReadLine());
                                num++;
                                return;
                            }
                        }
                    } catch {
                        Console.Write($"\nLine {num + 1} Error: Segmentation fault");
                        temp = true;
                        return;
                    }
                } else {
                    Console.Write($"\nLine {num + 1} Error: Incorrect address");
                    temp = true;
                    return;
                }
            }
        } else {
            Console.ReadLine();
        }
        num++;

    }
}