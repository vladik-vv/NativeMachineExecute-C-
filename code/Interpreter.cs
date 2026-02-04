using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic;
using PC;
using static PC.Computer;

public class Interpreter
{
    public static string[] systemArguments = ["0", "0"]; // one, two.
    public static string[] parts = []; // список в котором будут части линии инструкций
    public static int num = 0; // номер текущей строки
    public static int stackAddress = -1; // стэк для запоминания адреса
    public static bool isStop = false; // мы находимся в блоке стоп?
    public static StringBuilder txt = new StringBuilder();
    // строка строитель, в которой мы будем хранить текстовые данные на время выполнения кода.

    public static Dictionary<int, string> codeParts = new Dictionary<int, string>();
    // библиотека в которой хранится ключ: адрес и значение это линия кода.

    public static Dictionary<string, int> blocks = new Dictionary<string, int>();
    // библиотека в которой хранятся адреса блоков

    public static HashSet<string> varsNames = new HashSet<string>(); // список с названиями переменных в адресе
    public static Dictionary<string, byte> varsByte = new Dictionary<string, byte>(); // библиотека с переменными байт
    public static Dictionary<string, short> varsShort = new Dictionary<string, short>(); // библиотека с переменными 2 байт
    public static Dictionary<string, float> varsFloat = new Dictionary<string, float>(); // библиотека с переменными 4 байт
    public static Dictionary<string, double> varsDouble = new Dictionary<string, double>(); // библиотека с переменными 8 байт
    public static Dictionary<string, string> varsString = new Dictionary<string, string>(); // библиотека с переменными стринг

    public static void Run(){
        Clear(); // очищаем мусор
        FillCodeParts(); // заполняем список с кодом
        Interpetation(); // интерпретация

        Console.WriteLine();
    }

    public static void Clear(){
        codeParts.Clear();
        txt.Clear();
        blocks.Clear();
        isStop = false;
        num = 0;
        parts = [];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FillCodeParts(){
        string[] lines = File.ReadAllLines(Terminal.path);
        int num = 0;
        foreach (string line in lines){
            if (line.Trim().Split()[0] == ".block"){
                blocks.Add(line.Trim().Split()[1], num + 1);
            }
            if (line.Trim().Split()[0] == "stop:"){
                blocks.Add("stop:", num);
            }
            codeParts.Add(num, line.Trim());
            num++; 
        }
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void Interpetation(){

        while (true){
            parts = codeParts[num].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            try{
                parts[0] = parts[0]; // проверяем, пустая ли строка?
            } catch {
                num++;
                continue;  // если пустая просто пропускаем
            }

            switch (parts[0]){
                case "start:":{
                    start.run();
                    break;
                }
                case "stop:":{
                    stop.run();
                    break;
                }
                case "end":{
                    if (isStop) return; // если сейчас блок stop
                    end.run();
                    break;
                }
                case "mov":{ // вставить
                    mov.run();
                    if (mov.temp) num = blocks["stop:"];
                    break;
                }
                case "go":{ // перейти
                    go.run();
                    if (go.temp) num = blocks["stop:"];
                    continue;
                }
                case "out":{ // вывести
                    _out.run();
                    if (_out.temp) num = blocks["stop:"];
                    break;            
                }

                case "next":{ // переход на следующую строку
                    next.run();
                    break;
                }

                case "clear":{ // инструкция для очистки ячейки или адреса
                    clear.run();
                    if (clear.temp) num = blocks["stop:"];
                    break;
                }

                case "inp":{ // запрашиваем ввод
                    inp.run();
                    if (inp.temp) num = blocks["stop:"];
                    break;
                }

                case "wait":{ // ожидание
                    wait.run();
                    if (wait.temp) num = blocks["stop:"];
                    break;
                }

                case "add":{ // прибавить
                    add.run();
                    if (add.temp) num = blocks["stop:"];
                    break; 
                }

                case "sub":{ // убавить
                    sub.run();
                    if (sub.temp) num = blocks["stop:"];
                    break;
                }

                case "mul":{ // умножить
                    mul.run();
                    if (mul.temp) num = blocks["stop:"];
                    break;
                }

                case "div":{ // поделить
                    div.run();
                    if (div.temp) num = blocks["stop:"];
                    break;
                }
                
                case "call":{ // вызвать
                    call.run();
                    if (call.temp) num = blocks["stop:"];
                    break;
                }

                case "ret":{ // вернуться
                    ret.run();
                    break;
                } 

                case "db":{ // // создать ячейку для байт
                    db.run();
                    if (db.temp) num = blocks["stop:"];
                    break;
                }

                case "dw":{ // создать ячейку для шортс
                    dw.run();
                    if (dw.temp) num = blocks["stop:"];
                    break;
                }

                case "dd":{ // создать ячейку для флот
                    dd.run();
                    if (dd.temp) num = blocks["stop:"];
                    break;
                }

                case "dq":{ // создать ячейку для дабл
                    dq.run();
                    if (dq.temp) num = blocks["stop:"];
                    break;
                }

                case "ds":{ // создать ячейку для строк
                    ds.run();
                    if (ds.temp) num = blocks["stop:"];
                    break;
                }

                case "cmp":{ // сравнить два значения
                    cmp.run();
                    if (cmp.temp) num = blocks["stop:"];
                    break;
                } 

                case "ife":{ // если равны ==
                    ife.run();
                    if (ife.temp) num = blocks["stop:"];
                    break;
                }

                case "ifn":{ // если не равны !=
                    ifn.run();
                    if (ifn.temp) num = blocks["stop:"];
                    break;
                }

                case "ifg":{ // если больше >
                    ifg.run();
                    if (ifg.temp) num = blocks["stop"];
                    break;
                }

                case "ifl":{ // если меньше <
                    ifl.run();
                    if (ifl.temp) num = blocks["stop"];
                    break;
                }


                default:{
                    num++;
                    break;
                }
            } 
        }
    }
    public static string CheckVarName(string part){ // Проверить к какому типу относится переменная
        if (varsString.Keys.Contains(part)){
            return "string";
        } else if (varsShort.Keys.Contains(part)){
            return "short";
        } else if (varsFloat.Keys.Contains(part)){          
            return "float";
        } else if (varsDouble.Keys.Contains(part)){
            return "double";
        } else if (varsByte.Keys.Contains(part)){
            return "byte";
        } else {
            return "none";
        }
    }

    public static bool CheckVarContain(string part){ // Проверить к какому типу относится переменная
        if (varsString.Keys.Contains(part)){
            return true;
        } else if (varsShort.Keys.Contains(part)){
            return true;
        } else if (varsFloat.Keys.Contains(part)){
            return true;
        } else if (varsDouble.Keys.Contains(part)){
            return true;
        } else if (varsByte.Keys.Contains(part)){
            return true;
        } else {
            return false;
        }
    }
}