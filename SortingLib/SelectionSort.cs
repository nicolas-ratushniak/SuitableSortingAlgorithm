namespace SortingLib;

public class SelectionSort : ISortStrategy
{
    public void Sort(int[] arr)
    {
        if (arr is null)
        {
            throw new ArgumentNullException(nameof(arr));
        }

        for (int i = 0; i < arr.Length - 1; i++)
        {
            // Find the minimum element in unsorted array
            int min_idx = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[min_idx])
                {
                    min_idx = j;
                }
            }
            (arr[min_idx], arr[i]) = (arr[i], arr[min_idx]);
        }
    }
}