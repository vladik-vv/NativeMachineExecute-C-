/// <summary>
/// Структура, которая хранит в себе методы проверки
/// </summary>
struct CheckPC{   
    public static void CheckRAM(){
        
        if (Init.RAM > Init.maxRAM){
            Console.Write($"\nRam overflow {Init.RAM}/{Init.maxRAM}\n");
            Console.ReadLine();
            Environment.Exit(404);
        }
    }

    public static bool CheckInput(string code, string[] input){
        try{
            Terminal.Path = input[1];
        } catch{
            Console.Write($"Error: Where a name file? Example - {code} file.nem\n");
            return false;
        }

        
        if (code != "new"){
            try {
                string temp = File.ReadAllText(Terminal.Path);
            } catch{
                Console.Write($"Error: File {Terminal.Path} is not exist!\n");
                return false;
            }
        }

        return true;
    }
}