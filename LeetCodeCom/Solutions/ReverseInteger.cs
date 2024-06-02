using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using LeetCodeCom.Models.Configurations;

namespace LeetCodeCom.Solutions;

[Config(typeof(BenchmarkConfiguration))]

[SimpleJob(RuntimeMoniker.Net80, baseline: true)]
[SimpleJob(RuntimeMoniker.Net90)]

[MemoryDiagnoser]
[DisassemblyDiagnoser(printSource: true, exportHtml: true)]

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[HideColumns(Column.Error, Column.StdDev, Column.Median, Column.Job, Column.AllocRatio)]
public class ReverseInteger
{
    public IEnumerable<object[]> Numbers()
    {
        yield return new object[] { 1 };
        yield return new object[] { 13 };
        yield return new object[] { 123 };
        yield return new object[] { 3999 };
        yield return new object[] { 32909 };
        yield return new object[] { -929299 };
        yield return new object[] { 9959299 };
        yield return new object[] { 99999299 };
        yield return new object[] { 999995999 };
        yield return new object[] { 1534236469 };
        yield return new object[] { -2147483412 };
    }

    [Benchmark]
    [ArgumentsSource(nameof(Numbers))]
    public int Solution_1(int x)
    {
        if (x == 0)
        {
            return 0;
        }

        int value = x;
        if (x < 0)
        {
            value = -value;
            if (value < 0)
            {
                return 0;
            }
        }

        bool isNegative = x < 0;
        char[] chars = x.ToString().ToCharArray();

        Array.Reverse(chars);

        int length = isNegative ? chars.Length - 1 : chars.Length;

        StringBuilder sb = new(length);
        for (int i = 0; i < length; i++)
        {
            char item = chars[i];
            sb.Append(item);
        }

        int number;
        if (length != 10)
        {
            number = int.Parse(sb.ToString());
            return isNegative ? -number : number;
        }

        if (!int.TryParse(sb.ToString(), out number))
        {
            return 0;
        }

        return isNegative ? -number : number;
    }

    [Benchmark]
    [ArgumentsSource(nameof(Numbers))]
    public int Solution_2(int x)
    {
        bool isNegative = x < 0;
        char[] chars = x.ToString().ToCharArray();

        Array.Reverse(chars);

        int length = isNegative ? chars.Length - 1 : chars.Length;

        StringBuilder sb = new(length);
        for (int i = 0; i < length; i++)
        {
            char item = chars[i];
            sb.Append(item);
        }

        int number;
        if (length != 10)
        {
            number = int.Parse(sb.ToString());
            return isNegative ? -number : number;
        }

        if (!int.TryParse(sb.ToString(), out number))
        {
            return 0;
        }

        return isNegative ? -number : number;
    }


    [Benchmark]
    [ArgumentsSource(nameof(Numbers))]
    public int Solution_3(int x)
    {
        Span<int> numbers = stackalloc int[10];

        numbers[0] = x % 10;
        x /= 10;

        int coefficient = 1;

        int index = 1;
        while (x != 0)
        {
            numbers[index++] = x % 10;
            x /= 10;

            coefficient *= 10;
        }

        int result = 0;
        if (index != 10)
        {
            for (int i = 0; i < index; i++)
            {
                int number = numbers[i];
                result += number * coefficient;

                coefficient /= 10;
            }

            return result;
        }

        for (int i = 0; i < index; i++)
        {
            int number = numbers[i];
            try
            {
                result = checked(result + number * coefficient);
            }
            catch (OverflowException)
            {
                return 0;
            }

            coefficient /= 10;
        }

        return result;
    }

    [Benchmark]
    [ArgumentsSource(nameof(Numbers))]
    public int Solution_4(int x)
    {
        Span<int> numbers = stackalloc int[10];

        numbers[0] = x % 10;
        x /= 10;

        int coefficient = 1;

        int index = 1;
        while (x != 0)
        {
            numbers[index++] = x % 10;
            x /= 10;

            coefficient *= 10;
        }

        int result = 0;
        for (int i = 0; i < index; i++)
        {
            int number = numbers[i];

            if (index != 10)
            {
                result += number * coefficient;

                coefficient /= 10;
                continue;
            }

            try
            {
                result = checked(result + number * coefficient);
            }
            catch (OverflowException)
            {
                return 0;
            }

            coefficient /= 10;
        }

        return result;
    }

    [Benchmark]
    [ArgumentsSource(nameof(Numbers))]
    public int Solution_5(int x)
    {
        int value = x;
        if (x < 0)
        {
            value = -value;
            if (value < 0)
            {
                return 0;
            }
        }

        Span<int> numbers = stackalloc int[10];

        numbers[0] = x % 10;
        x /= 10;

        int coefficient = 1;

        int index = 1;
        while (x != 0)
        {
            numbers[index++] = x % 10;
            x /= 10;

            coefficient *= 10;
        }

        int result = 0;
        for (int i = 0; i < index; i++)
        {
            int number = numbers[i];

            if (index != 10)
            {
                result += number * coefficient;

                coefficient /= 10;
                continue;
            }

            try
            {
                result = checked(result + number * coefficient);
            }
            catch (OverflowException)
            {
                return 0;
            }

            coefficient /= 10;
        }

        return result;
    }

