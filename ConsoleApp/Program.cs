using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {
        static void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        static void ReverseArrayList(ArrayList list)
        {
            int left = 0;
            int right = list.Count - 1;

            while (left < right)
            {
                object temp = list[left];
                list[left] = list[right];
                list[right] = temp;

                left++;
                right--;
            }
        }
        static void PrintArrayList(ArrayList list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void ReverseQueue(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();

           
            while (queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }

           
            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }
        }

        static bool IsBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    char top = stack.Pop();
                    if (!IsMatchingPair(top, c))
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        static bool IsMatchingPair(char opening, char closing)
        {
            return (opening == '(' && closing == ')') ||
                   (opening == '{' && closing == '}') ||
                   (opening == '[' && closing == ']');
        }

        static int[] RemoveDuplicates(int[] arr)
        {
            HashSet<int> seen = new HashSet<int>();
            List<int> result = new List<int>();

            foreach (int num in arr)
            {
                if (!seen.Contains(num))
                {
                    seen.Add(num);
                    result.Add(num);
                }
            }

            return result.ToArray();
        }

        static void RemoveOddNumbers(ArrayList list)
        {
            
            for (int i = list.Count - 1; i >= 0; i--)
            {
                
                if (list[i] is int number && number % 2 != 0)
                {
                    list.RemoveAt(i);
                }
            }
        }

        static int[] FindIntersection(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
            List<int> result = new List<int>();

            
            foreach (int num in nums1)
            {
                if (frequencyMap.ContainsKey(num))
                {
                    frequencyMap[num]++;
                }
                else
                {
                    frequencyMap[num] = 1;
                }
            }

            
            foreach (int num in nums2)
            {
                if (frequencyMap.ContainsKey(num) && frequencyMap[num] > 0)
                {
                    result.Add(num);
                    frequencyMap[num]--;
                }
            }

            return result.ToArray();
        }

        static ArrayList FindSublistWithSum(ArrayList list, int targetSum)
        {
            int start = 0;
            int currentSum = 0;

            for (int end = 0; end < list.Count; end++)
            {
                currentSum += (int)list[end];

                while (currentSum > targetSum && start < end)
                {
                    currentSum -= (int)list[start];
                    start++;
                }

                if (currentSum == targetSum)
                {
                    ArrayList result = new ArrayList();
                    for (int i = start; i <= end; i++)
                    {
                        result.Add(list[i]);
                    }
                    return result;
                }
            }

            return new ArrayList(); 
        }


        static void ReverseFirstKElements(Queue<int> queue, int K)
        {
            if (queue == null || K <= 0 || K > queue.Count)
            {
                Console.WriteLine("Invalid input for K.");
                return;
            }

            Stack<int> stack = new Stack<int>();

            
            for (int i = 0; i < K; i++)
            {
                stack.Push(queue.Dequeue());
            }

           
            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }

           
            for (int i = 0; i < queue.Count - K; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }
        static void Main(string[] args)
        {
            //#region Task (1)
            //int[] data = { 64, 34, 25, 12, 22, 11, 90 };

            //Console.WriteLine("Original array:");
            //PrintArray(data);

            //OptimizedBubbleSort.OptimizeBubbleSort(data);

            //Console.WriteLine("\nSorted array:");
            //PrintArray(data);
            //#endregion

            /* =================================== */

            //#region Task (2)
            //ArrayList myList = new ArrayList() { 1, 2, 3, 4, 5, "hello", 7.5, true };

            //Console.WriteLine("Original ArrayList:");
            //PrintArrayList(myList);

            //ReverseArrayList(myList);

            //Console.WriteLine("\nReversed ArrayList:");
            //PrintArrayList(myList);
            //#endregion

            /* =================================== */

            //#region Task (3)
            //string[] input = Console.ReadLine().Split();
            //int N = int.Parse(input[0]);
            //int Q = int.Parse(input[1]);

            //int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            //int[] queries = new int[Q];
            //for (int i = 0; i < Q; i++)
            //{
            //    queries[i] = int.Parse(Console.ReadLine());
            //}


            //Array.Sort(arr);


            //foreach (int X in queries)
            //{

            //    int index = Array.BinarySearch(arr, X);
            //    if (index < 0)
            //    {

            //        index = ~index;
            //    }
            //    else
            //    {

            //        while (index < N && arr[index] == X)
            //        {
            //            index++;
            //        }
            //    }

            //    int count = N - index;
            //    Console.WriteLine(count);
            //}
            //#endregion

            /* =================================== */

            //#region Task (4)
            //try
            //{

            //    int N;
            //    if (!int.TryParse(Console.ReadLine(), out N))
            //    {
            //        Console.WriteLine("Error: Please enter a valid integer for array size");
            //        return;
            //    }


            //    string[] elements = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //    if (elements.Length != N)
            //    {
            //        Console.WriteLine($"Error: Please enter exactly {N} numbers");
            //        return;
            //    }

            //    int[] arr = new int[N];
            //    for (int i = 0; i < N; i++)
            //    {
            //        if (!int.TryParse(elements[i], out arr[i]))
            //        {
            //            Console.WriteLine($"Error: Element {i + 1} is not a valid integer");
            //            return;
            //        }
            //    }


            //    bool isPalindrome = true;
            //    for (int i = 0; i < N / 2; i++)
            //    {
            //        if (arr[i] != arr[N - 1 - i])
            //        {
            //            isPalindrome = false;
            //            break;
            //        }
            //    }

            //    Console.WriteLine(isPalindrome ? "YES" : "NO");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            //}
            //#endregion

            /* =================================== */

            //#region Task (5)
            //Queue<int> queue = new Queue<int>();
            //queue.Enqueue(1);
            //queue.Enqueue(2);
            //queue.Enqueue(3);
            //queue.Enqueue(4);
            //queue.Enqueue(5);

            //Console.WriteLine("Original Queue:");
            //foreach (int item in queue)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();

            //ReverseQueue(queue);

            //Console.WriteLine("Reversed Queue:");
            //foreach (int item in queue)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //#endregion

            /* =================================== */

            //#region Task (6)
            //string input = "[()]{}";
            //bool balanced = IsBalanced(input);

            //Console.WriteLine($"Input: {input}");
            //Console.WriteLine(balanced ? "Balanced" : "Not Balanced");
            //#endregion

            /* =================================== */

            //#region Task (7)
            //int[] arr = { 1, 2, 2, 3, 4, 4, 4, 5, 5 };
            //int[] uniqueArr = RemoveDuplicates(arr);

            //Console.WriteLine("Original Array:");
            //Console.WriteLine(string.Join(", ", arr));

            //Console.WriteLine("Array after removing duplicates:");
            //Console.WriteLine(string.Join(", ", uniqueArr));
            //#endregion

            /* =================================== */

            //#region Task (8)
            //ArrayList numbers = new ArrayList() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Console.WriteLine("Original ArrayList:");
            //foreach (var num in numbers)
            //{
            //    Console.Write(num + " ");
            //}
            //Console.WriteLine();

            //RemoveOddNumbers(numbers);

            //Console.WriteLine("ArrayList after removing odd numbers:");
            //foreach (var num in numbers)
            //{
            //    Console.Write(num + " ");
            //}
            //Console.WriteLine();
            //#endregion

            /* =================================== */

            //#region Task (9)
            //Queue mixedQueue = new Queue();


            //mixedQueue.Enqueue(1);          
            //mixedQueue.Enqueue("Apple");    
            //mixedQueue.Enqueue(5.28);       


            //Console.WriteLine("Elements in the queue:");
            //foreach (var item in mixedQueue)
            //{
            //    Console.WriteLine(item + " (" + item.GetType() + ")");
            //}


            //Console.WriteLine("\nDequeuing elements:");
            //while (mixedQueue.Count > 0)
            //{
            //    var item = mixedQueue.Dequeue();
            //    Console.WriteLine(item + " (" + item.GetType() + ")");
            //}
            //#endregion

            /* =================================== */

            //#region Task (10)
            //Stack<int> stack = new Stack<int>();


            //stack.Push(10);
            //stack.Push(20);
            //stack.Push(30);
            //stack.Push(40);
            //stack.Push(50);
            //stack.Push(60);
            //stack.Push(70);
            //stack.Push(80);
            //stack.Push(90);
            //stack.Push(100);

            //Console.WriteLine("Enter the target integer to search for:");
            //int target;
            //while (!int.TryParse(Console.ReadLine(), out target))
            //{
            //    Console.WriteLine("Invalid input. Please enter an integer:");
            //}

            //bool found = false;
            //int count = 0;
            //Stack<int> tempStack = new Stack<int>();


            //while (stack.Count > 0)
            //{
            //    count++;
            //    int current = stack.Pop();
            //    tempStack.Push(current);

            //    if (current == target)
            //    {
            //        found = true;
            //        break;
            //    }
            //}


            //while (tempStack.Count > 0)
            //{
            //    stack.Push(tempStack.Pop());
            //}


            //if (found)
            //{
            //    Console.WriteLine($"Target was found successfully and the count = {count}");
            //}
            //else
            //{
            //    Console.WriteLine("Target was not found");
            //}
            //#endregion

            /* =================================== */

            //#region Task (11)

            //int[] nums1 = { 1, 2, 3, 4, 4 };
            //int[] nums2 = { 10, 4, 4 };

            //int[] intersection = FindIntersection(nums1, nums2);

            //Console.WriteLine("Intersection of the two arrays:");
            //Console.WriteLine($"[{string.Join(", ", intersection)}]");
            //#endregion

            /* =================================== */

            //#region Task (12)
            //ArrayList numbers = new ArrayList { 1, 2, 3, 7, 5 };
            //int target = 12;

            //ArrayList result = FindSublistWithSum(numbers, target);

            //if (result.Count > 0)
            //{
            //    Console.Write("[");
            //    for (int i = 0; i < result.Count; i++)
            //    {
            //        Console.Write(result[i]);
            //        if (i < result.Count - 1)
            //        {
            //            Console.Write(", ");
            //        }
            //    }
            //    Console.WriteLine("]");
            //}
            //else
            //{
            //    Console.WriteLine("No sublist found with the given sum.");
            //}
            //#endregion

            /* =================================== */

            #region Task (13)
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            int K = 3;

            Console.WriteLine("Original Queue:");
            Console.WriteLine(string.Join(", ", queue));

            ReverseFirstKElements(queue, K);

            Console.WriteLine("Queue after reversing first " + K + " elements:");
            Console.WriteLine(string.Join(", ", queue));

            #endregion
        }
    }
}
