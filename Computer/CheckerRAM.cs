using static Computer;

static class CheckerRam{   
    public static void CheckRAM(){
        
        if (RAM > maxRAM){
            Console.WriteLine("RAM IS FULL");
            Environment.Exit(404);
        }
    }
}