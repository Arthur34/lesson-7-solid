using GuessTheNumberGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame.Classes
{
    public class ConsoleProvider : IWriter, IReader
    {
        /// <summary>
        /// Вывести строку в консоль.
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="nl">Символ новой строки в конце</param>
        public void Write(string message, bool nl = true)
        {
            Console.Write(message);
            if (nl)
                Console.WriteLine();
        }

        /// <summary>
        /// Вывод пустой строки.
        /// </summary>
        public void WriteEmptyLine() => Console.WriteLine();

        /// <summary>
        /// Очистка экрана.
        /// </summary>
        public void ClearScreen() => Console.Clear();

        /// <summary>
        /// Ввод строки.
        /// </summary>
        /// <returns></returns>
        public string Read() => Console.ReadLine();

        /// <summary>
        /// Ввод символа с клавиатуры.
        /// </summary>
        /// <returns></returns>
        public char ReadKey() => Console.ReadKey().KeyChar;
    }
}
