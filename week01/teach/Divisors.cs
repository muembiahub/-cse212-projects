public static class Divisors {
    /// <summary>
    /// Entry point for the Divisors class
    /// 
    /// </summary>
    public static void Run() {
        Console.WriteLine("Divisors");
        Console.WriteLine("Put a number in and get a list of all the divisors for that number excluding the number itself.");
        Console.WriteLine("====================== First Number ======================");
        Console.WriteLine("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        // Call the FindDivisors method and store the result in a list
        List<int> list = FindDivisors(number);
        Console.WriteLine("<List>{" + string.Join(", ", list) + "}");

        Console.WriteLine("====================== Second Number ======================");
        Console.WriteLine("Enter a number: ");
        int number2 = int.Parse(Console.ReadLine());

        // Call the FindDivisors method and store the result in a list
        List<int> list2 = FindDivisors(number2);
        Console.WriteLine("<List>{" + string.Join(", ", list2) + "}");

    }

    /// <summary>
    /// Create a list of all divisors for a number including 1
    /// and excluding the number itself. Modulo will be used
    /// to test divisibility.
    /// </summary>
    /// <param name="number">The number to find the divisors for</param>
    /// <returns>List of divisors</returns>
    private static List<int> FindDivisors(int number) {
        List<int> results = new();
        for (int i = 1; i < number; i++ ) {
            if (number % i == 0) {
                results.Add(i);
            }
        }

        return results;
    }
    
}