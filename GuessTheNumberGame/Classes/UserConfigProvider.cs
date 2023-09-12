using GuessTheNumberGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame.Classes
{
    public class UserConfigProvider : IConfigProvider
    {
        private readonly IWriter _writer;
        private readonly IReader _reader;

        public UserConfigProvider(IWriter writer, IReader reader)
        {
            _writer = writer;
            _reader = reader;
        }

        public int GetGuessCount()
        {
            // число попыток
            _writer.Write("Enter the maximum number of attempts: ");
            return (int.TryParse(_reader.Read(), out int input)) ? input : 3;
        }

        public int GetMax()
        {
            // максимально загадываемое число
            _writer.Write("Enter the maximum guessable number: ");
            return (int.TryParse(_reader.Read(), out int input)) ? input : 100;
        }

        public int GetMin()
        {
            // минимально загадываемое число
            _writer.Write("Enter the minimum guessable number: ");
            return (int.TryParse(_reader.Read(), out int input)) ? input : 0;
        }
    }
}
