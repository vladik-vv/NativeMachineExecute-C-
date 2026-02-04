using System.Runtime.CompilerServices;
using PC;

class Program
{

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    static void Main(){
        Computer.Start();
        Terminal.Start();
    }

}