using System;
using System.Collections.Generic;

class TwoSumProblem
{
    public static int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> numIndexMap = new Dictionary<int, int>();
        
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            
            if (numIndexMap.ContainsKey(complement))
            {
                return new int[] { numIndexMap[complement], i };
            }
            
            numIndexMap[nums[i]] = i;
        }
        
        throw new ArgumentException("No two sum solution");
    }

    public static void Main()
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;
        
        int[] result = TwoSum(nums, target);
        Console.WriteLine("Indices: [" + result[0] + ", " + result[1] + "]");
    }
}
