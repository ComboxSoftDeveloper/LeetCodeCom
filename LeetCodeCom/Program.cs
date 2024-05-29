using BenchmarkDotNet.Running;
using LeetCodeCom.Solutions;
using System.Diagnostics;

namespace LeetCodeCom;

internal static class Program
{
    internal static void Main()
    {
        Console.CursorVisible = false;

        Console.ForegroundColor = ConsoleColor.White;
        Console.Title = $"[{Process.GetCurrentProcess().ProcessName}] ProcessId: {Environment.ProcessId} Path: {Environment.CurrentDirectory}";

        BenchmarkRunner.Run<MoveZeroes>();
        
        Console.ReadLine();
    }
}