    [Benchmark]
    [ArgumentsSource(nameof(Numbers))]
    public int Solution_6(int x)
    {
        if (x == 0)
        {
            return 0;
        }

        int value = x;
        if (x < 0)
        {
            value = -value;
            if (value < 0)
            {
                return 0;
            }
        }

        int digitsCount = (int)Math.Log10(value) + 1;
        if (digitsCount == 1)
        {
            return x;
        }

        Span<int> numbers = stackalloc int[digitsCount];

        numbers[0] = x % 10;
        x /= 10;

        int coefficient = 1;
        for (int i = 1; i < digitsCount; i++)
        {
            numbers[i] = x % 10;
            x /= 10;

            coefficient *= 10;
        }

        int result = 0;
        if (digitsCount != 10)
        {
            for (int i = 0; i < digitsCount; i++)
            {
                int number = numbers[i];
                result += number * coefficient;

                coefficient /= 10;
            }

            return result;
        }

        for (int i = 0; i < digitsCount; i++)
        {
            int number = numbers[i];
            try
            {
                result = checked(result + number * coefficient);
            }
            catch (OverflowException)
            {
                return 0;
            }

            coefficient /= 10;
        }

        return result;
    }

    [Benchmark]
    [ArgumentsSource(nameof(Numbers))]
    public int Solution_7(int x)
    {
        if (x == 0)
        {
            return 0;
        }

        int value = x;
        if (x < 0)
        {
            value = -value;
            if (value < 0)
            {
                return 0;
            }
        }

        bool isNegative = x < 0;

        int digitsCount = (int)Math.Log10(value) + 1;
        if (digitsCount == 1)
        {
            return x;
        }

        Span<int> numbers = stackalloc int[digitsCount];

        numbers[0] = x % 10;
        x /= 10;

        int coefficient = 1;
        for (int i = 1; i < digitsCount; i++)
        {
            numbers[i] = x % 10;
            x /= 10;

            coefficient *= 10;
        }

        int number;

        int result = 0;
        if (digitsCount != 10)
        {
            for (int i = 0; i < digitsCount; i++)
            {
                number = numbers[i];
                result += number * coefficient;

                coefficient /= 10;
            }

            return result;
        }

        StringBuilder sb = new(numbers.Length);
        for (int i = 0; i < numbers.Length; i++)
        {
            int item = numbers[i];
            if (isNegative)
            {
                item = -item;
            }

            sb.Append(item);
        }

        if (!int.TryParse(sb.ToString(), out number))
        {
            return 0;
        }

        return isNegative ? -number : number;
    }

    [Benchmark]
    [ArgumentsSource(nameof(Numbers))]
    public int Solution_8(int x)
    {
        if (x == 0)
        {
            return 0;
        }

        int value = x;
        if (x < 0)
        {
            value = -value;
            if (value < 0)
            {
                return 0;
            }
        }

        int digitsCount = (int)Math.Log10(value) + 1;
        if (digitsCount < 1)
        {
            return x;
        }

        if (digitsCount == 10)
        {
            bool isNegative = x < 0;
            char[] chars = x.ToString().ToCharArray();

            Array.Reverse(chars);

            int length = isNegative ? chars.Length - 1 : chars.Length;

            StringBuilder sb = new(length);
            for (int i = 0; i < length; i++)
            {
                char item = chars[i];
                sb.Append(item);
            }

            if (!int.TryParse(sb.ToString(), out int number))
            {
                return 0;
            }

            return isNegative ? -number : number;
        }

        Span<int> numbers = stackalloc int[digitsCount];

        numbers[0] = x % 10;
        x /= 10;

        int coefficient = 1;
        for (int i = 1; i < digitsCount; i++)
        {
            numbers[i] = x % 10;
            x /= 10;

            coefficient *= 10;
        }

        int result = 0;
        for (int i = 0; i < digitsCount; i++)
        {
            int number = numbers[i];
            result += number * coefficient;

            coefficient /= 10;
        }

        return result;
    }

    [Benchmark]
    [ArgumentsSource(nameof(Numbers))]
    public int Solution_9(int x)
    {
        int value = x;
        Span<int> numbers = stackalloc int[10];

        numbers[0] = x % 10;
        x /= 10;

        int coefficient = 1;

        int index = 1;
        while (x != 0)
        {
            numbers[index++] = x % 10;
            x /= 10;

            coefficient *= 10;
        }

        int number;

        int result = 0;
        if (index != 10)
        {
            for (int i = 0; i < index; i++)
            {
                number = numbers[i];
                result += number * coefficient;

                coefficient /= 10;
            }

            return result;
        }

        bool isNegative = value < 0;
        int firstIndex = isNegative ? 1 : 0;

        string str = value.ToString();
        int length = str.Length;

        StringBuilder sb = new(str.Length);
        for (int i = length - 1; i >= firstIndex; i--)
        {
            char item = str[i];
            sb.Append(item);
        }

        if (!int.TryParse(sb.ToString(), out number))
        {
            return 0;
        }

        return isNegative ? -number : number;
    }

    [Benchmark]
    [ArgumentsSource(nameof(Numbers))]
    public int Solution_10(int x)
    {
        bool isNegative = x < 0;
        int firstIndex = isNegative ? 1 : 0;

        string str = x.ToString();
        int length = str.Length;

        StringBuilder sb = new(str.Length);
        for (int i = length - 1; i >= firstIndex; i--)
        {
            char item = str[i];
            sb.Append(item);
        }

        int number;
        if (sb.Length != 10)
        {
            number = int.Parse(sb.ToString());
            return isNegative ? -number : number;
        }

        if (!int.TryParse(sb.ToString(), out number))
        {
            return 0;
        }

        return isNegative ? -number : number;
    }
}
