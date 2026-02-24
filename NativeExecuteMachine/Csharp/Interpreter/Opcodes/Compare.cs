using static Parser;
using static Init;
using static System.Convert;
using static Types;
using static Executer;


struct Compare{ 
    public static void Execute(){ // сравнение аргументов

        isEqual = false;
        isHigh = false;

        if (nameArg1 == value){
            isEqual = true;
            return;
        }

        switch (typeArg1){
            case _registres: isHigh = registres[nameArg1] > doubleValue; isEqual = registres[nameArg1] == doubleValue; return;
            case _byte: isHigh = byteVars[nameArg1] > byteValue; isEqual = byteVars[nameArg1] == byteValue; return;
            case _short: isHigh = shortVars[nameArg1] > shortValue; isEqual = shortVars[nameArg1] == shortValue; return;
            case _float: isHigh = floatVars[nameArg1] > floatValue; isEqual = floatVars[nameArg1] == floatValue; return;
            case _double: isHigh = doubleVars[nameArg1] > doubleValue; isEqual = doubleVars[nameArg1] == doubleValue; return;
            case _string: {
                int lengthStr = stringVars[nameArg1].Length;
                switch (currentType){
                    case _byte: isHigh = lengthStr > byteValue; isEqual = lengthStr == byteValue; return;
                    case _short: isHigh = lengthStr > shortValue; isEqual = lengthStr == shortValue; return;
                    case _float: isHigh = lengthStr > floatValue; isEqual = lengthStr == floatValue; return;
                    case _double: isHigh = lengthStr > doubleValue; isEqual = lengthStr == doubleValue; return;
                    case _string: isHigh = lengthStr > value.Length; isEqual = stringVars[nameArg1] == value; return;
                    default: isHigh = lengthStr > ToDouble(value); isEqual = lengthStr == ToDouble(value); return;
                } 
            }
            case _byteARR: isHigh = byteArrs[nameArg1][elementNumArg1 ?? 0] > byteValue; 
                           isEqual = byteArrs[nameArg1][elementNumArg1 ?? 0] == byteValue; return;
            case _shortARR: isHigh = shortArrs[nameArg1][elementNumArg1 ?? 0] > shortValue; 
                            isEqual = shortArrs[nameArg1][elementNumArg1 ?? 0] == shortValue; return;
            case _floatARR: isHigh = floatArrs[nameArg1][elementNumArg1 ?? 0] > floatValue; 
                            isEqual = floatArrs[nameArg1][elementNumArg1 ?? 0] == floatValue; return;
            case _doubleARR: isHigh = doubleArrs[nameArg1][elementNumArg1 ?? 0] > doubleValue;
                             isEqual = doubleArrs[nameArg1][elementNumArg1 ?? 0] == doubleValue; return;
            case _stringARR: {
                int lengthStr = stringArrs[nameArg1][elementNumArg1 ?? 0].Length;
                switch (currentType){
                    case _byte: isHigh = lengthStr > byteValue; isEqual = lengthStr == byteValue; return;
                    case _short: isHigh = lengthStr > shortValue; isEqual = lengthStr == shortValue; return;
                    case _float: isHigh = lengthStr > floatValue; isEqual = lengthStr == floatValue; return;
                    case _double: isHigh = lengthStr > doubleValue; isEqual = lengthStr == doubleValue; return;
                    case _string: isHigh = lengthStr > value.Length; isEqual = stringArrs[nameArg1][elementNumArg1 ?? 0] == value; return;
                    default: isHigh = lengthStr > ToDouble(value); isEqual = lengthStr == ToDouble(value); return;
                } 
            }
        }
    }
}