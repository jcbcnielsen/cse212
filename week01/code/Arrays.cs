public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // create an array of doubles of length length
        double[] result = new double[length];

        // iterate through each multiple of number up to the length
        for (int i = 1; i <= length; i++)
        {
            //calculate the multiple and add it to the array
            result[i - 1] = number * i;
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // record the original size of the List
        int size = data.Count;

        // append the number of elements equal to amount from the end of the list onto the list
        data.AddRange(data.GetRange(size - amount, amount));

        // append the number of elements equal to amount from the start of the list onto the list
        data.AddRange(data.GetRange(0, size - amount));

        // remove the original elements of the list from the list, leaving the re-appended elements
        data.RemoveRange(0, size);
    }
}
