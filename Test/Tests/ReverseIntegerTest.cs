using LeetCodeCom.Solutions;
using Test.Models;

namespace Test.Tests;

public class ReverseIntegerTest
{
    private readonly ReverseInteger _reverseInteger;

    public static IEnumerable<object[]> Items =>
        new List<BaseValues[]>
        {
            new[] { new BaseValues { Value = -2147483648, Expected = 0 } },
            new[] { new BaseValues { Value = 5123, Expected = 3215 } },
            new[] { new BaseValues { Value = -2147483412, Expected = -2143847412 } },
            new[] { new BaseValues { Value = 1534236469, Expected = 0 } },
            new[] { new BaseValues { Value = 999995999, Expected = 999599999 } },
            new[] { new BaseValues { Value = 99999299, Expected = 99299999 } },
            new[] { new BaseValues { Value = 9959299, Expected = 9929599 } },
            new[] { new BaseValues { Value = -929299, Expected = -992929 } },
            new[] { new BaseValues { Value = 32909, Expected = 90923 } },
            new[] { new BaseValues { Value = 3999, Expected = 9993 } },
            new[] { new BaseValues { Value = 123, Expected = 321 } },
            new[] { new BaseValues { Value = 23, Expected = 32 } },
            new[] { new BaseValues { Value = 1, Expected = 1 } },
            new[] { new BaseValues { Value = -1, Expected = -1 } },
            new[] { new BaseValues { Value = 0, Expected = 0 } }
        };

    public ReverseIntegerTest()
    {
        _reverseInteger = new ReverseInteger();
    }

    [Theory]
    [MemberData(nameof(Items))]
    public void Solution_1(BaseValues item)
    {
        int result = _reverseInteger.Solution_1((int)item.Value!);

        Assert.Equal(item.Expected, result);
    }

    [Theory]
    [MemberData(nameof(Items))]
    public void Solution_2(BaseValues item)
    {
        int result = _reverseInteger.Solution_2((int)item.Value!);

        Assert.Equal(item.Expected, result);
    }


    [Theory]
    [MemberData(nameof(Items))]
    public void Solution_3(BaseValues item)
    {
        int result = _reverseInteger.Solution_3((int)item.Value!);

        Assert.Equal(item.Expected, result);
    }

    [Theory]
    [MemberData(nameof(Items))]
    public void Solution_4(BaseValues item)
    {
        int result = _reverseInteger.Solution_4((int)item.Value!);

        Assert.Equal(item.Expected, result);
    }

    [Theory]
    [MemberData(nameof(Items))]
    public void Solution_5(BaseValues item)
    {
        int result = _reverseInteger.Solution_5((int)item.Value!);

        Assert.Equal(item.Expected, result);
    }

    [Theory]
    [MemberData(nameof(Items))]
    public void Solution_6(BaseValues item)
    {
        int result = _reverseInteger.Solution_6((int)item.Value!);

        Assert.Equal(item.Expected, result);
    }

    [Theory]
    [MemberData(nameof(Items))]
    public void Solution_7(BaseValues item)
    {
        int result = _reverseInteger.Solution_7((int)item.Value!);

        Assert.Equal(item.Expected, result);
    }

    [Theory]
    [MemberData(nameof(Items))]
    public void Solution_8(BaseValues item)
    {
        int result = _reverseInteger.Solution_8((int)item.Value!);

        Assert.Equal(item.Expected, result);
    }

    [Theory]
    [MemberData(nameof(Items))]
    public void Solution_9(BaseValues item)
    {
        int result = _reverseInteger.Solution_9((int)item.Value!);

        Assert.Equal(item.Expected, result);
    }

    [Theory]
    [MemberData(nameof(Items))]
    public void Solution_10(BaseValues item)
    {
        int result = _reverseInteger.Solution_10((int)item.Value!);

        Assert.Equal(item.Expected, result);
    }
}
