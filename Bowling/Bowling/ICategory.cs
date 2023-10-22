namespace Bowling
{
    public interface ICategory
    {
        string Symbol { get;}
        int Pins { get; }
        int GetPins(string roll);
    }
}