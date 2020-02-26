using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    // Задача: реализовать метод SortStringArray, который должен возвращать сортированный массив строк.
    //   * Метод должен сортировать строки по количеству символов.
    //   * Метод должен выбрасывать ArgumentNullException, если в метод передан null.
    class Program
    {

        public static string[] SortStringArray(string[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("В метод передан null");
            }
            else
            {
                Array.Sort(array, new StringComparer());
                return array;
            }
        }
        private class StringComparer : IComparer<String>
        {
            public int Compare(String left, String right)
            {
                if (left.Length > right.Length)
                    return 1;
                else if (left.Length < right.Length)
                    return -1;
                else
                    return 0;
            }
        }
        
        // ----- ЗАПРЕЩЕНО ИЗМЕНЯТЬ КОД МЕТОДОВ, КОТОРЫЕ НАХОДЯТСЯ НИЖЕ -----

        static void Main(string[] args)
        {
            Console.WriteLine("Task is done when all test cases are correct:");

            int testCaseNumber = 1;

            TestReturnedValues(testCaseNumber++, new string[] { }, new string[] { });
            TestReturnedValues(testCaseNumber++, new string[] { string.Empty }, new string[] { string.Empty });
            TestReturnedValues(testCaseNumber++, new string[] { "abc" }, new string[] { "abc" });
            TestReturnedValues(testCaseNumber++, new string[] { "abc", "abcd" }, new string[] { "abc", "abcd" });
            TestReturnedValues(testCaseNumber++, new string[] { "abcd", "abc" }, new string[] { "abc", "abcd" });
            TestReturnedValues(testCaseNumber++, new string[] { "abc", "abcd", "abcde" }, new string[] { "abc", "abcd", "abcde" });
            TestReturnedValues(testCaseNumber++, new string[] { "abcde", "abcd", "abc" }, new string[] { "abc", "abcd", "abcde" });
            TestReturnedValues(testCaseNumber++, new string[] { "123456", "1", "12345", "12", "1234", "123", "1234567" }, new string[] { "1", "12", "123", "1234", "12345", "123456", "1234567" });
            TestReturnedValues(testCaseNumber++, new string[] { "1234567", "123", "1", "12345678", "12", "1234", "12", "1234", "123", "123456", "12345678", "1234", "12345", "123556" }, new string[] { "1", "12", "12", "123", "123", "1234", "1234", "1234", "12345", "123456", "123556", "1234567", "12345678", "12345678" });

            TestException<ArgumentNullException>(testCaseNumber++, null);

            if (correctTestCaseAmount == testCaseNumber - 1)
            {
                Console.WriteLine("Task is done.");
            }
            else
            {
                Console.WriteLine("TASK IS NOT DONE.");
            }
            Console.ReadKey();
        }
        private static void TestReturnedValues(int testCaseNumber, string[] array, string[] expectedResult)
        {
            try
            {
                var result = SortStringArray(array);

                if (result.SequenceEqual(expectedResult))
                {
                    Console.WriteLine(correctCaseTemplate, testCaseNumber);
                    correctTestCaseAmount++;
                }
                else
                {
                    Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
                }
            }
            catch (Exception)
            {
                Console.WriteLine(failedCaseTemplate, testCaseNumber);
            }
        }

        private static void TestException<T>(int testCaseNumber, string[] array) where T : Exception
        {
            try
            {
                SortStringArray(array);
                Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
            }
            catch (T)
            {
                Console.WriteLine(correctCaseTemplate, testCaseNumber);
                correctTestCaseAmount++;
            }
            catch (Exception)
            {
                Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
            }
        }

        private static string correctCaseTemplate = "Case #{0} is correct.";
        private static string incorrectCaseTemplate = "Case #{0} IS NOT CORRECT";
        private static string failedCaseTemplate = "Case #{0} FAILED";
        private static int correctTestCaseAmount = 0;
    }
}

