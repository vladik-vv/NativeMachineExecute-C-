using static Instructions;
class Vector4{
    public double X;
    public double Y;
    public double Z;
    public double W;

    public Vector4(double _X, double _Y, double _Z, double _W){
        X = _X;
        Y = _Y;
        Z = _Z;
        W = _W;
    }

    public void Set(double value, Instructions operation, char cord){
        switch (operation){
            case _mov:{
                switch (cord){
                    case 'X': X = value; break;
                    case 'Y': Y = value; break;
                    case 'Z': Z = value; break;
                    case 'W': W = value; break;
                } break;
            }
            case _add:{
                switch (cord){
                    case 'X': X += value; break;
                    case 'Y': Y += value; break;
                    case 'Z': Z += value; break;
                    case 'W': W += value; break;
                } break;
            }
            case _sub:{
                switch (cord){
                    case 'X': X -= value; break;
                    case 'Y': Y -= value; break;
                    case 'Z': Z -= value; break;
                    case 'W': W -= value; break;
                } break;
            }
            case _mul:{
                switch (cord){
                    case 'X': X *= value; break;
                    case 'Y': Y *= value; break;
                    case 'Z': Z *= value; break;
                    case 'W': W *= value; break;
                } break;
            }
            case _div:{
                switch (cord){
                    case 'X': X /= value; break;
                    case 'Y': Y /= value; break;
                    case 'Z': Z /= value; break;
                    case 'W': W /= value; break;
                } break;
            }
        }
    }

    public string Print(){
        return $"X:{X} Y:{Y} Z:{Z} W:{W}";
    }
}
