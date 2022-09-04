using System;
using System.Collections.Generic;
using System.Linq;

namespace RangeReaderStack
{
    public class RangeReaderClass
    {
        // Get the integer count by occurence in an input integer list
        public static int getCountByValue(List<int> inputIntegerList, int targetValue)
        {
            return inputIntegerList.Where(x => x == targetValue).Count();
        }

        public static List<int> getRangeFromMinMax(int min,int max)
        {
            return Enumerable.Range(min, max - min + 1).ToList();
        }

        public static Dictionary<int,int> DetectRanges(List<int> inputList)
        {
            var distinctInputList = inputList.Distinct().ToList();
            int primaryIterator = distinctInputList.Min();
            int iterator = primaryIterator + 1;
            Dictionary<int, int> rangeDict = new Dictionary<int, int>();

            while (primaryIterator < distinctInputList.Max())
            {

                while (CompareSequenceEquals(distinctInputList, primaryIterator, iterator))
                {
                    rangeDict[primaryIterator] = iterator++;

                }
                primaryIterator = iterator;
                iterator = primaryIterator + 1;
            }

            return rangeDict;
        }

        // Checks for the range in the given input integer list, returns true if present
        public static bool CompareSequenceEquals(List<int> distinctInputList, int min, int max)
        {
            return Enumerable.SequenceEqual(getRangeFromMinMax(min, max)
                               .Intersect(distinctInputList).ToList(),
                                getRangeFromMinMax(min, max))
                                && (max <= distinctInputList.Max())
                                && (min <= max);
        }

        public static int GetCountInRangeAndList(List<int> InputList,int min,int max)
        {
            var count = 0;
            foreach (int value in getRangeFromMinMax(min,max))
            {
                count = count + getCountByValue(InputList, value);
            }
            return count;
        }

        public static string RangeWriter(List<int> InputList,int min, int max)
        {
            return $"{min}-{max},{GetCountInRangeAndList(InputList,min,max)}";
        }

        public static void printTableFromInputList(List<int> InputList)
        {
            foreach(var input in DetectRanges(InputList))
            {
                Console.WriteLine(RangeWriter(InputList, input.Key, input.Value));
            }
        }
        
    }
}
