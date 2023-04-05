namespace SortingLib;

public class ShellSort : ISortStrategy
{
    public void Sort(int[] arr)
    {
        if (arr is null)
        {
            throw new ArgumentNullException(nameof(arr));
        }

        for (int gap = arr.Length / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < arr.Length; i += 1)
            {
                // add a[i] to the elements that have
                // been gap sorted save a[i] in temp and
                // make a hole at position i
                int temp = arr[i];

                // shift earlier gap-sorted elements up until
                // the correct location for a[i] is found
                int j;
                for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                {
                    arr[j] = arr[j - gap];
                }
                    
                // put temp (the original a[i]) 
                // in its correct location
                arr[j] = temp;
            }
        }
    }
}