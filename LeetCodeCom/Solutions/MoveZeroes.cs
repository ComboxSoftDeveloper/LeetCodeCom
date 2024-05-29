using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using LeetCodeCom.Models.Configurations;

namespace LeetCodeCom.Solutions;

// https://leetcode.com/problems/move-zeroes/description/

[Config(typeof(BenchmarkConfiguration))]

[SimpleJob(RuntimeMoniker.Net70)]
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

    public int[] nums;

    [GlobalSetup]
    public void GlobalSetup()
    {
        Random random = new(byte.MaxValue);
        const int maxValue = 20;

        nums = Enumerable.Range(1, ItemsCount)
           .Select(_ => random.Next(maxValue))
           .ToArray();
    }

    [Benchmark]
    public void Solution_1()
    {
        if (nums.Length is < 2 or > 10_000)
        {
            return;
        }

        int notZeroIndex = -1;

        Span<int> items = nums.AsSpan();
        for (int i = 0; i < items.Length; i++)
        {
            int item = items[i];
            if (item != 0)
            {
                notZeroIndex++;
                items[notZeroIndex] = item;
            }
        }

        notZeroIndex++;

        if (notZeroIndex != items.Length)
        {
            items[notZeroIndex..].Clear();
        }
    }

    [Benchmark]
    public void Solution_2()
    {
        if (nums.Length is < 2 or > 10_000)
        {
            return;
        }

        int notZeroIndex = -1;

        Span<int> items = nums.AsSpan();
        for (int i = 0; i < items.Length; i++)
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

        for (int i = 0; i < array.Length; i++)
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

        if (notZeroIndex != array.Length)
        {
            array[notZeroIndex..].Clear();
        }
    }

    [Benchmark]
    public void Solution_3()
    {
        if (nums.Length is < 2 or > 10_000)
        {
            return;
        }

        int notZeroIndex = -1;

        Span<int> items = nums.AsSpan();
        for (int i = 0; i < items.Length; i++)
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

        for (int i = 0; i < array.Length; i++)
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
        if (nums.Length is < 2 or > 10_000)
        {
            return;
        }

        int notZeroIndex = -1;
        int index = 0;

        Span<int> items = nums.AsSpan();
        while (index < items.Length)
        {
            if (items[index] != 0)
            {
                notZeroIndex++;
                items[notZeroIndex] = items[index];
            }

            index++;
        }

        notZeroIndex++;

        if (notZeroIndex != items.Length)
        {
            items[notZeroIndex..].Clear();
        }
    }

    [Benchmark]
    public void Solution_5()
    {
        if (nums.Length is < 2 or > 10_000)
        {
            return;
        }

        int notZeroIndex = 0;
        int index = 0;

        Span<int> items = nums.AsSpan();
        while (index < items.Length)
        {
            if (items[index] != 0)
            {
                items[notZeroIndex] = items[index];
                notZeroIndex++;
            }

            index++;
        }

        for (int i = notZeroIndex; i < items.Length; i++)
        {
            items[i] = 0;
        }
    }
}
