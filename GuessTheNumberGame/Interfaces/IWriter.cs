using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame.Interfaces
{
    public interface IWriter
    {
        void ClearScreen();
        void Write(string message, bool nl = false);
        void WriteEmptyLine();
    }
}
