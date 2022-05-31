using EmployeesEncountersMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesEncountersMonitor.Parsers
{
    class OfficeAttendanceParser
    {
        private TimeSpanParser TimeSpanParser = new();
        private DayOfWeekParser DayOfWeekParser = new();
        public OfficeAttendanceParser() { }

        public List<OfficeAttendanceModel> Parse(string inputText)
        {
            var officeAttendanceList = new List<OfficeAttendanceModel>();
            var daysEntries = inputText.Split(",");

            foreach (var dayEntry in daysEntries)
            {
                var rawDayOfWeek = dayEntry.Substring(0, 2);
                var rawTimeSpans = dayEntry[2..];

                var dayOfWeek = DayOfWeekParser.Parse(rawDayOfWeek);
                var attendanceResultModel = TimeSpanParser.Parse(rawTimeSpans);

                var entryTime = attendanceResultModel.EntryTime;
                var exitTime = attendanceResultModel.ExitTime;
                var officeAttendance = new OfficeAttendanceModel(dayOfWeek,entryTime,exitTime);
                officeAttendanceList.Add(officeAttendance);
            }

            return officeAttendanceList;
        }
    }
}
