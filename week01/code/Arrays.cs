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

        /*
        Come up with a plan on how to implement the MultiplesOf function. 
        The function should create and return an array of multiples of a number.
         The starting number and the number of multiples are provided as inputs to the function.
         For example, MultiplesOf(3,5),
         where the 3 is the starting number and 5 is the number of multiples, would result in <double>{3, 6, 9, 12, 15}.
        */
         
        int i = 0;
        double[] multiples = new double[length];
        while (i < length)
        {
            
            multiples[i] = number * (i + 1);
            i++;
        }

        return multiples;
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
       /*
       here is a plan to implement the RotateListRight function:
        1. Create a new list to hold the rotated values.
        2. Calculate the starting index for the rotation by subtracting the amount from the length of the data list.
        3. Loop through the data list starting from the calculated index and add each element to the new list.
        4. After reaching the end of the data list, continue looping from the beginning of the data list until all elements have been added to the new list.
        5. Clear the original data list and add all elements from the new list back into it.
       */
       
        List<int> rotated = new List<int>(data.Count);
        int startIndex = data.Count - amount;

        for (int i = startIndex; i < data.Count; i++)
        {
            rotated.Add(data[i]);
        }

        for (int i = 0; i < startIndex; i++)
        {
            rotated.Add(data[i]);
        }

        data.Clear();
        data.AddRange(rotated);
    }
}
