using static Types;
using static Instructions;
using static Parser;
using static System.Convert;

struct Executer{
    private static string opcode;
    public static Types? currentType;
    public static Types? typeArg1; // тип переменной
    public static int? elementNumArg1; // номер элемента массива  
    public static string? nameArg1; // имя переменной
    public static string value;  // готовое значение, которым изменяем
    public static byte byteValue; // ниже значения, которые уже конвертированы
    public static short shortValue;
    public static float floatValue;
    public static double doubleValue;
    public static bool isHigh;
    public static bool isEqual;
    public static string line;
    public static Dictionary<string, Action> opcodes = new Dictionary<string, Action>{
        {"mov", () => Change.Execute(_mov)},
        {"add", () => Change.Execute(_add)},
        {"sub", () => Change.Execute(_sub)},
        {"div", () => Change.Execute(_div)},
        {"mul", () => Change.Execute(_mul)},
        {"cos", () => Change.Execute(_cos)},
        {"sin", () => Change.Execute(_sin)},
        {"tan", () => Change.Execute(_tan)},
        {"inp", () => Change.Execute(_inp)},
        {"max", () => Change.Execute(_max)},
        {"min", () => Change.Execute(_min)},
        {"rand", () => Change.Execute(_rand)},
        {"dst", () => Change.Execute(_dst)},
        {"lng", () => Change.Execute(_lng)},
        {"lngsq", () => Change.Execute(_lngsq)},
        {"len", () => Change.Execute(_len)},
        {"srt", () => Change.Execute(_srt)},
        {"db", () => CreateVar.Execute(_byte)},
        {"dw", () => CreateVar.Execute(_short)},
        {"dd", () => CreateVar.Execute(_float)},
        {"dq", () => CreateVar.Execute(_double)},
        {"ds", () => CreateVar.Execute(_string)},
        {"arrb", () => CreateArr.Execute(_byteARR)},
        {"arrw", () => CreateArr.Execute(_shortARR)},
        {"arrd", () => CreateArr.Execute(_floatARR)},
        {"arrq", () => CreateArr.Execute(_doubleARR)},
        {"arrs", () => CreateArr.Execute(_stringARR)},
        {"out", () => Out.Execute()},
        {"go", () => GoTo.Execute(_go, value)},
        {"call", () => GoTo.Execute(_call, value)},
        {"ife", () => GoTo.ExecuteIF(_ife)},
        {"ifn", () => GoTo.ExecuteIF(_ifn)},
        {"ifh", () => GoTo.ExecuteIF(_ifh)},
        {"ifl", () => GoTo.ExecuteIF(_ifl)},
        {"ret", () => GoTo.Execute(_ret, value)},
        {"vec2", () => CreateVector.Execute(_vec2)},
        {"vec3", () => CreateVector.Execute(_vec3)},
        {"vec4", () => CreateVector.Execute(_vec4)}, 
        {"clear", () => Clear.Execute()},
        {"cmp", () => Compare.Execute()},
        {"tst_cmp_", () => Console.WriteLine($"IsHigh {isHigh}. IsEqual {isEqual}.")},
        {"tst_vars_", () => {foreach (string name in nameVars) {Console.Write($"{name} ");}}},
        {"wait", () => Thread.Sleep(Convert.ToInt32(value))},
        {"pop", () => OStack.Execute(_pop)},
        {"popa", () => OStack.Execute(_popa)},
        {"push", () => OStack.Execute(_push)},
        {"pusha", () => OStack.Execute(_pusha)},
        {"hlt", () => ExecuteHalt()},
        // matrix2 - массив 2д
        // matrix3 - массив 3д
        // matrix4 - массив 4д
    };
    
    public static void Start(string _instruction, Types? _currentType, Types? _typeArg1, int _elementNumArg1, string? _nameArg1,  string _value, string _line){
        opcode = _instruction;
        currentType = _currentType;
        typeArg1 = _typeArg1;
        elementNumArg1 = _elementNumArg1;
        nameArg1 = _nameArg1;
        value = _value;
        line = _line;
        
        CheckTypeAndConvertValue(); 
        CheckPC.CheckRAM();
        opcodes[opcode]();
    }

    static void CheckTypeAndConvertValue(){ // проверяем, какой тип у 1 аргумента и конвертируем в этот тип готовое значение (2 аргумент).
        if (opcode == "pusha" || opcode == "popa" || opcode == "pop" || opcode == "push" || opcode == "inp" || opcode == "clear" || opcode == "lng" || opcode == "lngsq" || opcode == "max" || opcode == "min" || opcode == "len" || opcode == "srt") 
            return;
            
        switch (typeArg1){
            case _registres:
            case _double:
            case _doubleARR:
            case _vector2x:
            case _vector2y:
            case _vector3x:
            case _vector3y:
            case _vector3z:
            case _vector4x:
            case _vector4y:
            case _vector4z:
            case _vector4w:{
                doubleValue = ToDouble(value); return;
            }
            case _byteARR:
            case _byte: byteValue = ToByte(value); return;
            case _shortARR:
            case _short: shortValue = ToInt16(value); return;
            case _floatARR:
            case _float: floatValue = ToSingle(value); return;
        }
    }

    static void ExecuteHalt(){ // перейти к блоку СТОП
        numberLine = blocks["__stop:"];
    }
}