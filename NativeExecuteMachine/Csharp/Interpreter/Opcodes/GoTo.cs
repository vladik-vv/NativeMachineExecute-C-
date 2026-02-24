using static Parser;
using static Instructions;
using static Executer;

struct GoTo{ 
    public static void Execute(Instructions mode, string point){ // прыгнуть на метку

        switch (mode){
            case _go:{ // безоговорочно перейти
                numberLine = blocks[$"{point}:"];
                return;
            }
            case _call:{ // вызвать, но сохранить адрес линии в стеке
                stackAddress.Add(numberLine);
                numberLine = blocks[$"{point}:"];
                return;
            }
            case _ret:{ // вернуться на тот адрес линии в стеке, или при отсутствии перейти на блок СТОП
                try {
                    numberLine = stackAddress.Last();
                } catch {
                    numberLine = blocks["__stop:"];
                    return;
                }
                stackAddress.Remove(stackAddress.Last());
                return;
            }
        }
    }

    public static void ExecuteIF(Instructions mode){ // если вызов идет с условием
        switch (mode){
            case _ife:{
                if (isEqual) {
                    if (nameArg1 == "go") Execute(_go, value);
                    else if (nameArg1 == "call") Execute(_call, value);
                } break;
            }
            case _ifn:{
                if (!isEqual){
                    if (nameArg1 == "go") Execute(_go, value);
                    else if (nameArg1 == "call") Execute(_call, value);
                } break;
            }
            case _ifh:{
                if (isHigh){
                    if (nameArg1 == "go") Execute(_go, value);
                    else if (nameArg1 == "call") Execute(_call, value);
                } break;
            }
            case _ifl:{
                if (!isHigh){
                    if (nameArg1 == "go") Execute(_go, value);
                    else if (nameArg1 == "call") Execute(_call, value);
                } break;
            }
        }
    }
}