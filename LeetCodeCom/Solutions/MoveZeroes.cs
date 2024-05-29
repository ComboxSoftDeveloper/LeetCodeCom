using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using LeetCodeCom.Models.Configurations;

namespace LeetCodeCom.Solutions;

// https://leetcode.com/problems/move-zeroes/description/

[Config(typeof(BenchmarkConfiguration))]

[SimpleJob(RuntimeMoniker.Net80, baseline: true)]
[SimpleJob(RuntimeMoniker.Net90)]

[MemoryDiagnoser]
[DisassemblyDiagnoser(printSource: true, exportHtml: true)]

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[HideColumns(Column.Error, Column.StdDev, Column.Median, Column.Job, Column.AllocRatio)]
public class MoveZeroes
{
    [Params(1_000_000)]
    public int ItemsCount;

    public int[] nums_1;
    public int[] nums_2;
    public int[] nums_3;
    public int[] nums_4;
    public int[] nums_5;
    public int[] nums_6;
    public int[] nums_7;

    [GlobalSetup]
    public void GlobalSetup()
    {
        Random random = new(byte.MaxValue);

        const int maxValue = 2;
        IEnumerable<int> numbers = Enumerable.Range(1, ItemsCount)
           .Select(_ => random.Next(maxValue))
           .ToArray();

        nums_1 = numbers.ToArray();
        nums_2 = numbers.ToArray();
        nums_3 = numbers.ToArray();
        nums_4 = numbers.ToArray();
        nums_5 = numbers.ToArray();
        nums_6 = numbers.ToArray();
        nums_7 = numbers.ToArray();
    }

    [Benchmark]
    public void Solution_1()
    {
        int notZeroIndex = -1;

        Span<int> items = nums_1.AsSpan();

        int length = items.Length;
        for (int i = 0; i < length; i++)
        {
            int item = items[i];
            if (item != 0)
            {
                notZeroIndex++;
                items[notZeroIndex] = item;
            }
        }

        notZeroIndex++;

        if (notZeroIndex != length)
        {
            items[notZeroIndex..].Clear();
        }
    }

    [Benchmark]
    public void Solution_2()
    {
        int notZeroIndex = -1;

        Span<int> items = nums_2.AsSpan();

        int length = items.Length;
        for (int i = 0; i < length; i++)
        {
            int item = items[i];
            if (item == 0)
            {
                notZeroIndex = i;
                break;
            }
        }

        if (notZeroIndex == -1)
        {
            return;
        }

        Span<int> array = items[notZeroIndex..];

        notZeroIndex = -1;

        length = array.Length;
        for (int i = 0; i < length; i++)
        {
            int item = array[i];
            if (i == 0 && item != 0)
            {
                notZeroIndex++;
                continue;
            }

            if (item == 0)
            {
                continue;
            }

            notZeroIndex++;

            array[notZeroIndex] = item;
        }

        notZeroIndex++;

        if (notZeroIndex != length)
        {
            array[notZeroIndex..].Clear();
        }
    }

    [Benchmark]
    public void Solution_3()
    {
        int notZeroIndex = -1;
        Span<int> items = nums_3.AsSpan();

        int length = items.Length;
        for (int i = 0; i < length; i++)
        {
            int item = items[i];
            if (item == 0)
            {
                notZeroIndex = i;
                break;
            }
        }

        if (notZeroIndex == -1)
        {
            return;
        }

        Span<int> array = items[notZeroIndex..];

        notZeroIndex = -1;

        length = array.Length;
        for (int i = 0; i < length; i++)
        {
            int item = array[i];
            if (i == 0 && item != 0)
            {
                notZeroIndex++;
                continue;
            }

            if (item == 0)
            {
                continue;
            }

            notZeroIndex++;

            array[notZeroIndex] = item;
            array[i] = 0;
        }
    }

    [Benchmark]
    public void Solution_4()
    {
        int notZeroIndex = -1;
        int index = 0;

        Span<int> items = nums_4.AsSpan();

        int length = items.Length;
        while (index < length)
        {
            if (items[index] != 0)
            {
                notZeroIndex++;
                items[notZeroIndex] = items[index];
            }

            index++;
        }

        notZeroIndex++;

        if (notZeroIndex != length)
        {
            items[notZeroIndex..].Clear();
        }
    }

    [Benchmark]
    public void Solution_5()
    {
        int notZeroIndex = 0;
        int index = 0;

        Span<int> items = nums_5.AsSpan();

        int length = items.Length;
        while (index < length)
        {
            if (items[index] != 0)
            {
                items[notZeroIndex] = items[index];
                notZeroIndex++;
            }

            index++;
        }

        for (int i = notZeroIndex; i < length; i++)
        {
            items[i] = 0;
        }
    }

    [Benchmark]
    public void Solution_6()
    {
        int notZeroCount = 0;

        int length = nums_6.Length;
        for (int i = 0; i < length; i++)
        {
            if (nums_6[i] != 0)
            {
                nums_6[notZeroCount++] = nums_6[i];
            }
        }

        while (notZeroCount < length)
        {
            nums_6[notZeroCount++] = 0;
        }
    }

    [Benchmark]
    public void Solution_7()
    {
        Span<int> items = nums_7.AsSpan();
        
        int notZeroCount = 0;

        int length = items.Length;
        for (int i = 0; i < length; i++)
        {
            if (items[i] != 0)
            {
                items[notZeroCount++] = items[i];
            }
        }

        while (notZeroCount < length)
        {
            items[notZeroCount++] = 0;
        }
    }
}
