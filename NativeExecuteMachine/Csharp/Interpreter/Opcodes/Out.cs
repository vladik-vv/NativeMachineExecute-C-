using static Parser;
using static Executer;
using System.Text;

struct Out{ 

    static int xnum;
    static int ynum;
    public static void Execute(){ 
        
        if (nameVars.Contains(value)){
            ExecuteShowArr();
            return;
        }

        if (!int.TryParse(parts[^1], out xnum)){
            Errors.Print(0x02); 
            return;
        }

        Console.Write($"{value}");

        while (xnum > 0){
            Console.Write('\n');
            xnum--;
        }
    }

    public static void ExecuteShowArr(){ // если на вывод дается массив или матрица
        StringBuilder txt = new StringBuilder(10000);

        string n1 = parts[^1].Replace('*', ' ').Split()[1];

        if (Matrix2_s.ContainsKey(value) || Matrix2_q.ContainsKey(value)){
            string n2 = parts[^1].Replace('*', ' ').Split()[0];
            if (!int.TryParse(n2, out ynum)){
                Errors.Print(0x02); 
                return;
            }
        }
        
        if (!int.TryParse(n1, out xnum)){
            Errors.Print(0x02); 
            return;
        }

        if (byteArrs.ContainsKey(value)){
            int tempx = xnum;
            foreach (byte b in byteArrs[value]){
                xnum = tempx;
                txt.Append(b);
                while (xnum > 0){ txt.Append(' '); xnum--; }
            }
        } else if (shortArrs.ContainsKey(value)){
            int tempx = xnum;
            foreach (short s in shortArrs[value]){
                xnum = tempx;
                txt.Append(s);
                while (xnum > 0){ txt.Append(' '); xnum--; }
            }
        } else if (floatArrs.ContainsKey(value)){
            int tempx = xnum;
            foreach (float f in floatArrs[value]){
                xnum = tempx;
                txt.Append(f);
                while (xnum > 0){ txt.Append(' '); xnum--; }
            }
        } else if (doubleArrs.ContainsKey(value)){
            int tempx = xnum;
            foreach (double d in doubleArrs[value]){
                xnum = tempx;
                txt.Append(d);
                while (xnum > 0){ txt.Append(' '); xnum--; }
            }
        } else if (stringArrs.ContainsKey(value)){
            int tempx = xnum;
            foreach (string s in stringArrs[value]){
                xnum = tempx;
                txt.Append(s);
                while (xnum > 0){ txt.Append(' '); xnum--; }
            }
        } else if (Matrix2_q.ContainsKey(value)){
            int savexnum = xnum;
            int saveynum = ynum;
            for (int y = 0; y < Matrix2_q[value].GetLength(0); y++){
                for (int x = 0; x < Matrix2_q[value].GetLength(1); x++){
                    txt.Append(Matrix2_q[value][y, x]);
                    while (xnum > 0){ txt.Append(' '); xnum--; }
                    xnum = savexnum;
                } while (ynum > 0){ txt.Append('\n'); ynum--; } ynum = saveynum; 
            }
        } else if (Matrix2_s.ContainsKey(value)){
            int savexnum = xnum;
            int saveynum = ynum;
            for (int y = 0; y < Matrix2_s[value].GetLength(0); y++){
                for (int x = 0; x < Matrix2_s[value].GetLength(1); x++){
                    txt.Append(Matrix2_s[value][y, x]);
                    while (xnum > 0){ txt.Append(' '); xnum--; }
                    xnum = savexnum;
                } while (ynum > 0){ txt.Append('\n'); ynum--; } ynum = saveynum;
            }
        }

        Console.Write(txt);

    }
}

