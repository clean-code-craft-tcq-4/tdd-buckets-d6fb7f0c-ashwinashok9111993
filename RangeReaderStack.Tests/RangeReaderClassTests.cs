using System;
using Xunit;
using RangeReaderStack;
using System.Collections.Generic;

namespace RangeReaderStack.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestGetValueByCountInList()
        {
            Assert.Equal(2, RangeReaderClass.getCountByValue(new List<int> { 1, 2, 3, 1, 2 }, 2));
        }

        [Fact]
        public void TestgetRangeFromMinMax()
        {
            Assert.Equal(new List<int> { 1, 2, 3, 4 }, RangeReaderClass.getRangeFromMinMax(1, 4));
        }

        [Fact]
        public void TestDetectRanges()
        {
            Assert.Equal(new Dictionary<int, int> { { 1, 4 }, { 6, 8 }, { 15, 17 } },
                RangeReaderClass.DetectRanges(new List<int> { 1, 1, 2, 3, 4, 4, 6, 7, 8, 15, 16, 17 }));
        }

        [Fact]
        public void TestCompareSequenceEquals()
        {
            Assert.True(RangeReaderClass.CompareSequenceEquals(new List<int> { 1, 1, 2, 3, 4, 4, 6, 7, 8, 15, 16, 17 }, 1, 4));
            Assert.False(RangeReaderClass.CompareSequenceEquals(new List<int> { 1, 1, 2, 3, 4, 4, 6, 7, 8, 15, 16, 17 }, 1, 5));
        }

        [Fact]
        public void TestGetCountInRangeAndList()
        {
            Assert.StrictEqual(4,RangeReaderClass.GetCountInRangeAndList(new List<int> { 1, 1, 1, 2 }, 1, 2));
        }

        [Fact]
        public void TestRangeWriter()
        {
            Assert.Equal("1-4,6", RangeReaderClass.RangeWriter(new List<int> { 1, 1, 2, 3, 4, 4, 6, 7, 8, 15, 16, 17 },1,4));
        }
    }
}
