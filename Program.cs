/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length == 0)
                    return 0;

                int uniqueCount = 1; // Initialize unique element count

                for (int current = 1; current < nums.Length; current++)
                {
                    // If the current element is different from the previous one, increment uniqueCount
                    if (nums[current] != nums[current - 1])
                    {
                        nums[uniqueCount] = nums[current]; // Move the unique element to its correct position
                        uniqueCount++; // Increment unique element count
                    }
                }

                return uniqueCount; // Return the count of unique elements
            }
            catch (Exception)
            {
                throw; // Re-throw the exception
            }
        }

        /*
         * Self-analysis:
         
        a)   The code successfully eliminates duplicates from an integer array that has been sorted in-place while preserving the elements' relative order. 
        b)   It employs a two-pointer method, repeatedly scanning the array to find and move special elements to the front. 
        c)   Variable names that improve code clarity and make the logic easier to understand are {uniqueCount} and `current}. With O(n) time complexity and O(1) space complexity, the implementation is effective overall, and the comments enhance readability further.

        */

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length <= 1)
                    return nums;

                int nonZeroIndex = 0; // Pointer to keep track of the position to swap non-zero elements

                // Traverse the array
                for (int i = 0; i < nums.Length; i++)
                {
                    // If the current element is non-zero, swap it with the element at nonZeroIndex
                    if (nums[i] != 0)
                    {
                        int temp = nums[i];
                        nums[i] = nums[nonZeroIndex];
                        nums[nonZeroIndex] = temp;
                        nonZeroIndex++; // Increment nonZeroIndex
                    }
                }

                return nums;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
         * Self-analysis:
        a) The given code preserves the relative order of the non-zero elements while successfully moving all zeroes to the end of the array.By iterating through the array and replacing non-zero elements with the element at the { nonZeroIndex}, it utilizes a two-pointer technique.By using this method, zeroes are pushed to the end of the array and non-zero elements are moved toward the beginning while keeping their original order. 
        b) When an array is null or empty, the code responds appropriately by returning the input array.
        c) Well-managed variable naming, error handling, and input validation add to the robustness and clarity of the code. Overall, the implementation has an O(n) time complexity and an O(1) space complexity, effectively solving the problem in-place. n is the length of the array.
          
        */

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                Array.Sort(nums); // Sort the array to use two-pointer approach
                IList<IList<int>> result = new List<IList<int>>();

                for (int first = 0; first < nums.Length - 2; first++)
                {
                    if (first > 0 && nums[first] == nums[first - 1]) // Skip duplicate elements
                        continue;

                    int second = first + 1;
                    int third = nums.Length - 1;

                    while (second < third)
                    {
                        int sum = nums[first] + nums[second] + nums[third];
                        if (sum == 0)
                        {
                            result.Add(new List<int> { nums[first], nums[second], nums[third] });

                            // Skip duplicate elements
                            while (second < third && nums[second] == nums[second + 1])
                                second++;
                            while (second < third && nums[third] == nums[third - 1])
                                third--;

                            second++;
                            third--;
                        }
                        else if (sum < 0)
                        {
                            second++;
                        }
                        else
                        {
                            third--;
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /* * Self-analysis:
        a.) The given code finds unique triplets in the sorted array that sum up to zero by efficiently using a two-pointer technique. Variable names such as {first}, {second}, and {third} improved readability by adding clarity to the code. 
        b.) Even though it is unlikely that the operations involved will result in exceptions, the try-catch block guarantees error handling. The algorithm traverses the array efficiently, with an initial sorting overhead of O(n log n) and a time complexity of O(n^2) because of nested loops. The space complexity stays at O(1). 
        c.) All things considered, the solution to the problem of locating unique triplets in the provided array with a zero sum is succinct, effective, and dependable.
        */

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                int maxCount = 0;
                int currentCount = 0;

                foreach (int num in nums)
                {
                    if (num == 1)
                    {
                        currentCount++;
                        maxCount = Math.Max(maxCount, currentCount);
                    }
                    else
                    {
                        currentCount = 0; // Reset count if the current number is not 1
                    }
                }

                return maxCount;
            }
            catch (Exception)
            {
                throw;
            }
        }



        /* 
           * Self-analysis:
        a) The provided code uses a simple iterative method to efficiently calculate the maximum number of consecutive ones in a binary array.
        b) It initializes variables to record the maximum count reached thus far ({maxCount}) and the current count of consecutive ones ({currentCount}). When a one is encountered in the array, the code iterates through it, increasing `currentCount}; when a zero is encountered, it resets to zero. The maximum value of {currentCount} encountered is updated in `maxCount}. 
        c) The implementation is effective, with constant space complexity and an O(n) time complexity where n is the array's length. 
        
          
         */

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                int decimalValue = 0;
                int baseValue = 1;

                while (binary != 0)
                {
                    int remainder = binary % 10; // Extract the rightmost digit
                    decimalValue += remainder * baseValue; // Update the decimal value
                    binary /= 10; // Remove the rightmost digit
                    baseValue *= 2; // Update the base value
                }

                return decimalValue;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* 
           * Self-analysis:
        a) Using simple arithmetic operations, the provided code efficiently converts a binary number to its decimal representation. 
        b) From right to left, iterating through the binary number, it extracts each digit and modifies the corresponding decimal value according to its positional value. The algorithm satisfies the requirements by avoiding bitwise operators and {Math.Pow}. Although it is unlikely that exceptions will arise in this case, exception handling guarantees durability. The implementation effectively manages inputs within the given constraints. On the other hand, input validation might be used to make sure the binary number entered is within the permitted range. 
        c) All things considered, the solution is understandable, and satisfies the stated requirements. It provides a simple conversion technique without requiring complicated operations or libraries.
         */

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.


        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                if (nums.Length < 2)
                    return 0;

                // Radix sort
                RadixSort(nums);

                int maxGap = 0;
                for (int i = 1; i < nums.Length; i++)
                {
                    int diff = nums[i] - nums[i - 1];
                    maxGap = Math.Max(maxGap, diff);
                }

                return maxGap;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void RadixSort(int[] nums)
        {
            int max = nums.Max();
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountSort(nums, exp);
            }
        }

        private static void CountSort(int[] nums, int exp)
        {
            int[] output = new int[nums.Length];
            int[] count = new int[10];

            for (int i = 0; i < nums.Length; i++)
            {
                count[(nums[i] / exp) % 10]++;
            }

            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                output[count[(nums[i] / exp) % 10] - 1] = nums[i];
                count[(nums[i] / exp) % 10]--;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = output[i];
            }
        }


        /* * Analysis:
         a) The provided code uses the radix sort algorithm to efficiently find the maximum difference between two successive elements in a sorted array. The requirements of the algorithm are met by radix sort, which guarantees linear time complexity and linear extra space usage. The implementation first determines whether the input array has fewer than two elements; if so, it returns 0. The array is then sorted using radix sort, which guarantees that the elements are arranged in ascending order. Eventually, iterating through the sorted array, it determines the greatest difference between each subsequent element.
        b) Without the need for extra data structures, the solution provides an effective linear time solution while successfully resolving the issue within the given constraints.
        
         */

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                Array.Sort(nums);

                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    if (nums[i - 2] + nums[i - 1] > nums[i])
                    {
                        return nums[i - 2] + nums[i - 1] + nums[i];
                    }
                }

                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /* 
         * Analysis:
        a) From the given integer array, the provided code efficiently determines the largest perimeter of a triangle with non-zero area.
        b)To make sure that the largest elements are taken into consideration first, it sorts the array in non-decreasing order initially. After that, iterating through the sorted array, it determines whether each triplet of succeeding elements, in accordance with the triangle inequality theorem, forms a legitimate triangle. The perimeter is returned if a legitimate triangle is located. The implementation handles arrays up to 10^4 in length and elements between 1 and 10^6 in order to comply with the given constraints.
        c) Stability is ensured by exception handling, even though exceptions are unlikely in this case.    
      
         */

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                while (s.Contains(part)) // Check if s contains the substring part
                {
                    int index = s.IndexOf(part); // Find the index of the leftmost occurrence of part
                    s = s.Remove(index, part.Length); // Remove part from s starting at index
                }

                return s;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* * Analysis:
        a) The code that is provided effectively eliminates every instance of the substring {part} from the string {s}. 
        b) It keeps going through {s} until there are no more instances of {part}. In every iteration, it utilizes the {IndexOf` method to determine the index of the leftmost instance of {part} and the `Remove} method to eliminate it from {s}. This method eliminates all instances of {part} from {s} without depending on any built-in features. 
        c) The implementation ensures compatibility with inputs that contain lowercase  letters by handling input strings and substrings within the given constraints. 
           
         */


        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}