using static Parser;
using static Init;
using static System.Convert;
using static Types;
using static Executer;

struct CreateVar{ 
    public static void Execute(Types t_var){ // создание переменной

        nameVars.Add(nameArg1); // добавляем в список имен переменных

        switch (t_var){ // проверяем тип переменной и меняем
            case _byte:{ 
                byteVars.Add(nameArg1, ToByte(value)); 
                RAM++; 
                return;
            }
            case _short:{ 
                shortVars.Add(nameArg1, ToInt16(value)); 
                RAM += 2; 
                return;
            }
            case _float:{ 
                floatVars.Add(nameArg1, ToSingle(value)); 
                RAM += 4; 
                return;
            }
            case _double:{ 
                doubleVars.Add(nameArg1, ToDouble(value)); 
                RAM += 8; 
                return;
            }
            case _string:{ 
                stringVars.Add(nameArg1, value); 
                RAM += value.Length; 
                return;
            }
        }
    }
}