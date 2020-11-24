using System;
using Jobb.Models;
using Jobb.Models.Implementations;
using Jobb.Models.Implementations.Jobbs;
using Jobb.Utility;

namespace Jobb
{
    class Program
    {
        static void Main(string[] args)
        {
            
            EmptyDirectoryJobb xy = new EmptyDirectoryJobb("Test", new Schedule(Period.Seconds, 1), @"C:\Test");
            while (true)
            {
                
            }
        }
    }
}