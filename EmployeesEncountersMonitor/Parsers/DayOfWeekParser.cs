using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesEncountersMonitor.Parsers
{
    class DayOfWeekParser
    {
        public DayOfWeekParser() { }

        public DayOfWeek Parse(string inputText)
        {
            var result = inputText switch
            {
                "SU" => DayOfWeek.Sunday,
                "MO" => DayOfWeek.Monday,
                "TU" => DayOfWeek.Tuesday,
                "WE" => DayOfWeek.Wednesday,
                "TH" => DayOfWeek.Thursday,
                "FR" => DayOfWeek.Friday,
                "SA" => DayOfWeek.Saturday,
                _ => throw new NotSupportedException("Invalid day of week abbreviation input.")
            };
            return result;
        }
    }
}
