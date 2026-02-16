using static Parser;
using static Init;
using static Executer;

struct Clear{ 

    public static void Execute(){
        switch (nameArg1){
            case "registres":{
                ClearRegistres();
                break;
            }
            case "screen":{
                Console.Clear();
                break;
            }
            default:{
                nameVars.Remove(nameArg1);
                switch (typeArg1){
                    case Types._registres:{registres[nameArg1] = 0; break;}
                    case Types._string:{RAM -= stringVars[nameArg1].Length; stringVars.Remove(nameArg1); break;}
                    case Types._byte:{RAM -= 1; byteVars.Remove(nameArg1); break;}
                    case Types._short:{RAM -= 2; shortVars.Remove(nameArg1); break;}
                    case Types._float:{RAM -= 4; floatVars.Remove(nameArg1); break;}
                    case Types._double:{RAM -= 8; doubleVars.Remove(nameArg1); break;}
                    case Types._vector2:{RAM -= 8; vec2s.Remove(nameArg1); break;}
                    case Types._vector3:{RAM -= 12; vec3s.Remove(nameArg1); break;}
                    case Types._vector4:{RAM -= 16; vec4s.Remove(nameArg1); break;}
                    case Types._byteARR:{RAM -= byteArrs[nameArg1].Count(); byteArrs.Remove(nameArg1); break;}
                    case Types._shortARR:{RAM -= shortArrs[nameArg1].Count() * 2; shortArrs.Remove(nameArg1); break;}
                    case Types._floatARR:{RAM -= floatArrs[nameArg1].Count() * 4; floatArrs.Remove(nameArg1); break;}
                    case Types._doubleARR:{RAM -= doubleArrs[nameArg1].Count() * 8; doubleArrs.Remove(nameArg1); break;}
                    case Types._stringARR:{foreach(string str in stringArrs[nameArg1]){if (str == null) {RAM--;} else {RAM -= str.Length;}}; stringArrs.Remove(nameArg1); break;}
                } break;
            }
        }
    }
}


