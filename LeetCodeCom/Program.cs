using System.Diagnostics;
using BenchmarkDotNet.Running;
using LeetCodeCom.Solutions;

namespace LeetCodeCom;

internal static class Program
{
    internal static void Main()
    {
        Console.CursorVisible = false;

        Console.ForegroundColor = ConsoleColor.White;
        Console.Title = $"[{Process.GetCurrentProcess().ProcessName}] ProcessId: {Environment.ProcessId} Path: {Environment.CurrentDirectory}";

        BenchmarkRunner.Run<ReverseInteger>();

        Console.ReadLine();
    }
}