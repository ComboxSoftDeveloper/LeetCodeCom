using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using LeetCodeCom.Models.Configurations;

// https://leetcode.com/problems/move-zeroes/description/

namespace LeetCodeCom.Solutions;

[Config(typeof(BenchmarkConfiguration))]

[SimpleJob(RuntimeMoniker.Net80, baseline: true)]
[SimpleJob(RuntimeMoniker.Net90)]

[MemoryDiagnoser]
[DisassemblyDiagnoser(printSource: true, exportHtml: true)]

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[HideColumns(Column.Error, Column.StdDev, Column.Median, Column.Job, Column.AllocRatio)]
public class MoveZeroes
{
    [Params(100_000_000)]
    public int ItemsCount;

    public int[] nums_1;
    public int[] nums_2;
    public int[] nums_3;
    public int[] nums_4;
    public int[] nums_5;
    public int[] nums_6;

    [GlobalSetup]
    public void GlobalSetup()
    {
        const int maxValue = 5;
        Random random = new(maxValue);

        int[] numbers = Enumerable.Range(1, ItemsCount)
           .Select(_ => random.Next(maxValue))
           .ToArray();

        nums_1 = numbers.ToArray();
        nums_2 = numbers.ToArray();
        nums_3 = numbers.ToArray();
        nums_4 = numbers.ToArray();
        nums_5 = numbers.ToArray();
        nums_6 = numbers.ToArray();
    }

    [Benchmark]
    public void Solution_1()
    {
        int index = -1;
        Span<int> items = nums_1.AsSpan();

        int length = items.Length - 1;
        for (int i = 0; i < length; i++)
        {
            int item = items[i];
            if (item == 0)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            return;
        }

        Span<int> array = items[index..];

        index = -1;

        length = array.Length;
        for (int i = 0; i < length; i++)
        {
            int item = array[i];
            if (item != 0)
            {
                index++;

                array[index] = item;
                array[i] = 0;
            }
        }
    }

    [Benchmark]
    public void Solution_2()
    {
        int index = -1;

        Span<int> items = nums_2.AsSpan();

        int length = items.Length;
        for (int i = 0; i < length; i++)
        {
            int item = items[i];
            if (item != 0)
            {
                index++;
                items[index] = item;
            }
        }

        index++;

        if (index != length)
        {
            items[index..].Clear();
        }
    }

    [Benchmark]
    public void Solution_3()
    {
        int notZeroIndex = -1;
        int index = 0;

        Span<int> items = nums_3.AsSpan();

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
    public void Solution_4()
    {
        int notZeroIndex = 0;
        int index = 0;

        Span<int> items = nums_4.AsSpan();

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
    public void Solution_5()
    {
        int index = 0;

        int length = nums_5.Length;
        for (int i = 0; i < length; i++)
        {
            if (nums_5[i] != 0)
            {
                nums_5[index++] = nums_5[i];
            }
        }

        while (index < length)
        {
            nums_5[index++] = 0;
        }
    }

    [Benchmark]
    public void Solution_6()
    {
        Span<int> items = nums_6.AsSpan();

        int index = 0;

        int length = items.Length;
        for (int i = 0; i < length; i++)
        {
            if (items[i] != 0)
            {
                items[index++] = items[i];
            }
        }

        while (index < length)
        {
            items[index++] = 0;
        }
    }
}
