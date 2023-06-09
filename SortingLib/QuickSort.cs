﻿namespace SortingLib;

public class QuickSort : ISortStrategy
{
    public void Sort(int[] arr)
    {
        if (arr is null)
        {
            throw new ArgumentNullException(nameof(arr));
        }
        QuickSortArray(arr, 0, arr.Length - 1);
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = (low - 1);

        for (int j = low; j <= high - 1; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }
        (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
        return (i + 1);
    }

    private void QuickSortArray(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivot = Partition(arr, low, high);

            QuickSortArray(arr, low, pivot - 1);
            QuickSortArray(arr, pivot + 1, high);
        }
    } 
}