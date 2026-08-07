public class SubsequenceOperations : ISubsequenceOperations
{
    /*
    0 1 2 3 4 5 6
    6 2 4 3 1 5 9 
    1 1 2 1 1 2 3

    largest = 3
    lastindex = 6 startIndex = lastIndex-largest+1 = 4

    */
    public List<int> FindLongestIncreasingSubsequence(string sequence)
    {
        List<int> numbers = sequence.Split(' ').Select(int.Parse).ToList();
        List<int> longestIncreasingSubsequence = new List<int>();
        int[] lengthOfIncSubsequnce = new int[numbers.Count];
        int maxLength = 1;
        int lastIndex = 0;

        for (int ind = 0; ind < numbers.Count; ind++)
        {
            if (ind == 0 || numbers[ind] <= numbers[ind - 1])
            {
                lengthOfIncSubsequnce[ind] = 1;
            }
            else
            {
                lengthOfIncSubsequnce[ind] = lengthOfIncSubsequnce[ind - 1] + 1;
            }

            if (lengthOfIncSubsequnce[ind] > maxLength)
            {
                maxLength = lengthOfIncSubsequnce[ind];
                lastIndex = ind;
            }
        }

        int startIndex = lastIndex - maxLength + 1;

        for (int ind = startIndex; ind <= lastIndex; ind++)
        {
            longestIncreasingSubsequence.Add(numbers[ind]);
        }

        return longestIncreasingSubsequence;
    }
}