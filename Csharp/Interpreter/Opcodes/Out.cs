using static Parser;

struct Out{ 

    static int num;
    public static void Execute(){ 
        
        if (!int.TryParse(parts[^1], out num)){
            Errors.Print(0x02); 
            return;
        }

        Console.Write($"{Executer.value}");

        while (num > 0){
            Console.Write('\n');
            num--;
        }
    }
}

