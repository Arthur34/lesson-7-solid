using GuessTheNumberGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame.Classes
{
    /// <summary>
    /// Генератор случайных чисел.
    /// </summary>
    public class SimpleRandomGen : IRandomGen
    {
        public int GetNext(int min, int max) => new Random().Next(min, max);
    }
}
