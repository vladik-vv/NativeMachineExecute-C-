using static Parser;
using static Types;
using static Init;
using static Instructions;
using static Executer;

struct Change{ 

    public static void Execute(Instructions mode){   // математические инструкции

        switch (typeArg1){
            case _vector2x: vec2s[nameArg1].Set(doubleValue, mode, 'X'); break;
            case _vector2y: vec2s[nameArg1].Set(doubleValue, mode, 'Y'); break;
            case _vector3x: vec3s[nameArg1].Set(doubleValue, mode, 'X'); break;
            case _vector3y: vec3s[nameArg1].Set(doubleValue, mode, 'Y'); break;
            case _vector3z: vec3s[nameArg1].Set(doubleValue, mode, 'Z'); break;
            case _vector4x: vec4s[nameArg1].Set(doubleValue, mode, 'X'); break;
            case _vector4y: vec4s[nameArg1].Set(doubleValue, mode, 'Y'); break;
            case _vector4z: vec4s[nameArg1].Set(doubleValue, mode, 'Z'); break;
            case _vector4w: vec4s[nameArg1].Set(doubleValue, mode, 'W'); break;
        }

        int mx = matrix_x ?? 0;
        int my = matrix_y ?? 0;

        switch (mode){
            case _mov:{    // переместить
                switch (typeArg1){
                    case _registres: registres[nameArg1] = doubleValue; return;
                    case _byte: byteVars[nameArg1] = byteValue; return;
                    case _short: shortVars[nameArg1] = shortValue; return;
                    case _float: floatVars[nameArg1] = floatValue; return;
                    case _double: doubleVars[nameArg1] = doubleValue; return;
                    case _string: RAM -= stringVars[nameArg1].Length; stringVars[nameArg1] = value; RAM += value.Length; return;
                    case _byteARR: byteArrs[nameArg1][elementNumArg1 ?? 0] = byteValue; return;
                    case _shortARR: shortArrs[nameArg1][elementNumArg1 ?? 0] = shortValue; return;
                    case _floatARR: floatArrs[nameArg1][elementNumArg1 ?? 0] = floatValue; return;
                    case _doubleARR: doubleArrs[nameArg1][elementNumArg1 ?? 0] = doubleValue; return;
                    case _stringARR: stringArrs[nameArg1][elementNumArg1 ?? 0] = value; return;
                    case _stringMatrix2: Matrix2_s[nameArg1][my, mx] = value; return;
                    case _doubleMatrix2: Matrix2_q[nameArg1][my, mx] = doubleValue; return;  
                } return;
            }

            case _add:{    // добавить
                switch (typeArg1){
                    case _registres: registres[nameArg1] += doubleValue; return;
                    case _byte: byteVars[nameArg1] += byteValue; return;
                    case _short: shortVars[nameArg1] += shortValue; return;
                    case _float: floatVars[nameArg1] += floatValue; return;
                    case _double: doubleVars[nameArg1] += doubleValue; return;
                    case _string: stringVars[nameArg1] += value; RAM += value.Length; return;
                    case _byteARR: byteArrs[nameArg1][elementNumArg1 ?? 0] += byteValue; return;
                    case _shortARR: shortArrs[nameArg1][elementNumArg1 ?? 0] += shortValue; return;
                    case _floatARR: floatArrs[nameArg1][elementNumArg1 ?? 0] += floatValue; return;
                    case _doubleARR: doubleArrs[nameArg1][elementNumArg1 ?? 0] += doubleValue; return;
                    case _stringARR: stringArrs[nameArg1][elementNumArg1 ?? 0] += value; return;
                    case _stringMatrix2: Matrix2_s[nameArg1][my, mx] += value; return;
                    case _doubleMatrix2: Matrix2_q[nameArg1][my, mx] += doubleValue; return;
                } return;
            }
            
            case _sub:{    // вычтать
                switch (typeArg1){
                    case _registres: registres[nameArg1] -= doubleValue; return;
                    case _byte: byteVars[nameArg1] -= byteValue; return;
                    case _short: shortVars[nameArg1] -= shortValue; return;
                    case _float: floatVars[nameArg1] -= floatValue; return;
                    case _double: doubleVars[nameArg1] -= doubleValue; return;
                    case _byteARR: byteArrs[nameArg1][elementNumArg1 ?? 0] -= byteValue; return;
                    case _shortARR: shortArrs[nameArg1][elementNumArg1 ?? 0] -= shortValue; return;
                    case _floatARR: floatArrs[nameArg1][elementNumArg1 ?? 0] -= floatValue; return;
                    case _doubleARR: doubleArrs[nameArg1][elementNumArg1 ?? 0] -= doubleValue; return;
                    case _string:
                    case _stringMatrix2:
                    case _stringARR: Errors.Print(0x08); return;
                    case _doubleMatrix2: Matrix2_q[nameArg1][my, mx] -= doubleValue; return;
                } return;
            }

            case _div:{    // поделить
                switch (typeArg1){
                    case _registres: registres["rnr"] = registres[nameArg1] % doubleValue; registres[nameArg1] /= doubleValue; return;
                    case _byte: registres["rnr"] = byteVars[nameArg1] % byteValue; byteVars[nameArg1] /= byteValue; return;
                    case _short: registres["rnr"] = shortVars[nameArg1] % shortValue; shortVars[nameArg1] /= shortValue; return;
                    case _float: registres["rnr"] = floatVars[nameArg1] % floatValue; floatVars[nameArg1] /= floatValue; return;
                    case _double: registres["rnr"] = doubleVars[nameArg1] % doubleValue; doubleVars[nameArg1] /= doubleValue; return;
                    case _byteARR: registres["rnr"] = byteArrs[nameArg1][elementNumArg1 ?? 0] % byteValue; byteArrs[nameArg1][elementNumArg1 ?? 0] /= byteValue; return;
                    case _shortARR: registres["rnr"] = shortArrs[nameArg1][elementNumArg1 ?? 0] % shortValue; shortArrs[nameArg1][elementNumArg1 ?? 0] /= shortValue; return;
                    case _floatARR: registres["rnr"] = floatArrs[nameArg1][elementNumArg1 ?? 0] % floatValue; floatArrs[nameArg1][elementNumArg1 ?? 0] /= floatValue; return;
                    case _doubleARR: registres["rnr"] = doubleArrs[nameArg1][elementNumArg1 ?? 0] % doubleValue; doubleArrs[nameArg1][elementNumArg1 ?? 0] /= doubleValue; return;
                    case _string:
                    case _stringMatrix2:
                    case _stringARR: Errors.Print(0x08); return;
                    case _doubleMatrix2: Matrix2_q[nameArg1][my, mx] /= doubleValue; return;
                } return;
            }
            
            case _mul:{    // умножить
                switch (typeArg1){
                    case _registres: registres[nameArg1] *= doubleValue; return;
                    case _byte: byteVars[nameArg1] *= byteValue; return;
                    case _short: shortVars[nameArg1] *= shortValue; return;
                    case _float: floatVars[nameArg1] *= floatValue; return;
                    case _double: doubleVars[nameArg1] *= doubleValue; return;
                    case _byteARR: byteArrs[nameArg1][elementNumArg1 ?? 0] *= byteValue; return;
                    case _shortARR: shortArrs[nameArg1][elementNumArg1 ?? 0] *= shortValue; return;
                    case _floatARR: floatArrs[nameArg1][elementNumArg1 ?? 0] *= floatValue; return;
                    case _doubleARR: doubleArrs[nameArg1][elementNumArg1 ?? 0] *= doubleValue; return;
                    case _string:
                    case _stringMatrix2: 
                    case _stringARR: Errors.Print(0x08); return;
                    case _doubleMatrix2: Matrix2_q[nameArg1][my, mx] *= doubleValue; return;
                } return;
            }

            case _cos:{ // косинус аргумента
                switch (typeArg1){
                    case _registres: registres[nameArg1] = System.Math.Cos(doubleValue); return;
                    case _byte: byteVars[nameArg1] = (byte)System.Math.Cos(byteValue); return;
                    case _short: shortVars[nameArg1] = (short)System.Math.Cos(shortValue); return;
                    case _float: floatVars[nameArg1] = (float)System.Math.Cos(floatValue); return;
                    case _double: doubleVars[nameArg1] = System.Math.Cos(doubleValue); return;
                    case _byteARR: byteArrs[nameArg1][elementNumArg1 ?? 0] = (byte)System.Math.Cos(byteValue); return;
                    case _shortARR: shortArrs[nameArg1][elementNumArg1 ?? 0] = (short)System.Math.Cos(shortValue); return;
                    case _floatARR: floatArrs[nameArg1][elementNumArg1 ?? 0] = (float)System.Math.Cos(floatValue); return;
                    case _doubleARR: doubleArrs[nameArg1][elementNumArg1 ?? 0] = System.Math.Cos(doubleValue); return;
                    case _string:
                    case _stringMatrix2: 
                    case _stringARR: Errors.Print(0x08); return;
                    case _doubleMatrix2: Matrix2_q[nameArg1][my, mx] = System.Math.Cos(doubleValue); return;
                } return;
            }

            case _sin:{ // синус аргумента
                switch (typeArg1){
                    case _registres: registres[nameArg1] = System.Math.Sin(doubleValue); return;
                    case _byte: byteVars[nameArg1] = (byte)System.Math.Sin(byteValue); return;
                    case _short: shortVars[nameArg1] = (short)System.Math.Sin(shortValue); return;
                    case _float: floatVars[nameArg1] = (float)System.Math.Sin(floatValue); return;
                    case _double: doubleVars[nameArg1] = System.Math.Sin(doubleValue); return;
                    case _byteARR: byteArrs[nameArg1][elementNumArg1 ?? 0] = (byte)System.Math.Sin(byteValue); return;
                    case _shortARR: shortArrs[nameArg1][elementNumArg1 ?? 0] = (short)System.Math.Sin(shortValue); return;
                    case _floatARR: floatArrs[nameArg1][elementNumArg1 ?? 0] = (float)System.Math.Sin(floatValue); return;
                    case _doubleARR: doubleArrs[nameArg1][elementNumArg1 ?? 0] = System.Math.Sin(doubleValue); return;
                    case _string:
                    case _stringMatrix2: 
                    case _stringARR: Errors.Print(0x08); return;
                    case _doubleMatrix2: Matrix2_q[nameArg1][my, mx] = System.Math.Sin(doubleValue); return;
                } return;
            }
            
            case _tan:{ // тангес аргумента
                switch (typeArg1){
                    case _registres: registres[nameArg1] = System.Math.Tan(doubleValue); return;
                    case _byte: byteVars[nameArg1] = (byte)System.Math.Tan(byteValue); return;
                    case _short: shortVars[nameArg1] = (short)System.Math.Tan(shortValue); return;
                    case _float: floatVars[nameArg1] = (float)System.Math.Tan(floatValue); return;
                    case _double: doubleVars[nameArg1] = System.Math.Tan(doubleValue); return;
                    case _byteARR: byteArrs[nameArg1][elementNumArg1 ?? 0] = (byte)System.Math.Tan(byteValue); return;
                    case _shortARR: shortArrs[nameArg1][elementNumArg1 ?? 0] = (short)System.Math.Tan(shortValue); return;
                    case _floatARR: floatArrs[nameArg1][elementNumArg1 ?? 0] = (float)System.Math.Tan(floatValue); return;
                    case _doubleARR: doubleArrs[nameArg1][elementNumArg1 ?? 0] = System.Math.Tan(doubleValue); return;
                    case _string:
                    case _stringMatrix2:
                    case _stringARR: Errors.Print(0x08); return;
                    case _doubleMatrix2: Matrix2_q[nameArg1][my, mx] = System.Math.Tan(doubleValue); return;
                } return;
            }

            case _min:
            case _max:{ // максимальный элемент массива
                double maxelementDouble = 0;
                string maxelementString = "";
                if (byteArrs.ContainsKey(value)){ if (mode == _max ) {maxelementDouble = byteArrs[value].Max();} if (mode == _min ) {maxelementDouble = byteArrs[value].Min();} }
                if (shortArrs.ContainsKey(value)){ if (mode == _max ) {maxelementDouble = shortArrs[value].Max();} if (mode == _min ) {maxelementDouble = shortArrs[value].Min();} }
                if (floatArrs.ContainsKey(value)){ if (mode == _max ) {maxelementDouble = floatArrs[value].Max();} if (mode == _min ) {maxelementDouble = floatArrs[value].Min();} }
                if (doubleArrs.ContainsKey(value)){ if (mode == _max ) {maxelementDouble = doubleArrs[value].Max();} if (mode == _min ) {maxelementDouble = doubleArrs[value].Min();} }
                if (stringArrs.ContainsKey(value)){ if (mode == _max ) {maxelementString = stringArrs[value].Max();} if (mode == _min ) {maxelementString = stringArrs[value].Min();} }
        
                switch (typeArg1){
                    case _registres: registres[nameArg1] = maxelementDouble; return;
                    case _byte: byteVars[nameArg1] = (byte)maxelementDouble; return;
                    case _short: shortVars[nameArg1] = (short)maxelementDouble; return;
                    case _float: floatVars[nameArg1] = (float)maxelementDouble; return;
                    case _double: doubleVars[nameArg1] = maxelementDouble; return;
                    case _byteARR: byteArrs[nameArg1][elementNumArg1 ?? 0] = (byte)maxelementDouble; return;
                    case _shortARR: shortArrs[nameArg1][elementNumArg1 ?? 0] = (short)maxelementDouble; return;
                    case _floatARR: floatArrs[nameArg1][elementNumArg1 ?? 0] = (float)maxelementDouble; return;
                    case _doubleARR: doubleArrs[nameArg1][elementNumArg1 ?? 0] = maxelementDouble; return;
                    case _string: stringVars[nameArg1] = maxelementString; return; 
                    case _stringARR: stringArrs[nameArg1][elementNumArg1 ?? 0] = maxelementString; return;
                } return;
            }

            case _rand:{
                double num1 = 0;
                switch (typeArg1){
                    case _registres: num1 = registres[nameArg1]; break;
                    case _byte: num1 = byteVars[nameArg1]; break;
                    case _short: num1 = shortVars[nameArg1]; break;
                    case _float: num1 = floatVars[nameArg1]; break;
                    case _double: num1 = doubleVars[nameArg1]; break;
                    case _byteARR: num1 = byteArrs[nameArg1][elementNumArg1 ?? 0]; break;
                    case _shortARR: num1 = shortArrs[nameArg1][elementNumArg1 ?? 0]; break;
                    case _floatARR: num1 = floatArrs[nameArg1][elementNumArg1 ?? 0]; break;
                    case _doubleARR: num1 = doubleArrs[nameArg1][elementNumArg1 ?? 0]; break;
                }

                registres["rnd"] = new Random().NextInt64(Convert.ToInt64(num1), Convert.ToInt64(value));
                return;
            }

            case _dst:{ // дистанция
                switch (typeArg1){
                    case _vector2: registres["rvc"] = (double)System.Math.Sqrt(System.Math.Pow(vec2s[nameArg1].X - vec2s[value].X, 2) + System.Math.Pow(vec2s[nameArg1].Y - vec2s[value].Y, 2)); return;
                    case _vector3: registres["rvc"]  = (double)System.Math.Sqrt(System.Math.Pow(vec3s[nameArg1].X - vec3s[value].X, 2) + System.Math.Pow(vec3s[nameArg1].Y - vec3s[value].Y, 2) + System.Math.Pow(vec3s[nameArg1].Z - vec3s[value].Z, 2)); return;
                    case _vector4: registres["rvc"]  = (double)System.Math.Sqrt(System.Math.Pow(vec4s[nameArg1].X - vec4s[value].X, 2) + System.Math.Pow(vec4s[nameArg1].Y - vec4s[value].Y, 2) + System.Math.Pow(vec4s[nameArg1].Z - vec4s[value].Z, 2) + System.Math.Pow(vec4s[nameArg1].W - vec4s[value].W, 2)); return;
                } return;
            }

            case _lngsq:
            case _lng:{ // длинна вектора
                double lengthVector = 0;
                    if (vec2s.ContainsKey(value)) {if (mode == _lng) lengthVector = System.Math.Sqrt(vec2s[value].X * vec2s[value].X + vec2s[value].Y * vec2s[value].Y); if (mode == _lngsq) lengthVector = vec2s[value].X * vec2s[value].X + vec2s[value].Y * vec2s[value].Y;}
                    if (vec3s.ContainsKey(value)) {if (mode == _lng) lengthVector = System.Math.Sqrt(vec3s[value].X * vec3s[value].X + vec3s[value].Y * vec3s[value].Y + vec3s[value].Z * vec3s[value].Z); if (mode == _lngsq) lengthVector = vec3s[value].X * vec3s[value].X + vec3s[value].Y * vec3s[value].Y + vec3s[value].Z * vec3s[value].Z;}
                    if (vec4s.ContainsKey(value)) {if (mode == _lng) lengthVector = System.Math.Sqrt(vec4s[value].X * vec4s[value].X + vec4s[value].Y * vec4s[value].Y + vec4s[value].Z * vec4s[value].Z + vec4s[value].W * vec4s[value].W); if (mode == _lngsq) lengthVector = vec4s[value].X * vec4s[value].X + vec4s[value].Y * vec4s[value].Y + vec4s[value].Z * vec4s[value].Z + vec4s[value].W * vec4s[value].W;}   
                switch (typeArg1){
                    case _registres: registres[nameArg1] = lengthVector; return;
                    case _byte: byteVars[nameArg1] = (byte)lengthVector; return;
                    case _short: shortVars[nameArg1] = (short)lengthVector; return;
                    case _float: floatVars[nameArg1] = (float)lengthVector; return;
                    case _double: doubleVars[nameArg1] = lengthVector; return;
                    case _byteARR: byteArrs[nameArg1][elementNumArg1 ?? 0] = (byte)lengthVector; return;
                    case _shortARR: shortArrs[nameArg1][elementNumArg1 ?? 0] = (short)lengthVector; return;
                    case _floatARR: floatArrs[nameArg1][elementNumArg1 ?? 0] = (float)lengthVector; return;
                    case _doubleARR: doubleArrs[nameArg1][elementNumArg1 ?? 0] = lengthVector; return;
                    case _string: stringVars[nameArg1] = lengthVector.ToString(); return;
                    case _stringARR: Errors.Print(0x08); stringArrs[nameArg1][elementNumArg1 ?? 0] = lengthVector.ToString(); return;
                }
                return;
            }

            case _len:{ // вычислить длину строку
                switch (typeArg1){
                    case _registres: registres[nameArg1] = value.Length; return;
                    case _byte: byteVars[nameArg1] = (byte)value.Length; return;
                    case _short: shortVars[nameArg1] = (short)value.Length; return;
                    case _float: floatVars[nameArg1] = (float)value.Length; return;
                    case _double: doubleVars[nameArg1] = value.Length; return;
                    case _byteARR: byteArrs[nameArg1][elementNumArg1 ?? 0] = (byte)value.Length; return;
                    case _shortARR: shortArrs[nameArg1][elementNumArg1 ?? 0] = (short)value.Length; return;
                    case _floatARR: floatArrs[nameArg1][elementNumArg1 ?? 0] = (float)value.Length; return;
                    case _doubleARR: doubleArrs[nameArg1][elementNumArg1 ?? 0] = value.Length; return;
                    case _string: stringVars[nameArg1] = value.Length.ToString(); return;
                    case _stringARR: Errors.Print(0x08); stringArrs[nameArg1][elementNumArg1 ?? 0] = value.Length.ToString(); return;
                } return;
            }

            case _inp:{
                string inp = Console.ReadLine() ?? "0";
                switch (typeArg1){
                    case _registres: registres[nameArg1] = Convert.ToDouble(inp); return;
                    case _byte: byteVars[nameArg1] = Convert.ToByte(inp); return;
                    case _short: shortVars[nameArg1] = Convert.ToInt16(inp); return;
                    case _float: floatVars[nameArg1] = Convert.ToSingle(inp); return;
                    case _double: doubleVars[nameArg1] = Convert.ToDouble(inp); return;
                    case _byteARR: byteArrs[nameArg1][elementNumArg1 ?? 0] = Convert.ToByte(inp); return;
                    case _shortARR: shortArrs[nameArg1][elementNumArg1 ?? 0] = Convert.ToInt16(inp); return;
                    case _floatARR: floatArrs[nameArg1][elementNumArg1 ?? 0] = Convert.ToInt32(inp); return;
                    case _doubleARR: doubleArrs[nameArg1][elementNumArg1 ?? 0] = Convert.ToDouble(inp); return;
                    case _string: stringVars[nameArg1] = inp; return;
                    case _stringARR: Errors.Print(0x08); stringArrs[nameArg1][elementNumArg1 ?? 0] = inp; return;
                    case _doubleMatrix2: Matrix2_q[nameArg1][my, mx] = Convert.ToDouble(inp); return;
                    case _stringMatrix2: Matrix2_s[nameArg1][my, mx] = inp; return;
                } return;
            }

            case _srt:{
                switch (typeArg1){
                    case _byteARR:{ byteArrs[nameArg1].Sort(); return; }
                    case _shortARR:{ shortArrs[nameArg1].Sort(); return; }
                    case _floatARR:{ floatArrs[nameArg1].Sort(); return; }
                    case _doubleARR:{ doubleArrs[nameArg1].Sort(); return; }
                    case _stringARR:{ stringArrs[nameArg1].Sort(); return; }
                } return;
            }
        }
    }
}
