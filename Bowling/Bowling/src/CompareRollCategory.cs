using Bowling.src.Categories;
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
                return new Roll { Pins = GetPins(rolls[round].ToString()), Category = GetCategory(rolls[round].ToString()) };
            }
            return null;
        }

        private Category GetCategory(string roll)
        {
            var symbolMapper = new Dictionary<string, Category>
            {
                { "-", Category.GutterBall},
                { "X", Category.Strike},
                { "/", Category.Spare}
            };
            return symbolMapper.ContainsKey(roll) ? symbolMapper[roll] : Category.Normal;
        }

        private int GetPins(string roll)
        {
            var categoryMapper = new Dictionary<Category, ICategory>
            {
                { Category.GutterBall, new GutterBall()},
                { Category.Strike, new Strike()},
                { Category.Spare, new Spare(rolls[0].ToString())},
                { Category.Normal, new Normal(roll)}
            };
            ICategory category = categoryMapper[GetCategory(roll)];
            return category.GetPins();
        }
    }
}