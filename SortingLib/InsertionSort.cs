namespace SortingLib;

public class InsertionSort : ISortStrategy
{
    public void Sort(int[] arr)
    {
        if (arr is null)
        {
            throw new ArgumentNullException(nameof(arr));
        }

        for (int i = 0; i < arr.Length; i++)
        {
            int key = arr[i];
            int comparerIndex = i - 1;

            while (comparerIndex >= 0 && arr[comparerIndex] > key)
            {
                arr[comparerIndex + 1] = arr[comparerIndex];
                comparerIndex--;
            }
            arr[comparerIndex + 1] = key;
        }
    }
}