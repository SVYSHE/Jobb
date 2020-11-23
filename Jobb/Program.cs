using System;
using Jobb.Models;
using Jobb.Models.Implementations;
using Jobb.Models.Implementations.Jobbs;

namespace Jobb
{
    class Program
    {
        static void Main(string[] args)
        {
            EmptyDirectoryJobb deleteJob = new EmptyDirectoryJobb("empty directory 'test'", @"C:\Test");
            deleteJob.Execute();
        }
    }
}