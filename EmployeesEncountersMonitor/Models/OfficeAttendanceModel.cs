using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesEncountersMonitor.Models
{
    class OfficeAttendanceModel
    {
        public virtual EmployeeModel Employee { get; set; }
        public DayOfWeek DayOfWeek { get; private set; }
        public TimeSpan EntryTime { get; private set; }
        public TimeSpan ExitTime { get; private set; }
        public OfficeAttendanceModel() { }
        public OfficeAttendanceModel(DayOfWeek dayOfWeek, TimeSpan entryTime, TimeSpan exitTime)
        {
            DayOfWeek = dayOfWeek;
            EntryTime = entryTime;
            ExitTime = exitTime;
        }

        public override string ToString()
        {
            return Enum.GetName(DayOfWeek) + " | " + EntryTime +"-"+ExitTime;
        }
    }
}
