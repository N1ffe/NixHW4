namespace NixHW4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int n1, n2 = 0, n3 = 0, c1, c2;
            int[] arr1;
            string[] arr2, arr3;
            bool result;
            do
            {
                Console.Write("Enter array size: ");
                string? input = Console.ReadLine();
                result = int.TryParse(input, out n1);
                if (result)
                {
                    if (n1 < 1)
                    {
                        Console.WriteLine("Array size can not be less than 1");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number");
                }
            } while (!result || n1 < 1);
            arr1 = new int[n1];
            arr2 = new string[n1];
            arr3 = new string[n1];
            for (int i = 0; i < n1; i++)
            {
                arr1[i] = random.Next(1, 26 + 1);
                if (arr1[i] % 2 == 0)
                {
                    arr2[n2] = arr1[i].ToString();
                    n2++;
                }
                else
                {
                    arr3[n3] = arr1[i].ToString();
                    n3++;
                }
            }
            ShowArray(arr1, n1, "\narr1: ");
            ShowArray(arr2, n2, "arr2: ");
            ShowArray(arr3, n3, "arr3: ");
            Console.WriteLine();
            c1 = Task(arr2, n2, "arr2: ");
            c2 = Task(arr3, n3, "arr3: ");
            if (c1 > c2)
            {
                Console.WriteLine($"\narr2 has {c1 - c2} more uppercase letters ({c1})");
            }
            else
            {
                Console.WriteLine($"\narr3 has {c2 - c1} more uppercase letters ({c2})");
            }
        }
        public static void ShowArray(int[] arr, int size, string text)
        {
            Console.Write(text);
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
        }
        public static void ShowArray(string[] arr, int size, string text)
        {
            Console.Write(text);
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
        }
        public static int Task(string[] arr, int size, string text)
        {
            char[] targetSymbols = new char[] { 'a', 'e', 'i', 'd', 'h' };
            const int asciiOffset1 = 97, asciiOffset2 = -32;
            int count = 0;
            for (int i = 0; i < size; i++)
            {
                int ascii = Convert.ToInt32(arr[i]) + asciiOffset1 - 1;
                if (Array.IndexOf(targetSymbols, (char)ascii) > -1)
                {
                    arr[i] = ((char)(ascii + asciiOffset2)).ToString();
                    count++;
                }
                else
                {
                    arr[i] = ((char)ascii).ToString();
                }
            }
            ShowArray(arr, size, text);
            return count;
        }
    }
}