using static Parser;
using static Executer;

struct CreateMX2{ 

    public static void Execute(Types mode){ 

        int x = matrix_x ?? 0;
        int y = matrix_y ?? 0;

        if (mode == Types._stringMatrix2){
            Matrix2_s[nameArg1] = new string[y, x];
            for (int yy = 0; yy < Matrix2_s[nameArg1].GetLength(0); yy++){
                for (int xx = 0; xx < Matrix2_s[nameArg1].GetLength(1); xx++){
                    Matrix2_s[nameArg1][yy, xx] = " ";
                }
            }
            nameVars.Add(nameArg1);
            return;
        } else {
            Matrix2_q[nameArg1] = new double[y, x];
            for (int yy = 0; yy < Matrix2_q[nameArg1].GetLength(0); yy++){
                for (int xx = 0; xx < Matrix2_q[nameArg1].GetLength(1); xx++){
                    Matrix2_q[nameArg1][yy, xx] = 0;
                }
            }
            nameVars.Add(nameArg1);
            return;
        }
    }
}

