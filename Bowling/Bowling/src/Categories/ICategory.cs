namespace Bowling.src.Categories
{
    public interface ICategory
    {
        int Pins { get; }
        int GetPins(string roll);
    }
}