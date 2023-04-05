namespace SortingLib;

public class StoogeSort : ISortStrategy
{
    public void Sort(int[] arr)
    {
        if (arr is null)
        {
            throw new ArgumentNullException(nameof(arr));
        }

        StoogeSortArray(arr, 0, arr.Length - 1);
    }

    private void StoogeSortArray(int[] arr, int low, int high)
    {
        if (low >= high)
            return;

        if (arr[low] > arr[high])
        {
            (arr[low], arr[high]) = (arr[high], arr[low]);
        }

        if (high - low + 1 > 2)
        {
            int oneThird = (high - low + 1) / 3;

            StoogeSortArray(arr, low, high - oneThird);
            StoogeSortArray(arr, low + oneThird, high);
            StoogeSortArray(arr, low, high - oneThird);
        }
    }
}