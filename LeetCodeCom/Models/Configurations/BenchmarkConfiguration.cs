using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;

namespace LeetCodeCom.Models.Configurations;

public class BenchmarkConfiguration : ManualConfig
{
    public BenchmarkConfiguration()
    {
        SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend);
    }
}
