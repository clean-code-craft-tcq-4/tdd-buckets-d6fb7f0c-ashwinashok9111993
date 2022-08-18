namespace RangeReaderClass.Tests;
using RangeReaderClass;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Assert.True(RangeReader.GetNumReadings("4-5") == 2);
    }
}