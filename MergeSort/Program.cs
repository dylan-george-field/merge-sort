internal class Program
{
    private static void Main(string[] args)
    {
        var listToSort = new int[] { 6, 5, 3, 3, 2, 1 };

        MergeSort(listToSort);

        foreach (var item in listToSort)
        {
            Console.WriteLine(item);
        }

        Console.ReadLine();
    }

    private static void MergeSort(int[] array)
    {
        int[] helper = new int[array.Length];

        MergeSort(array, helper, 0, array.Length - 1);
    }

    private static void MergeSort(int[] array, int[] helper, int low, int high)
    {
        if (low < high) // stop when when no more elements to divide
        {
            int middle = (low + high) / 2; // rounds down
            MergeSort(array, helper, low, middle); // sort left
            MergeSort(array, helper, middle + 1, high); // sort right
            Merge(array, helper, low, middle, high); // merge
        }
    }

    private static void Merge(int[] array, int[] helper, int low, int middle, int high)
    {
        /* copy both halves into the helper array */
        for (int i = low; i <= high; i++) {
            helper[i] = array[i];
        }

        int pointerLeft = low;
        int pointerRight = middle + 1;
        int current = low;

        /* iterate through the helper array. Compare the left and right half copying back
         * the smaller element from the two halves into the original array */
        while (pointerLeft <= middle && pointerRight <= high)
        {
            if (helper[pointerLeft] <= helper[pointerRight])
            {
                array[current] = helper[pointerLeft];
                pointerLeft++;
            } else
            {
                array[current] = helper[pointerRight];
                pointerRight++;
            }
            current++;
        }

        /* copy the rest of the left side of the array into the target array */
        int remaining = middle - pointerLeft;
        for (int i = 0; i <= remaining; i++)
        {
            array[current + i] = helper[pointerLeft + i];
        }
    } 
}
