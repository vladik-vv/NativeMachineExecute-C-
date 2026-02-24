/// <summary>
/// Точка входа в компьютер
/// </summary>
struct Program
{
    static int Main(){
        Init.StartInit();   // Запускаем инициализатор компьютера, инициализируя регистры, оперативку..
        Terminal.StartTerminal();   // Запускаем терминал, сердце программы.
        return 0;
    }
}