namespace SortingLib;

public class SortContext
{
    private ISortStrategy _strategy;

    public SortContext(ISortStrategy strategy)
    {
        _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
    }

    public void ChangeStrategy(ISortStrategy strategy)
    {
        _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
    }

    public void Sort(int[] arr)
    {
        _strategy.Sort(arr);
    }
}