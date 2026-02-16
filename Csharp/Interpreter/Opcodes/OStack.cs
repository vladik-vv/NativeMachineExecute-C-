using static Executer;

struct OStack{ 

    public static void Execute(Instructions mode){ 
        switch (mode){
            case Instructions._pusha:{
                foreach (string key in Init.registres.Keys){
                    Init.stackRegistres[key] = Init.registres[key];
                }
                return;
            }
            case Instructions._push:{
                Init.stackRegistres[nameArg1] = Init.registres[nameArg1];
                return;
            }
            case Instructions._pop:{
                Init.registres[nameArg1] = Init.stackRegistres[nameArg1];
                return;
            }
            case Instructions._popa:{
                foreach (string key in Init.stackRegistres.Keys){
                    Init.registres[key] = Init.stackRegistres[key];
                }
                return;
            }
        }
    }
}

