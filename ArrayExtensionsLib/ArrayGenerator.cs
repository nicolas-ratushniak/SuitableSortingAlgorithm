namespace ArrayExtensionsLib;

public class ArrayGenerator
{
    private readonly Random _rand = new();

    public void PopulateRandomly(int[] array, int min, int max)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = _rand.Next(min, max + 1);
        }
    }
}
