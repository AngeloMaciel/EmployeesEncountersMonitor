using EmployeesEncountersMonitor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesEncountersMonitor.Parsers
{
    class EmployeesParser
    {
        private string FilePath { get; set; }
        private OfficeAttendanceParser OfficeAttendanceParser = new();
        public EmployeesParser() { }

        public EmployeesParser(string filePath) 
        {
            FilePath = filePath;
        }

        private List<string> ReadFileLines()
        {
            var fileContent = File.ReadAllLines(FilePath);
            return new List<string>(fileContent);
        }
        public List<EmployeeModel> Parse()
        {
            var employeeList = new List<EmployeeModel>();
            var fileContentLines = this.ReadFileLines();

            foreach(var fileLine in fileContentLines)
            {
                var lineSplit = fileLine.Split("=");
                var rawName = lineSplit[0];
                var rawDayTimes = lineSplit[1];

                var employeeName = rawName;
                var attendanceTimes = OfficeAttendanceParser.Parse(rawDayTimes);

                var employee = new EmployeeModel(employeeName,attendanceTimes);
                foreach(var attendanceTime in attendanceTimes)
                {
                    attendanceTime.Employee = employee;
                }
                employeeList.Add(employee);
            }

            return employeeList;
        }
    }
}
