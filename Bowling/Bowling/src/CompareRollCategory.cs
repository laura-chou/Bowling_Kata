﻿using Bowling.src.Categories;
using System.Text;

namespace Bowling.src
{
    public class CompareRollCategory
    {
        private string rolls;

        public CompareRollCategory(string rolls)
        {
            this.rolls = rolls;
        }

        public Roll? GetRoll(int round)
        {
            if (round < rolls.Length)
            {
                return new Roll { Pins = GetPins(rolls[round].ToString()) };
            }
            return null;
        }

        private int GetPins(string roll)
        {
            var symbolMapper = new Dictionary<string, ICategory>
            {
                { "-", new GutterBall()},
                { "X", new Strike()},
                { "/", new Spare(rolls[0].ToString())}
            };
            ICategory category = symbolMapper.ContainsKey(roll) ? symbolMapper[roll] : new Normal(roll);
            return category.GetPins();
        }
    }
}