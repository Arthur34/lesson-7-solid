using GuessTheNumberGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame.Classes
{
    public class StaticConfigProvider : IConfigProvider
    {
        public int GetGuessCount() => 3;
        public int GetMax() => 100;
        public int GetMin() => 0;
    }
}
