namespace Bowling
{
    public class BaseMethod
    {
        public bool HaveThisRoll(Roll? roll)
        {
            return roll != null;
        }
        public bool IsLastRolls(int index)
        {
            return index + 1 == 10;
        }
    }
}