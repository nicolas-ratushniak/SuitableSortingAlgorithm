namespace SortingLib;

public class MergeSort : ISortStrategy
{
    public void Sort(int[] arr)
    {
        if (arr is null)
        {
            throw new ArgumentNullException(nameof(arr));
        }
        SortArrayPart(arr, 0, arr.Length - 1);
    }

    private void SortArrayPart(int[] arr, int start, int end)
    {
        if (start < end)
        {
            int middle = start + (end - start) / 2; ;

            // Sort first and second halves
            SortArrayPart(arr, start, middle);
            SortArrayPart(arr, middle + 1, end);

            // Merge the sorted halves
            MergeParts(arr, start, middle, end);
        }
    }

    private void MergeParts(int[] arr, int start, int middle, int end)
    {
        int[] sorted = new int[end - start + 1];

        int numIndex = 0;
        int leftPartIndex = start;
        int rigthPartIndex = middle + 1;

        while (leftPartIndex <= middle && rigthPartIndex <= end)
        {
            if (arr[leftPartIndex] < arr[rigthPartIndex])
            {
                sorted[numIndex++] = arr[leftPartIndex++];
            }
            else
            {
                sorted[numIndex++] = arr[rigthPartIndex++];
            }
        }

        while (leftPartIndex <= middle)
        {
            sorted[numIndex++] = arr[leftPartIndex++];
        }

        while (rigthPartIndex <= end)
        {
            sorted[numIndex++] = arr[rigthPartIndex++];
        }

        for (int i = 0; i < sorted.Length; i++)
        {
            arr[start + i] = sorted[i];
        }
    }
}