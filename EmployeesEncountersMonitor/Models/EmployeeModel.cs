using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesEncountersMonitor.Models
{
    class EmployeeModel
    {

        public string EmployeeName { get; private set; }
        public List<OfficeAttendanceModel> AttendanceTimes { get; }
        public EmployeeModel(string employeeName, List<OfficeAttendanceModel> attendanceTimes)
        {
            EmployeeName = employeeName;
            AttendanceTimes = attendanceTimes;
        }

        public override string ToString()
        {
            var namePart = "Name: " + EmployeeName + "\nAttendance: \n";
            var attendanceDescription = new List<string>(AttendanceTimes.FindAll(a => true)
                .Select(at => new string("\tDay: " + at.DayOfWeek +
            "\n \t\tEntry: " + at.EntryTime + " Exit: " + at.ExitTime + "\n"))
                );
            var result = namePart;
            foreach (var entry in attendanceDescription)
            {
                result += entry;
            }

            return result;
        }
    }
}
