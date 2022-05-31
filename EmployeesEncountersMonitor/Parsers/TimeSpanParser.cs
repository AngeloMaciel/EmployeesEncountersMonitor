using EmployeesEncountersMonitor.Parsers.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesEncountersMonitor.Parsers
{
    class TimeSpanParser
    {
        public TimeSpanParser() { }
        public AttendanceResultModel Parse(string inputText)
        {
            var rawTimeSpans = inputText.Split("-");
            
            var entryTime = TimeSpan.Parse(rawTimeSpans[0]);
            var exitTime  = TimeSpan.Parse(rawTimeSpans[1]);

            var result = new AttendanceResultModel(entryTime,exitTime);
            return result;
        }
    }
}
