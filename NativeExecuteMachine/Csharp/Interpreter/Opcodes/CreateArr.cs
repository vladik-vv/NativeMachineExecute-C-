using static Parser;
using static Init;
using static System.Convert;
using static Types;
using static Executer;

struct CreateArr{ 
    public static void Execute(Types t_var){ // создание переменной

        int num = ToInt32(value) - 1;
        nameVars.Add(nameArg1); // добавляем в список имен переменных
        switch (t_var){
            case _byteARR:{
                byteArrs.Add(nameArg1, new byte[num + 1]);
                RAM += num + 1;
                while (num > 0){
                    byteArrs[nameArg1][num] = 0;
                    num--;
                }
                break;
            }
            case _shortARR:{
                shortArrs.Add(nameArg1, new short[num + 1]);
                RAM += (num + 1) * 2;
                while (num > 0){
                    shortArrs[nameArg1][num] = 0;
                    num--;
                }
                break;
            }
            case _floatARR:{
                floatArrs.Add(nameArg1, new float[num + 1]);
                RAM += (num + 1) * 4;
                while (num > 0){
                    floatArrs[nameArg1][num] = 0;
                    num--;
                }
                break;
            }
            case _doubleARR:{
                doubleArrs.Add(nameArg1, new double[num + 1]);
                RAM += (num + 1) * 8;
                while (num > 0){
                    doubleArrs[nameArg1][num] = 0;
                    num--;
                }
                break;
            }
            case _stringARR:{
                stringArrs.Add(nameArg1, new string[num + 1]);
                RAM += num + 1;
                while (num > 0){
                    stringArrs[nameArg1][num] = "";
                    num--;
                }
                break;
            }
        }
    }
}
