using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame.Interfaces
{
    public interface IReader
    {
        string Read();
        char ReadKey();
    }
}
