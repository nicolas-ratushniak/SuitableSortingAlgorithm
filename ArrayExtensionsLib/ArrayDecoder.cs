using System.Text;

namespace ArrayExtensionsLib;

public static class ArrayDecoder
{
    public static string ArrayToString(int[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        StringBuilder sb = new();

        for (int i = 0; i < array.Length; i++)
        {
            sb.Append(array[i]);

            if (i < array.Length - 1)
            {
                sb.Append(' ');
            }
        }
        return sb.ToString();
    }

    public static bool TryParseArray(string input, out int[]? array)
    {
        array = null;

        string[] elems = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (elems.Length == 0)
        {
            return false;
        }

        for (int i = 0; i < elems.Length; i++)
        {
            if (array is null)
            {
                array = new int[elems.Length];
            }
            if (!int.TryParse(elems[i], out array[i]))
            {
                return false;
            }
        }
        return true;
    }
}