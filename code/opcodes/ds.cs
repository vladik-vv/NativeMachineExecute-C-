using static PC.Computer;
using static Interpreter;
#pragma warning disable CS8981
public class ds{
    public static bool temp = false;
    public static void run(){
        temp = false;

        if (varsNames.Contains(parts[1])){
            temp = true;
            Console.WriteLine($"\nLine {num + 1} Error: Redefinition of symbol");
            return;
        }

        try {
            int num2 = 0;
            while (codeParts[num][num2] != '"'){
                num2++;
            }
            num2++;
            while (codeParts[num][num2] != '"'){
                txt.Append(codeParts[num][num2]);
                num2++;
            }

            RAM += txt.Length;
            if (RAM >= maxRAM)
                KillProcessRAM();

            varsString.Add(parts[1], txt.ToString());
            txt.Clear();

        } catch {
            Console.WriteLine($"\nLine {num + 1} Error: Segmentation fault");
            temp = true;
            return;
        }

        varsNames.Add(parts[1]);
        num++;
    }
}