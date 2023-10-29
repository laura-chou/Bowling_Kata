namespace Bowling
{
    public interface ICategory
    {
        int Pins { get; }
        int GetPins(string roll);
    }
}