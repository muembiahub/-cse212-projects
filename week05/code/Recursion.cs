
using System;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Sum of squares using recursion.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Generate permutations of a given size.
    /// </summary>
    public static void PermutationsChoose(
        List<string> results,
        string letters,
        int size,
        string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        foreach (char letter in letters)
        {
            string remainingLetters = letters.Replace(letter.ToString(), "");

            PermutationsChoose(
                results,
                remainingLetters,
                size,
                word + letter);
        }
    }

    /// <summary>
    /// Problem 3: Count the ways to climb stairs using recursion
    /// and memoization.
    /// </summary>
    public static decimal CountWaysToClimb(
        int s,
        Dictionary<int, decimal>? remember = null)
    {
        if (s < 0)
            return 0;

        if (s == 0)
            return 1;

        if (s == 1)
            return 1;

        if (s == 2)
            return 2;

        if (s == 3)
            return 4;

        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (remember.ContainsKey(s))
            return remember[s];

        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        remember[s] = ways;

        return ways;
    }

    /// <summary>
    /// Problem 4: Generate all binary strings from a wildcard pattern.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        string patternZero =
            pattern[..index] + "0" + pattern[(index + 1)..];

        WildcardBinary(patternZero, results);

        string patternOne =
            pattern[..index] + "1" + pattern[(index + 1)..];

        WildcardBinary(patternOne, results);
    }

    /// <summary>
    /// Problem 5: Find all paths through the maze using recursion.
    /// </summary>
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize the current path.
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // Check whether the current position is valid.
        if (!maze.IsValidMove(currPath, x, y))
        {
            return;
        }

        // Add the current position to the path.
        currPath.Add((x, y));

        // Check whether we have reached the end.
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            // Explore the four possible directions.
            SolveMaze(results, maze, x + 1, y, currPath); // Right
            SolveMaze(results, maze, x - 1, y, currPath); // Left
            SolveMaze(results, maze, x, y + 1, currPath); // Down
            SolveMaze(results, maze, x, y - 1, currPath); // Up
        }

        // Backtrack to explore other possible paths.
        currPath.RemoveAt(currPath.Count - 1);
    }
}
