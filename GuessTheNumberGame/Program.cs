using GuessTheNumberGame.Classes;
using GuessTheNumberGame.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        // экземпляр класса работы с консолью
        var consoleProvider = new ConsoleProvider();

        // экземпляр класса генератора случайных чисел
        var random = new SimpleRandomGen();

        // экземпляр класс с настройками игры
        var config = new UserConfigProvider(writer: consoleProvider, reader: consoleProvider);

        // создаем игру и запускаем
        IGame game = new GuessTheNumberConfigurable(writer: consoleProvider, reader: consoleProvider, randomgen: random, config: config);
        game.Start();
    }
}