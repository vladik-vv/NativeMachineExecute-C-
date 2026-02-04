using static PC.Computer;
using static Interpreter;
#pragma warning disable CS8981
public class cmp{
    public static bool temp = false;
    public static void run(){
        try {
            temp = false;
            systemArguments[0] = parts[1];

            if (parts[2][0] == '"'){ // если вторая часть строка
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

                systemArguments[1] = txt.ToString();
                num++;
                txt.Clear();
                return;
            }

            systemArguments[1] = parts[2];
            num++;
            return;
        } catch{
            Console.WriteLine($"\nLine {num + 1} Error: Icorrect argument");
            temp = true;
            return;
        }
    }
}