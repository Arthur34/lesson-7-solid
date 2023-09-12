using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame.Interfaces
{
    /// <summary>
    /// Провайдер настроек
    /// </summary>
    public interface IConfigProvider
    {
        int GetMin();
        int GetMax();
        int GetGuessCount();
    }
}
