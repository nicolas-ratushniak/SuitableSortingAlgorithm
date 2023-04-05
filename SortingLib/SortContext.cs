namespace SortingLib;

public class SortContext
{
    private ISortStrategy _strategy;

    public SortContext() { }

    public SortContext(ISortStrategy strategy)
    {
        _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
    }

    public void SetStrategy(ISortStrategy strategy)
    {
        _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
    }

    public void Sort(int[] arr)
    {
        if (_strategy is null)
        {
            throw new InvalidOperationException("None of sort stratagies was chosen.");
        }
        _strategy.Sort(arr);
    }
}