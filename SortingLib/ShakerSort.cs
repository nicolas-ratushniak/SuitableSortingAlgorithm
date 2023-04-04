namespace SortingLib;

public class ShakerSort : ISortStrategy
{
    public void Sort(int[] arr)
    {
        if (arr is null)
        {
            throw new ArgumentNullException(nameof(arr));
        }

        int begin = 0;
        int end = arr.Length - 1;

        while (begin < end)
        {
            int newBegin = end;
            int newEnd = begin;

            for (int i = begin; i < end; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
                    newEnd = i;
                }
            }
            end = newEnd;

            for (int i = end; i > begin; i--)
            {
                if (arr[i] < arr[i - 1])
                {
                    (arr[i], arr[i - 1]) = (arr[i - 1], arr[i]);
                    newBegin = i;
                }
            }
            begin = newBegin;
        }
    }
}