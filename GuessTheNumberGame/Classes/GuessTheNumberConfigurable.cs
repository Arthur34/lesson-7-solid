using GuessTheNumberGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame.Classes
{
    public class GuessTheNumberConfigurable : GuessTheNumberGame
    {
        private readonly IConfigProvider _config;

        public GuessTheNumberConfigurable(IWriter writer, IReader reader, IRandomGen randomgen, IConfigProvider config)
            : base(writer, reader, randomgen)
        {
            _config = config;
            Setup();
        }

        protected void Setup()
        {
            _min = _config.GetMin();
            _max = _config.GetMax();

            if (_min > _max)
                _min = _max;

            _maxGuessCount = _config.GetGuessCount();

            if (_maxGuessCount <= 0)
                _maxGuessCount = 1;
        }
    }
}
