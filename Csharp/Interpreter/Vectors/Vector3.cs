using static Instructions;
class Vector3{
    public double X;
    public double Y;
    public double Z;

    public Vector3(double _X, double _Y, double _Z){
        X = _X;
        Y = _Y;
        Z = _Z;
    }

    public void Set(double value, Instructions operation, char cord){
        switch (operation){
            case _mov:{
                switch (cord){
                    case 'X': X = value; break;
                    case 'Y': Y = value; break;
                    case 'Z': Z = value; break;
                } break;
            }
            case _add:{
                switch (cord){
                    case 'X': X += value; break;
                    case 'Y': Y += value; break;
                    case 'Z': Z += value; break;
                } break;
            }
            case _sub:{
                switch (cord){
                    case 'X': X -= value; break;
                    case 'Y': X -= value; break;
                    case 'Z': Z -= value; break;
                } break;
            }
            case _mul:{
                switch (cord){
                    case 'X': X *= value; break;
                    case 'Y': Y *= value; break;
                    case 'Z': Z *= value; break;
                } break;
            }
            case _div:{
                switch (cord){
                    case 'X': X /= value; break;
                    case 'Y': Y /= value; break;
                    case 'Z': Z /= value; break;
                } break;
            }
        }
    }

    public string Print(){
        return $"X:{X} Y:{Y} Z:{Z}";
    }
}