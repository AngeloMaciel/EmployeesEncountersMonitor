using EmployeesEncountersMonitor.Parsers;
using System;
using System.IO;

namespace EmployeesEncountersMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var encountersAnalyser = new EncountersAnalyser();
            var encounters = encountersAnalyser.Analyse();

            foreach (var encounter in encounters)
            {
                Console.WriteLine(encounter);
            }

            Console.ReadLine();
        }
    }
}
