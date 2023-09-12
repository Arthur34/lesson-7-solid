using GuessTheNumberGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame.Classes
{
    public class GuessTheNumberGame : IGame
    {
        private readonly IWriter _writer;
        private readonly IReader _reader;
        private readonly IRandomGen _random;

        protected int _min = 0, _max = 100, _maxGuessCount = 3;

        public GuessTheNumberGame(IWriter writer, IReader reader, IRandomGen random)
        {
            _writer = writer;
            _random = random;
            _reader = reader;
        }

        /// <summary>
        /// Точка входа.
        /// </summary>
        public void Start()
        {
            WriteStartMessage();        // приветствие
            ShowMainMenu();             // меню
            MainMenuProcess();
        }

        /// <summary>
        /// Взаимодействие в меню
        /// </summary>
        private void MainMenuProcess()
        {
            const string startkey = "S";
            const string aboutkey = "A";
            const string exitkey = "X";

            char key;

            do
            {
                _writer.Write("Your choice: ", false);
                key = _reader.ReadKey();

                switch (key.ToString().ToUpper())
                {
                    case startkey:
                        StartGame();
                        ShowMainMenu();
                        break;

                    case aboutkey:
                        ShowAbout();
                        ShowMainMenu();
                        break;

                    case exitkey:
                        break;
                }
            } while (key.ToString().ToUpper() != exitkey);

            _writer.WriteEmptyLine();
            _writer.Write("Good bye!", true);
        }

        private void StartGame()
        {
            const string exitkey = "X";

            int digit = GetRandomDigit();

            int guess;
            int guessCount = 0;
            string input;

            bool isExit, isValid;

            _writer.WriteEmptyLine();
            _writer.Write("The number is hidden. Try to guess!", true);
            _writer.Write($"Or enter '{exitkey}' to exit.", true);
            _writer.WriteEmptyLine();

            do
            {
                if (guessCount >= _maxGuessCount)
                {
                    // закончились попытки
                    _writer.Write($"Unfortunately, you have reached your limit of attempts. Correct answer: {digit}", true);
                    PressAnyKey();
                    return;
                }

                _writer.Write("Your number: ", false);
                input = _reader.Read();

                (isExit, isValid, guess) = CheckInput(input, exitkey);

                if (isExit)
                    return;

                if (!isValid)
                {
                    _writer.Write("It's not a number!", true);
                    continue;
                }

                guessCount++;

                if (guess == digit)
                {
                    ShowWinnerMessage(guessCount);
                    return;
                }
                else if (guess < digit)
                {
                    // число меньше, чем загаданное
                    _writer.Write("You guessed wrong. Your number is less than the hidden number.", true);
                    _writer.WriteEmptyLine();
                }
                else
                {
                    // число больше, чем загаданное
                    _writer.Write("You guessed wrong. Your number is greater than the hidden number.", true);
                    _writer.WriteEmptyLine();
                }
            } while (true);
        }

        /// <summary>
        /// Проверка ввода.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="exitsign"></param>
        /// <returns></returns>
        private static (bool exit, bool valid, int digit) CheckInput(string input, string exitsign)
        {
            if (input.ToLower() == exitsign.ToLower())
                return (true, true, 0);

            if (!int.TryParse(input, out int guess))
                return (false, false, 0);
            else
                return (false, true, guess);
        }

        protected virtual void WriteStartMessage()
        {
            _writer.WriteEmptyLine();
            _writer.Write("The game begins!", nl: true);
            _writer.WriteEmptyLine();
        }

        protected virtual void ShowAbout()
        {
            _writer.ClearScreen();
            _writer.Write("ABOUT THE GAME", true);
            _writer.WriteEmptyLine();

            _writer.Write("The game guesses a number, and you have to guess that number.", true);
            _writer.Write("If the attempt is incorrect, the game will tell you whether", true);
            _writer.Write("the entered number is greater or less than the guessed number.", true);
            _writer.Write("The fewer attempts, the better!", true);
            PressAnyKey();
        }

        protected virtual void ShowMainMenu()
        {
            _writer.ClearScreen();
            _writer.Write("MENU", nl: true);
            _writer.WriteEmptyLine();

            _writer.Write("S: Start the game", true);
            _writer.Write("A: About", true);
            _writer.Write("X: Exit", true);
            _writer.WriteEmptyLine();
        }

        protected virtual void ShowWinnerMessage(int count)
        {
            _writer.WriteEmptyLine();
            _writer.Write($"Yes, right! You guessed the number in {count} attempts", nl: true);
            PressAnyKey();
            _writer.WriteEmptyLine();
        }

        private int GetRandomDigit()
        {
            return _random.GetNext(_min, _max);
        }

        /// <summary>
        /// Нажмите любую клавишу...
        /// </summary>
        private void PressAnyKey()
        {
            _writer.WriteEmptyLine();
            _writer.Write("Press any key to continue... ");
            _reader.ReadKey();
        }
    }
}
