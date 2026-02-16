/// <summary>
/// Точка входа в компьютер
/// </summary>
struct Program
{
    static void Main(){
        Init.StartInit();   // Запускаем инициализатор компьютера, инициализируя регистры, оперативку..
        Terminal.StartTerminal();   // Запускаем терминал, сердце программы.
    }
}