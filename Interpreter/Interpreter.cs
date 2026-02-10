using System.Numerics;
using System.Text;
static class Interpreter
{   
    public const string systemKey = "system.key";
    public static Random rnd = new Random();
    public static bool isWarn = false; // если true то инструкция завершилась с ошибкой.
    public static bool isEnd = false;
    public static bool isStop = false; // мы находимся в блоке стоп?
    public static int stackAddress = -1; // стэк для запоминания адреса
    public static string[] systemArguments = ["0", "0"]; // one, two.
    public static string[] parts = []; // список в котором будут части линии инструкций
    public static int numberLine = 0; // номер текущей строки
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
    public static Dictionary<string, byte[]> arrsByte = new Dictionary<string, byte[]>(); // массивы байт
    public static Dictionary<string, short[]> arrsShort = new Dictionary<string, short[]>(); // массивы 2 байт
    public static Dictionary<string, float[]> arrsFloat = new Dictionary<string, float[]>(); // массивы 4 байт
    public static Dictionary<string, double[]> arrsDouble = new Dictionary<string, double[]>(); // массивы 8 байт
    public static Dictionary<string, string[]> arrsString = new Dictionary<string, string[]>(); // массивы строк
    public static Dictionary<string, Vector2> vec2s = new Dictionary<string, Vector2>(); // Вектора 2д
    public static Dictionary<string, Vector3> vec3s = new Dictionary<string, Vector3>(); // Вектора 3д
    public static char currentVectorCord; // x, y, z
    public static string? currentVectorName;
    public static byte currentVectorD; // 2, 3
    public static Dictionary<string, Type> varsTypes = new Dictionary<string, Type>(); // Переменные с типами
    public static Dictionary<string, int> currentArr = new Dictionary<string, int>(); // имя и номер элемента
    public readonly static Dictionary<string, Action> opcodes = new Dictionary<string, Action>{
        
    };

    public static void Run(string mode){

        switch (mode){
            case "dis":{
                Clear();
                FillCodeParts();
                DisAssembly();  // дизассемблирование
                break;
            }
            case "run":{
                Clear(); // очищаем мусор
                FillCodeParts(); // заполняем список с кодом
                Interpetation(); // интерпретация

                Console.WriteLine();
                break;    
            }
        }
    }

    private static void Clear(){
        parts = [];
        codeParts.Clear();
        blocks.Clear();
        isStop = false;
        numberLine = 0;
        stackAddress = -1;
        isWarn = false;
        isEnd = false;
        varsNames.Clear();
        varsByte.Clear();
        varsFloat.Clear();
        varsDouble.Clear();
        varsShort.Clear();
        varsString.Clear();
        arrsByte.Clear();
        arrsShort.Clear();
        arrsFloat.Clear();
        arrsDouble.Clear();
        arrsString.Clear();
        vec2s.Clear();
        vec3s.Clear();
    }


    private static void FillCodeParts(){
        string[] lines = File.ReadAllLines(Terminal.path);

        foreach (string line in lines){

            switch (line.Trim().Split()[0]){
                case ".p":{
                    blocks.Add(line.Trim().Split()[1], numberLine + 1);
                    break;
                }
                case "__stop:":{
                    blocks.Add("__stop:", numberLine);
                    break;
                }
                case "__start:":{
                    blocks.Add("__start:", numberLine);
                    break;
                }
            }

            StringBuilder txt = new StringBuilder();
            bool commaRemove = false;   // запятая пропущена?
            foreach (char ch in line){
                if ((ch == ',' || ch == '\'') && commaRemove == false){
                    if (ch == '\''){
                        txt.Append(ch);
                        commaRemove = true; 
                        continue;
                    }
                    commaRemove = true;
                    continue;
                } else {
                    txt.Append(ch);
                }
            }

            codeParts.Add(numberLine, txt.ToString().Trim());
            numberLine++; 
            txt.Clear();
        }
    }

    private static void Interpetation(){
        numberLine = blocks["__start:"];

        while (numberLine < codeParts.Count()){
            string line = codeParts[numberLine];
            numberLine++;
            parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries); 

            try {
                parts[0] = parts[0];
            } catch {
                continue;
            }

            if (parts[0][0] == '.' || parts[0][0] == '_')
                continue; 

            if (parts.Count() > 2)
                CheckArguments.Run(parts[0], parts[1], parts[2], line);

            else if (parts.Count() == 2)
                CheckArguments.Run(parts[0], parts[1], null, line);

            else if (parts.Count() == 1)
                CheckArguments.Run(parts[0], null, null, line);

        }

    }

    private static void DisAssembly(){
        foreach (string line in codeParts.Values){
            if (parts == null) continue;
            Console.WriteLine($"0x{rnd.NextInt64(100000000000000, 999999999999999)}    {line}");
        }
    }
}