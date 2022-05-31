using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesEncountersMonitor.Parsers.ResultModels
{
    class AttendanceResultModel
    {
        public TimeSpan EntryTime { get; set; }
        public TimeSpan ExitTime { get; set; }
        public AttendanceResultModel() { }
        public AttendanceResultModel(TimeSpan entryTime, TimeSpan exitTime) 
        {
            this.EntryTime = entryTime;
            this.ExitTime  = exitTime;
        }
    }
}
