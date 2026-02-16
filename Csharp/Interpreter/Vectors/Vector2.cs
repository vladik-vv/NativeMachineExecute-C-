using static Instructions;
class Vector2{
    public double X;
    public double Y;

    public Vector2(double _X, double _Y){
        X = _X;
        Y = _Y;
    }

    public void Set(double value, Instructions operation, char cord){
        switch (operation){
            case _mov:{
                switch (cord){
                    case 'X': X = value; break;
                    case 'Y': Y = value; break;
                } break;
            }
            case _add:{
                switch (cord){
                    case 'X': X += value; break;
                    case 'Y': Y += value; break;
                } break;
            }
            case _sub:{
                switch (cord){
                    case 'X': X -= value; break;
                    case 'Y': X -= value; break;
                } break;
            }
            case _mul:{
                switch (cord){
                    case 'X': X *= value; break;
                    case 'Y': Y *= value; break;
                } break;
            }
            case _div:{
                switch (cord){
                    case 'X': X /= value; break;
                    case 'Y': Y /= value; break;
                } break;
            }
        }
    }

    public string Print(){
        return $"X:{X} Y:{Y}";
    }
}