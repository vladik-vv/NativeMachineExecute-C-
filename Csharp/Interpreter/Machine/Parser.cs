using System.Text;

struct Parser
{   
    public const string systemKey = "keyboard.key";
    public static Random rnd = new Random();
    public static int? stackAddress; // стэк для запоминания адреса
    public static string[] systemArguments = ["0", "0"]; // one, two.
    public static string[] parts = []; // список в котором будут части линии инструкций
    public static int numberLine = 0; // номер текущей строки
    public static Dictionary<int, string> codeParts = new Dictionary<int, string>();
    // библиотека в которой хранится ключ: адрес и значение это линия кода.
    public static Dictionary<string, int> blocks = new Dictionary<string, int>();
    // библиотека в которой хранятся адреса блоков
    public static bool isWarn; // закончилась ли программа с ошибкой

    public static List<string> nameVars = new List<string>();
    public static Dictionary<string, byte> byteVars = new Dictionary<string, byte>();
    public static Dictionary<string, short> shortVars = new Dictionary<string, short>();
    public static Dictionary<string, float> floatVars = new Dictionary<string, float>();
    public static Dictionary<string, double> doubleVars = new Dictionary<string, double>();
    public static Dictionary<string, string> stringVars = new Dictionary<string, string>();
    public static Dictionary<string, byte[]> byteArrs = new Dictionary<string, byte[]>();
    public static Dictionary<string, short[]> shortArrs = new Dictionary<string, short[]>();
    public static Dictionary<string, float[]> floatArrs = new Dictionary<string, float[]>();
    public static Dictionary<string, double[]> doubleArrs = new Dictionary<string, double[]>();
    public static Dictionary<string, string[]> stringArrs = new Dictionary<string, string[]>();
    public static Dictionary<string, Vector2> vec2s = new Dictionary<string, Vector2>();
    public static Dictionary<string, Vector3> vec3s = new Dictionary<string, Vector3>();
    public static Dictionary<string, Vector4> vec4s = new Dictionary<string, Vector4>();

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
        isWarn = false;
        numberLine = 0;
        stackAddress = -1;
        vec2s.Clear();
        vec3s.Clear();
        vec4s.Clear();
        nameVars.Clear();
        byteVars.Clear();
        shortVars.Clear();
        floatVars.Clear();
        doubleVars.Clear();
        stringVars.Clear();
        byteArrs.Clear();
        shortArrs.Clear();
        floatArrs.Clear();
        doubleArrs.Clear();
        stringArrs.Clear();
        blocks.Clear();
        codeParts.Clear();
    }


    private static void FillCodeParts(){    // заполняем части кода
        string[] lines = File.ReadAllLines(Terminal.Path);

        foreach (string line in lines){

            try {char temp = line.Trim(' ')[1];} catch {continue;}

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

    private static void Interpetation(){    // проходимся по каждой линии
        try {
            numberLine = blocks["__start:"];

            while (numberLine < codeParts.Count()){
                
                CheckPC.CheckRAM();
                if (isWarn) return;
                string line = codeParts[numberLine];
                numberLine++;

                parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries); 

                try { parts[0] = parts[0]; } catch { continue; }

                if (parts[0][0] == '.' || parts[0][0] == '_' || parts[0][0] == ';') continue; 

                if (parts.Count() > 2)
                    CheckArguments.Run(parts[0], parts[1], parts[2], line);

                else if (parts.Count() == 2)
                    CheckArguments.Run(parts[0], parts[1], null, line);

                else if (parts.Count() == 1)
                    CheckArguments.Run(parts[0], null, null, line);

            }
        } catch {
            Console.Clear();
            Console.WriteLine($"Unhandled error! LineCode: < {codeParts[numberLine - 1]} >");
            return;
        }

    }

    private static void DisAssembly(){      // диз-ассемблирование кода (инструкция заменяется на хекс код)
        StringBuilder txt = new StringBuilder();
        foreach (string line in codeParts.Values){
            txt.Append($"0x{rnd.NextInt64(100000000000000, 999999999999999)}    ");
            int countChars = 30;
            byte count = 0;
            foreach (char b in Convert.ToHexString(Encoding.ASCII.GetBytes(line.Split()[0]))){
                if (count == 2) {txt.Append(" "); count = 0; countChars--;}
                txt.Append(b);
                countChars--;
                count++;
            }
            for (int i = 0; i < countChars; i++){
                txt.Append(" ");
            }
            foreach (string part in line.Split()){
                if (part != line.Split()[0]){
                    txt.Append(part + " ");
                }
            }
            txt.Append("\n");
        }
        Console.Write(txt);
    }
}